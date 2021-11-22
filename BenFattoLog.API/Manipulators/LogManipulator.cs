using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BenFattoLog.API {

    using BenFattoLog.API.Manipulators.Contracts;
    using BenFattoLog.Application.Contracts;
    using BenFattoLog.Application.DTO;

    public class LogManipulator : ILogManipulator {

        private readonly ILogApplication logApplication;

        public LogManipulator(ILogApplication logApplication) {
            this.logApplication = logApplication;
        }

        public Task<ResponseDTO> Save(LogDTO log) {
            int result;                                        
            
            result = logApplication.Save(log);

            var response = new ResponseDTO {
                Success = result == 0 ? true : false
            };

            return Task.FromResult(response);
        }
        public Task<ResponseDTO> Delete(Guid id) {

            var result = logApplication.Delete(id);

            var response = new ResponseDTO {
                Success = result == 0 ? true : false
            };

            return Task.FromResult(response);
        }

        public ResponseTableDTO GetAll() {

            var allList = logApplication.GetAll();

            var localLog = allList.Select(a => new LogDTO() {
                Id = a.Id,
                IpAddress = a.IpAddress,
                OccurrenceeDate = a.OccurrenceeDate,
                AccessLog = a.AccessLog,
                HttpResponse = a.HttpResponse,
                Port = a.Port
            }).ToList();

            var filledResponseDto = new ResponseTableDTO {
                Total = localLog.Count,
                TotalNotFiltered = localLog.Count,
                Rows = localLog.ToArray()
            };

            return filledResponseDto;
        }

        public ResponseTableDTO LogFilter(LogSearchDTO logSearch) {

            var logSearchLocal = new LogSearchDTO() {
                IpAddress = logSearch.IpAddress,
                InitialDate = logSearch.InitialDate,
                FinalDate = logSearch.FinalDate,
                UserAgent = logSearch.UserAgent,

            };

            var allList = logApplication.LogFilter(logSearchLocal);

            var localLog = allList.Select(a => new LogDTO() {
                Id = a.Id,
                IpAddress = a.IpAddress,
                OccurrenceeDate = a.OccurrenceeDate,
                AccessLog = a.AccessLog,
                HttpResponse = a.HttpResponse,
                Port = a.Port
            }).ToList();

            var filledResponseDto = new ResponseTableDTO {
                Total = localLog.Count,
                TotalNotFiltered = localLog.Count,
                Rows = localLog.ToArray()
            };

            return filledResponseDto;
        }

        public async Task<ResponseDTO> GetUpload(List<IFormFile> files) {

            int result = 1;

            foreach (var formFile in files) {
                if (formFile.Length > 0) {

                    var msFile = new MemoryStream();
                    await formFile.CopyToAsync(msFile);

                    result = logApplication.Upload(msFile.ToArray());

                }
            }

            var response = new ResponseDTO {
                Success = result == 0 ? true : false
            };

            return await Task.FromResult(response);
        }

    }
}
