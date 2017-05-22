﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestIT.Data;
using TestIT.Entities;
using TestIT.Web.Helpers;
using TestIT.Web.ViewModels;

namespace TestIT.Web.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly TestItContext _context;

        public SampleDataController(TestItContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a TestData with matching Id
        /// </summary>
        /// <remarks>This method will return an IActionResult containing the TestData record and StatusCode 200 if successful. 
        /// If there is a an error, you will get a status message and StatusCode which will indicate what was the error.</remarks>
        /// <param name="id">the ID of the record to retrieve</param>
        /// <returns>an IActionResult</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var testData = await _context.TestDatas
                                   .DefaultIfEmpty(null as TestData)
                                   .SingleOrDefaultAsync(a => a.Id == id);

            if (testData == null)
            {
                return Json(NoContent());
            }

            return Json(Ok(testData));
        }

        // GET: api/sampleData
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var testData = _context.TestDatas;

            if (!testData.Any())
            {
                return Json(NoContent());
            }

            return Json(Ok(await testData.ToListAsync()));
        }

        // POST api/sampleData
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TestData value)
        {
            ICollection<ValidationResult> results = new List<ValidationResult>();

            if (!value.IsModelValid(out results))
            {
                return Json(BadRequest(results));
            }

            try
            {
                value.Id = 0;
                var newTestData = _context.AddAsync(value);
                await _context.SaveChangesAsync();

                return Json(Ok(newTestData.Result.Entity as TestData));
            }
            catch (DbUpdateException exception)
            {
                Debug.WriteLine("An exception occurred: {0}, {1}", exception.InnerException, exception.Message);
                return Json(NotFound("An error occurred; new record not saved"));
            }
        }

        // PUT api/sampleData/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TestData value)
        {
            ICollection<ValidationResult> results = new List<ValidationResult>();

            if (!value.IsModelValid(out results))
            {
                return Json(BadRequest(results));
            }

            bool recordExists = _context.TestDatas.Where(a => a.Id == value.Id).Any();

            if (!recordExists)
            {
                return Json(NoContent());
            }

            try
            {
                _context.Update(value);
                await _context.SaveChangesAsync();
                return Json(Ok(value));
            }
            catch (DbUpdateException exception)
            {
                Debug.WriteLine("An exception occurred: {0}, {1}", exception.InnerException, exception.Message);
                return Json(NotFound("An error occurred; record not updated"));
            }
        }

        // DELETE api/sampleData/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var testData = await _context.TestDatas
                                         .AsNoTracking()
                                         .SingleOrDefaultAsync(m => m.Id == id);

            if (testData == null)
            {
                return Json(NotFound("Record not found; not deleted"));
            }

            try
            {
                _context.TestDatas.Remove(testData);
                await _context.SaveChangesAsync();
                return Json(Ok("deleted"));
            }
            catch (DbUpdateException exception) 
            {
                Debug.WriteLine("An exception occurred: {0}, {1}", exception.InnerException, exception.Message);
                return Json(NotFound("An error occurred; not deleted"));
            }
        }
    }
}
