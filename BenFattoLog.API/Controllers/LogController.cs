using BenFattoLog.API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BenFattoLog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {

        private readonly ILogger<LogController> _logger;
        private LogManipulator logManipulator;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
            logManipulator = new LogManipulator();
        }

        [HttpGet]
        public ResponseDto GetLogs()
        {
            return logManipulator.GetAll();
        }

        [HttpPut]
        public async Task<IActionResult> PutLogs(LogTupleDto logTupleDTO) {



            return NoContent();
        }
    }
}
