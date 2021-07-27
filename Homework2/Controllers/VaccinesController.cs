using Homework2.Models;
using Homework2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework2.Controllers
{
    public class VaccinesController : Controller
    {
        private readonly IVaccineService _vaccineService;

        public VaccinesController(IVaccineService vaccineService) {
            _vaccineService = vaccineService;
        }

        public IActionResult Index()
        {
            return View(_vaccineService.GetVaccines());
        }


        //EDIT ACTION
        [HttpGet]
        public IActionResult Details(int id) {
            return View(_vaccineService.GetVaccine(id));
        }

        [HttpPost]
        public IActionResult Details(int id, Vaccine update) {
            var vaccine = _vaccineService.GetVaccine(id);
            vaccine.VaccineName = update.VaccineName;
            vaccine.daysBetweenDoses = update.daysBetweenDoses;
            _vaccineService.SaveChanges();
            return RedirectToAction("Index");
        }

        //ADDING VACCINE REQUIRES 2 ACTIONS
        //Action1: Display Form: doGet()
        [HttpGet]
        public IActionResult Add() {
            return View();
        }

        //Action2: Process Form Submission: doPost()
        [HttpPost]
        public IActionResult Add(Vaccine vaccine) {
            _vaccineService.AddVaccine(vaccine);
            return RedirectToAction("Index");
        }

        //NEW DOSES
        //Action1: Display form - doGet()
        [HttpGet]
        public IActionResult Dose() {
            return View(_vaccineService.GetVaccines());
        }

        //Action2: Process Form Submission: doPost()
        [HttpPost]
        public IActionResult Dose(Vaccine update) {
            var vaccine = _vaccineService.GetVaccine(update.VaccineName);
            vaccine.totalDoses = update.totalDoses;
            _vaccineService.SaveChanges();
            return RedirectToAction("Index");
        }


   
    }
}
