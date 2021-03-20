using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.SeedWork
{
    public class Error
    {
        public string Message { get; set; }
        public string Local { get; set; }

        public Error( string local, string message)
        {
            Message = message;
            Local = local;
        }

        public string GetError()
        {
          return $"{Local} - {Message}";
        }
    }
}
