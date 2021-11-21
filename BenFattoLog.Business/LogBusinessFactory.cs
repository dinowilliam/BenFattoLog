using System;
using System.Net;

namespace BenFattoLog.Business {

    using BenFattoLog.Business.Contracts;
    using BenFattoLog.Domain.Entities;
    using BenFattoLog.Domain.Entities.Contracts;    

    public class LogBusinessFactory : ILogBusinessFactory {
        
        public LogBusinessFactory() {
            
        }

        public ILog createLog(IPAddress ip, DateTime occurrencee, string accesslog, short httpresponse, int port) {

            return new Log(ip, occurrencee, accesslog, httpresponse, port);

        }
    }

}
