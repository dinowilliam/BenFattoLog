using BenFattoLog.API.DTO;
using BenFattoLog.BLL;
using BenFattoLog.Domain.Entities;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BenFattoLog.API {
    public class LogManipulator {

        LogBusiness logBusiness { get; set; }
        public LogManipulator() {
            this.logBusiness = new LogBusiness();
        }

        public ResponseDto GetAll() {

            var allList = logBusiness.GetAll();

            var localLog = allList.Select(a => new LogTupleDto() {
                Id = a.Id,
                IpAddress = a.IpAddress,
                OccurrenceeDate = a.OccurrenceeDate,
                AccessLog = a.AccessLog,
                HttpResponse = a.HttpResponse,
                Port = a.Port,
                AddDate = a.AddDate

            }).ToList();

            var filledResponseDto = new ResponseDto {
                Total = localLog.Count,
                TotalNotFiltered = localLog.Count,
                Rows = localLog.ToArray()
            };

            return filledResponseDto;
        }

    }
}
