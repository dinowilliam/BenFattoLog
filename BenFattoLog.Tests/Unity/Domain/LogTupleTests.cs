
using BenFattoLog.Domain.Entities;
using System;
using System.Net;
using Xunit;

namespace BenFattoLog.Tests.Domain
{
    public class LogTupleTests {

        [Fact]
        public void IsIPInvalid() {
            // Arrange
            var logTuple = new Log();

            // Act
            logTuple.IpAddress = IPAddress.Parse("0.0.0.0");

            // Assert
            Assert.NotEqual(logTuple.IpAddress, LogTupleTestHelper.Ip);

        }

        [Fact]
        public void IsIPValid() {
            // Arrange
            var logTuple = new Log();

            // Act
            logTuple.IpAddress = IPAddress.Parse("216.239.46.100");

            //assert
            Assert.Equal(logTuple.IpAddress, LogTupleTestHelper.Ip);

        }

        [Fact]
        public void IsOccurencieInvalid() {
            // Arrange
            var logTuple = new Log();
            // Act
            logTuple.OccurrenceeDate = DateTime.MinValue;
            // Assert
            Assert.NotEqual(logTuple.OccurrenceeDate, LogTupleTestHelper.OccurrenceeInvalid);
        }
        [Fact]
        public void IsOcurrencieValid() {
            // Arrange
            var logTuple = new Log();
            // Act
            logTuple.OccurrenceeDate = new DateTime(2020, 12, 1, 0, 0, 0);
            //assert
            Assert.Equal(logTuple.OccurrenceeDate, LogTupleTestHelper.OccurrenceeValid);
        }

    }
}
