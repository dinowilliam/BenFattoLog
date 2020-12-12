using BenFattoLog.API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenFattoLog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {

        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<LogTupleDTO> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new LogTupleDTO {
                Id = Guid.NewGuid(),
                OccurrenceeDate = DateTime.Now.AddDays(index),
                HttpResponse = 404,
                Port = rng.Next(0, 65535),
                AddDate = DateTime.Now
            }).ToArray();
        }
    }
}
