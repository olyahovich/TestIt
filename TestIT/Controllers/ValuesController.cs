using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using RawRabbit;
using RawRabbit.Enrichers.MessageContext.Context;
using RawRabbit.Operations.MessageSequence;
using TestIT.SharedLibraries.Messages;

namespace TestIT.Web.Controllers
{
    [RequireHttps]
    public class ValuesController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly Random _random;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(IBusClient legacyBusClient, ILoggerFactory loggerFactory)
        {
            _busClient = legacyBusClient;
            _logger = loggerFactory.CreateLogger<ValuesController>();
        }
        
        [HttpPost]
        [Route("api/values")]
        public async Task<IActionResult> PostAsync([FromBody]RequestMessage request)
        {
            _logger.LogDebug("Recieved Value Request.");
            var valueSequence = _busClient.ExecuteSequence(s => s
                .PublishAsync(request)
                .When<ValueCreationFailed, TestItMessageContext>(
                    (failed, context) =>
                    {
                        _logger.LogWarning("Unable to create Values. Exception: {0}", failed.Exception);
                        return Task.FromResult(true);
                    }, it => it.AbortsExecution())
                .Complete<ResponseMessage>()
            );

            try
            {
                await valueSequence.Task;
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"No response recieved. Is the Console App started? \n\nException: {e}");
            }
            

            return Ok(valueSequence.Task.Result.ResultPath);
        }
        
        [HttpGet("api/values/{path}")]
        public async Task<string> GetAsync(string pathToFile)
        {
            _logger.LogInformation("Requesting Value with path to file {valueId}", pathToFile);
            var response = await _busClient.RequestAsync<RequestMessage, ResponseMessage>(new RequestMessage { PathToFile = pathToFile });
            return response.ResultPath;
        }
    }
}
