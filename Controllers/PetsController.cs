using KurthProject2Vet.Models;
using Microsoft.AspNetCore.Mvc;
using KurthProject2Vet.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurthProject2Vet.Controllers
{
    public class PetsController : Controller
    {
        //this is the index action method, will be accessible by the route /owners
        /// </summary>
        /// <returns></returns>

        private IProject2Repository _repository;
        public PetsController(IProject2Repository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Pet> pets = _repository.GetAllPets();

            return View(pets);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pet pet)
        {
            if (ModelState.IsValid == true)
            {
                //insert owner into dtabase
                _repository.AddPet(pet);
                return RedirectToAction("Index");
            }
            return View(pet);
        }
        [HttpGet]
        //PetServices	(HttpGet)	to	display	the	pets and	all	of	the	services	
       // they have    used
        public IActionResult PetServices()
        {
            List<Pet> petServices = _repository.GetAllPetServices();

            return View(petServices);
        }
    }
}
