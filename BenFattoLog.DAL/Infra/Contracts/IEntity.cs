using System;

namespace BenFattoLog.DAL.Infra.Contracts {
    public interface IEntity {
        Guid Id { get; set; }
    }
}
