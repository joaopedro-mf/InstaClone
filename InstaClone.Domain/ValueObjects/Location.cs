using InstaClone.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InstaClone.Domain.ValueObjects
{
    [ComplexType]
    [Owned]
    public class Location : ValueObject
    {
        public string Name { get; set; }
        public string City { get; set;}
        public string State { get; set; }
        public string Country { get; set; }

        public Location() { }

        public Location(string name, string city, string state, string country ) 
        {
            Name = name;
            City = city;
            State = state;
            Country = country;
        }

        public Location(string FullLocation)
        {
            string[] subs = FullLocation.Split(',');

            Validate(subs);

            
            Name = IfNullReturnDefault(subs[0]);
            if (subs.Length >= 2)
                City = IfNullReturnDefault(subs[1]);
            if (subs.Length >= 3)
                State = IfNullReturnDefault(subs[2]);
            if (subs.Length >= 4)
                Country = IfNullReturnDefault(subs[3]);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return City;
            yield return State;
            yield return Country;

        }

        private void Validate(string[] value)
        {
            if (value.Length > 2)
            {
                //state
                if (value[2].Length > 2)
                    AddError(new Error("Location", "Estado com formato invalido"));
                // country
                if (value[3].Length > 2)
                    AddError(new Error("Location", "Pais formato invalido"));
            }
        }

        public string GetValue()
        {
            return $"{Name}, {City},{State},{Country}";
        }

        private string IfNullReturnDefault(string value) =>
               value == null ? "" : value;
    }
}
