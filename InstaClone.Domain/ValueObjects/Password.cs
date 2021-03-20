using InstaClone.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace InstaClone.Domain.ValueObjects
{
    [ComplexType]
    [Owned]
    public class Password : ValueObject
    {

        //TODO -> check change Value for private
        public string Value { get; set; }

        public Password(){ }
        public Password(string value)
        {
            Validate(value);
            if (Errors.Count == 0)
                GenareteHash(value);
            else Value = "";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private void GenareteHash(string value)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            Value = hash.ToString();
        }

        // value need be a hash value
        public bool CheckPassword(string valueForCompare)
        {

            bool bEqual = false;
            if (Value.Length == valueForCompare.Length)
            {
                int i = 0;
                while ((i < Value.Length) && (Value[i] == valueForCompare[i]))
                {
                    i += 1;
                }
                if (i == Value.Length)
                {
                    bEqual = true;
                }
            }

            return bEqual;
        }

        private void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                AddError( new Error("Password","Senha não informada."));

            if (value.Length < 6 || value.Length > 15)
                AddError(new Error("Password", "Senha com tamanho invalido."));

            if (Regex.IsMatch(value, (@"[^a-zA-Z0-9]")))
                AddError(new Error("Password", "Senha não possui caracter especial."));

        }
    }
}
