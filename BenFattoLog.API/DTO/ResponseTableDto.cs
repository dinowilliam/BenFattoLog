using System;
using System.Collections.Generic;
using System.Net;

namespace BenFattoLog.API.DTO
{
    public class ResponseTableDto {
        public int Total { get; set; }
        public int TotalNotFiltered { get; set; }
        public IEnumerable<LogTupleDto> Rows { get; set; }

    }
}