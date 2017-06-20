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
    [SwaggerIgnore]
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
            _random = new Random();
        }

        [Authorize]
        [HttpGet]
        [Route("api/values")]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogDebug("Recieved Value Request.");
            var valueSequence = _busClient.ExecuteSequence(s => s
                .PublishAsync(new ValuesRequested
                {
                    NumberOfValues = _random.Next(1, 10)
                })
                .When<ValueCreationFailed, MessageContext>(
                    (failed, context) =>
                    {
                        _logger.LogWarning("Unable to create Values. Exception: {0}", failed.Exception);
                        return Task.FromResult(true);
                    }, it => it.AbortsExecution())
                .Complete<ValuesCalculated>()
            );

            try
            {
                await valueSequence.Task;
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"No response recieved. Is the Console App started? \n\nException: {e}");
            }

            _logger.LogInformation("Successfully created {valueCount} values", valueSequence.Task.Result.Values.Count);

            return Ok(valueSequence.Task.Result.Values);
        }

        [Authorize]
        [HttpGet("api/values/{id}")]
        public async Task<string> GetAsync(int id)
        {
            _logger.LogInformation("Requesting Value with id {valueId}", id);
            var response = await _busClient.RequestAsync<ValueRequest, ValueResponse>(new ValueRequest { Value = id });
            return response.Value;
        }
    }
}
