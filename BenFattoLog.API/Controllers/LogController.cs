using BenFattoLog.API.Manipulators.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenFattoLog.API.Controllers {

    using BenFattoLog.Application.DTO;

    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {

        private readonly ILogger<LogController> _logger;
        private readonly ILogManipulator logManipulator;

        public LogController(ILogger<LogController> logger, ILogManipulator logManipulator)
        {
            _logger = logger;
            this.logManipulator = logManipulator;
        }

        [HttpGet]
        public ResponseTableDTO GetLogs()
        {
            return logManipulator.GetAll();
        }

        [HttpPost("Search")]
        public ResponseTableDTO GetLogsSearch(LogSearchDTO logSearch) {
            return logManipulator.LogFilter(logSearch);
        }

        [HttpPut]
        public async Task<ResponseDTO> PutLogs(LogDTO logDTO) {

            return await logManipulator.Save(logDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDTO> DeleteLogs(Guid id) {

            return await logManipulator.Delete(id);
        }

        [HttpPut("Upload")]
        public async Task<ResponseDTO> OnPostUploadAsync(List<IFormFile> files) {

           return await logManipulator.GetUpload(files); ;
        }
    }
}
