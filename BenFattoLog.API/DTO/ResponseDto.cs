using System;
using System.Collections.Generic;
using System.Net;

namespace BenFattoLog.API.DTO
{
    public class ResponseDto {
        public bool Success{ get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }

    }
}
