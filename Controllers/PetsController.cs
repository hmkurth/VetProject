using KurthProject2Vet.Models;
using KurthProject2Vet.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            VetViewModel viewModels = new VetViewModel();
            viewModels.Pets = _repository.GetAllPets();
            return View(viewModels);
          
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AvailableOwners = _repository.GetAllOwners();
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
            ViewBag.AvailableOwners = _repository.GetAllOwners();
            return View(pet);
        }
        [HttpGet]
        //PetServices	(HttpGet)	to	display	the	pets and	all	of	the	services	
        // they have    usedRetrieves	all	of	the	Pet	objects	from	the	database	and	includes	
        //the Services    rendered	for	each pet
           // ii.This will    require utilizing   the.Include() and.ThenInclude()
            //syntax.If you are struggling  with this, please ask  me  for	help J
            //iii.Passes the Pet objects that include the related Services to  the
//          PetServices View
        public IActionResult PetServices()
        {
          
   
             VetViewModel viewModels = new VetViewModel();
            viewModels.Pets = _repository.GetAllPets();
            viewModels.PetServices = _repository.GetAllPetServices();
            ViewBag.PetServices = _repository.GetAllPetServices();//??trying to get a view for petservices
            return View(viewModels);

        }
    }
}
