using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework2.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string VaccineName { get; set; }
        public int dosesRequired { get; set; }
        public int daysBetweenDoses { get; set; }
        public int totalDoses { get; set; }

        public Vaccine() { }

        public Vaccine(int id, string name, int dosesrequired, int daysbetweendoses, int totaldoses) {
            Id = id;
            VaccineName = name;
            dosesRequired = dosesrequired;
            daysBetweenDoses = daysbetweendoses;
            totalDoses = totaldoses;
        }

    }
}
