using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenFattoLog.API.Manipulators.Contracts {
    
    using BenFattoLog.Application.DTO;

    public interface ILogManipulator {
        public Task<ResponseDTO> Save(LogDTO log);
        public Task<ResponseDTO> Delete(Guid id);
        public ResponseTableDTO GetAll();
        public ResponseTableDTO LogFilter(LogSearchDTO logSearch);
        public Task<ResponseDTO> GetUpload(List<IFormFile> files);
    }
}