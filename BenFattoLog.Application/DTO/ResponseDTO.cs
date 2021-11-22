using System;
using System.Collections.Generic;
using System.Net;

namespace BenFattoLog.Application.DTO
{
    public class ResponseDTO {
        public bool Success{ get; set; }
        public IEnumerable<MessageDTO> Messages { get; set; }

    }
}
