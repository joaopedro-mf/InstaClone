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

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return City;
            yield return State;
            yield return Country;

        }
    }
}
