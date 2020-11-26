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
        public IActionResult Create(Owner owner)
        {
            if (ModelState.IsValid == true)
            {
                //insert owner into dtabase
                _repository.AddOwner(owner);
                return RedirectToAction("Index");
            }
            return View(owner);
        }
    }
}
