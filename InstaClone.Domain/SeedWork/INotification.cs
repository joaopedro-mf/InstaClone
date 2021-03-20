using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.SeedWork
{
    public interface INotification
    {
        List<Error> Errors { get; }
        void AddError(Error erro);
        void AddErrors(IEnumerable<Error> erros);
    }
}
