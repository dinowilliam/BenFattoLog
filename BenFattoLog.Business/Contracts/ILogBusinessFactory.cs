namespace BenFattoLog.Business.Contracts {

    using BenFattoLog.Domain.Entities;

    internal interface ILogBusinessFactory {
        Log getLog();
    }
}
