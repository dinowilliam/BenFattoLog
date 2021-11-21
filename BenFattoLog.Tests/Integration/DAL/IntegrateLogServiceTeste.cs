using BenFattoLog.DAL.Services;
using BenFattoLog.Domain.Entities;
using BenFattoLog.Utils;
using System;
using System.Net;
using Xunit;

namespace BenFattoLog.Tests.Domain {
    public class IntegrateLogServiceTests {

        [Fact]
        public void IsLogServiceInsertingTrue() {
            // Arrange
            var logTuple = new Log();
            var logService = new LogService();

            logTuple.Id = Guid.NewGuid();
            logTuple.IpAddress = IPAddress.Parse("215.35.134.34");
            logTuple.OccurrenceeDate = DateTime.UtcNow;
            logTuple.AccessLog = "GET /~oswinds/publications.html HTTP/1.0";
            logTuple.HttpResponse = 404;
            logTuple.Port = 48966;

            // Act
            logService.Save(logTuple);
            var retorno = logService.GetById(logTuple.Id);

            // Assert
            Assert.Equal(logTuple.Id, retorno.Id);

        }

    }
}
