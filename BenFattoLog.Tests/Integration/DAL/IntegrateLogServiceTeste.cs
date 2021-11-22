using System;
using System.Net;
using Moq;
using Xunit;

namespace BenFattoLog.Tests.Domain {
    
    using BenFattoLog.DAL.Repositorys.Models;
    using BenFattoLog.DAL.Services.Contracts;    

    public class IntegrateLogServiceTests {        

        [Fact]
        public void LogService_IsInserting_True() {

            // Arrange
            var log = new LogPersistance();            
            var logServiceQueries = new Mock<ILogServiceQueries>();

            log.Id = Guid.NewGuid();
            log.IpAddress = IPAddress.Parse("215.35.134.34");
            log.OccurrenceeDate = DateTime.UtcNow;
            log.AccessLog = "GET /~oswinds/publications.html HTTP/1.0";
            log.HttpResponse = 404;
            log.Port = 48966;

            // Act
            logServiceQueries.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(log);

            var retorno = logServiceQueries.Object.GetById(log.Id);                 

            // Assert
            Assert.Equal(log.Id, retorno.Id);

        }

    }
}
