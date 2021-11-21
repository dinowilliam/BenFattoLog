namespace BenFattoLog.Business {

    using BenFattoLog.Business.Contracts;
    using BenFattoLog.Domain.Entities;

    public class LogBusinessFactory : ILogBusinessFactory {
        
        public LogBusinessFactory() {
            
        }

        public Log getLog() {

            return new Log();

        }
    }

}
