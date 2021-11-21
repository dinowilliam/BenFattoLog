using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BenFattoLog.API
{

    using BenFattoLog.API.DTO;
    using BenFattoLog.Application;

    public class LogManipulator {

        LogApplication logApplication { get; set; }

        public LogManipulator() {
            this.logApplication = new LogApplication();
        }

        public Task<ResponseDto> Save(LogTupleDto log) {
            int result;

            if (log.Id == null) {
                var logSave = new LogTuple() {
                    Id = Guid.NewGuid(),
                    IpAddress = log.IpAddress,
                    OccurrenceeDate = log.OccurrenceeDate,
                    AccessLog = log.AccessLog,
                    HttpResponse = log.HttpResponse,
                    Port = log.Port

                };

                result = logBusiness.Save(logSave);


            }
            else{
                var logSave = new LogTuple() {
                    Id = log.Id.Value,
                    IpAddress = log.IpAddress,
                    OccurrenceeDate = log.OccurrenceeDate,
                    AccessLog = log.AccessLog,
                    HttpResponse = log.HttpResponse,
                    Port = log.Port

                };

                result = logBusiness.Update(logSave);

            }

            var response = new ResponseDto {
                Success = result == 0 ? true : false
            };

            return Task.FromResult(response);
        }
        public Task<ResponseDto> Delete(Guid id) {

            var result = logBusiness.Delete(id);

            var response = new ResponseDto {
                Success = result == 0 ? true : false
            };

            return Task.FromResult(response);
        }

        public ResponseTableDto GetAll() {

            var allList = logBusiness.GetAll();

            var localLog = allList.Select(a => new LogTupleDto() {
                Id = a.Id,
                IpAddress = a.IpAddress,
                OccurrenceeDate = a.OccurrenceeDate,
                AccessLog = a.AccessLog,
                HttpResponse = a.HttpResponse,
                Port = a.Port
            }).ToList();

            var filledResponseDto = new ResponseTableDto {
                Total = localLog.Count,
                TotalNotFiltered = localLog.Count,
                Rows = localLog.ToArray()
            };

            return filledResponseDto;
        }

        public ResponseTableDto LogFilter(LogSearchDto logSearch) {

            var logSearchLocal = new LogSearch() {
                IpAddress = logSearch.IpAddress,
                InitialDate = logSearch.InitialDate,
                FinalDate = logSearch.FinalDate,
                UserAgent = logSearch.UserAgent,

            };

            var allList = logBusiness.LogFilter(logSearchLocal);

            var localLog = allList.Select(a => new LogTupleDto() {
                Id = a.Id,
                IpAddress = a.IpAddress,
                OccurrenceeDate = a.OccurrenceeDate,
                AccessLog = a.AccessLog,
                HttpResponse = a.HttpResponse,
                Port = a.Port
            }).ToList();

            var filledResponseDto = new ResponseTableDto {
                Total = localLog.Count,
                TotalNotFiltered = localLog.Count,
                Rows = localLog.ToArray()
            };

            return filledResponseDto;
        }

        public async Task<ResponseDto> GetUpload(List<IFormFile> files) {

            int result = 1;

            foreach (var formFile in files) {
                if (formFile.Length > 0) {

                    var msFile = new MemoryStream();
                    await formFile.CopyToAsync(msFile);

                    result = logBusiness.Upload(msFile.ToArray());

                }
            }

            var response = new ResponseDto {
                Success = result == 0 ? true : false
            };

            return await Task.FromResult(response);
        }

    }
}
