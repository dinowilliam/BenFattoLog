using BenFattoLog.Domain.Entities;
using BenFattoLog.Utils;
using System;
using System.Net;
using Xunit;

namespace BenFattoLog.Tests.Domain {
    public class LogTupleTests {

        [Fact]
        public void IsIPInvalid() {
            // Arrange
            var logTuple = new LogTuple();

            // Act
            logTuple.Ip = IPAddress.Parse("0.0.0.0");

            // Assert
            Assert.NotEqual(logTuple.Ip, LogTupleTestHelper.Ip);

        }

        [Fact]
        public void IsIPValid() {
            // Arrange
            var logTuple = new LogTuple();

            // Act
            logTuple.Ip = IPAddress.Parse("216.239.46.100");

            //assert
            Assert.Equal(logTuple.Ip, LogTupleTestHelper.Ip);

        }

        [Fact]
        public void IsOccurencieInvalid() {
            // Arrange
            var logTuple = new LogTuple();
            // Act
            logTuple.Occurrence = DateTime.MinValue;
            // Assert
            Assert.NotEqual(logTuple.Occurrence, LogTupleTestHelper.Occurrence);
        }
        [Fact]
        public void IsOcurrencieValid() {
            // Arrange
            var logTuple = new LogTuple();
            // Act
            logTuple.Occurrence = DateTime.UtcNow;
            //assert
            Assert.Equal(logTuple.Occurrence, LogTupleTestHelper.Occurrence);
        }

    }
}
