using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.SeedWork
{
    public interface IResponse 
    {
        bool Sucesso { get; }
        string[] GetErros();
        object GetResponse();
     }
}
