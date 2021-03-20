using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Domain.SeedWork
{
    public class Response<TEntity> : IResponse where TEntity:class
    {
        public readonly List<Error> _erros;
        public bool Sucesso => Erros.Count ==0;

        public TEntity ObjectOfResponse;

        public Response()
        {
            _erros = new List<Error>();
        }

        public Response(TEntity response)
        {
            _erros = new List<Error>();
            ObjectOfResponse = response;
        }
        public Response(TEntity response, List<Error> erros)
        {
            _erros = erros;
            ObjectOfResponse = response;
        }
        public Response(TEntity response, Error erros)
        {
            _erros = new List<Error>();
            _erros.Add(erros);
            ObjectOfResponse = response;
        }
        public List<Error> Erros => _erros as List<Error>;

        public void AddErro(Error erro) =>  _erros.Add(erro);
        
        public void AddErros(IEnumerable<Error> erros) => _erros.AddRange(erros);

        public string[] GetErros()
        {
            List<string> ErrorsList = new List<string>();

            foreach (var err in _erros)
                ErrorsList.Add(err.GetError());

            return ErrorsList.ToArray();
        }

        public object GetResponse()
        {
            return ObjectOfResponse;
        }
    }
}
