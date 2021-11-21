using System;
using System.Net;

namespace BenFattoLog.Business.Contracts {

    using BenFattoLog.Domain.Entities.Contracts;    

    internal interface ILogBusinessFactory {
        ILog createLog(IPAddress ip, DateTime occurrencee, string accesslog, short httpresponse, int port);
    }
}
