using System.Collections.Generic;

namespace BenFattoLog.Application.DTO
{
    public class ResponseTableDTO {
        public int Total { get; set; }
        public int TotalNotFiltered { get; set; }
        public IEnumerable<LogDTO> Rows { get; set; }

    }
}
