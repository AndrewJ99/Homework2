using Homework2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework2.Services
{
    public interface IVaccineService {
        List<Vaccine> GetVaccines();

        Vaccine GetVaccine(int id);

        Vaccine GetVaccine(string name);

        void AddVaccine(Vaccine vaccine);

        void newDoses(Vaccine vaccine);

        void SaveChanges();
    }

    public class VaccineService : IVaccineService {
        private readonly AppDbContext _db;

        public VaccineService(AppDbContext db) {
            _db = db;
        }

        public List<Vaccine> GetVaccines() {
            return _db.Vaccines.ToList();
        }

        public Vaccine GetVaccine(int id) {
            return _db.Vaccines.Where(e => e.Id == id).Select(e => e).FirstOrDefault();
        }

        public Vaccine GetVaccine(String name) {
            return _db.Vaccines.Where(e => e.VaccineName == name).Select(e => e).FirstOrDefault();
        }

        public void AddVaccine(Vaccine vaccine) {
            _db.Vaccines.Add(vaccine);
            _db.SaveChanges();
        }

        public void newDoses(Vaccine vaccine) {
            _db.Vaccines.Update(vaccine);
            _db.SaveChanges();
        }

        public void SaveChanges() => _db.SaveChanges();

    }

    /*public class MockVaccineService : IVaccineService
    {
        private List<Vaccine> vaccines;

        public MockVaccineService() {
            vaccines = new List<Vaccine> {
                new Vaccine(1, "Pizer", 2, 21, 10000)
            };  
        }

        public List<Vaccine> GetVaccines() {
            return vaccines;
        }

        public Vaccine GetVaccine(int id) {
            return vaccines[id - 1];
        }

        public void AddVaccine(Vaccine vaccine) {
            vaccine.Id = vaccines.Count;
            vaccines.Add(vaccine);
        }
    }*/
}
