

using System;

namespace HospitalClassLib.SharedModel
{
   public class Country
   {

        public Country()
        {
        }

        public Country(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}