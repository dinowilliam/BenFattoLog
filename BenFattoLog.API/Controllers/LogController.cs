using BenFattoLog.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ResponseTableDto GetLogs()
        {
            return logManipulator.GetAll();
        }

        [HttpPost("Search")]
        public ResponseTableDto GetLogsSearch(LogSearchDto logSearch) {
            return logManipulator.LogFilter(logSearch);
        }

        [HttpPut]
        public async Task<ResponseDto> PutLogs(LogTupleDto logTuple) {

            return await logManipulator.Save(logTuple);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto> DeleteLogs(Guid id) {

            return await logManipulator.Delete(id);
        }

        [HttpPut("Upload")]
        public async Task<ResponseDto> OnPostUploadAsync(List<IFormFile> files) {

           return await logManipulator.GetUpload(files); ;
        }
    }
}
