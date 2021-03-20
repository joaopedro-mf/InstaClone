using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InstaClone.Domain.SeedWork
{
    
    public class Notification : INotification
    {
        [NotMapped]
        public bool haveError => _erros.Count != 0;
        [NotMapped]
        public readonly List<Error> _erros;

        public Notification()
        {
            _erros = new List<Error>();
        }

        public List<Error> Errors => _erros as List<Error>;

        public void AddError(Error erro) => _erros.Add(erro);

        public void AddErrors(IEnumerable<Error> erros) => _erros.AddRange(erros);
    }
}
