using KurthProject2Vet.Models;
using KurthProject2Vet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KurthProject2Vet.Controllers
{
    public class OwnersController : Controller
    {
        //this is the index action method, will be accessible by the route /owners
    /// </summary>
    /// <returns></returns>
   
        private IProject2Repository _repository;
        public OwnersController(IProject2Repository repository)
        {
            _repository = repository;
        }
        [HttpGet]
       /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.Owner
                .Include(owner => owner.Pets)
                .ToListAsync());

            List<Owner> owners = _repository.GetAllOwners();
            
            return View(owners);
        }  */
        [HttpGet]
        public IActionResult Index()
        {
            VetViewModel viewModels = new VetViewModel();
            viewModels.Owners = _repository.GetAllOwnersAsync();
            viewModels.Pets = _repository.GetAllPets();
            return View(viewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AvailablePets = _repository.GetAllPets();
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
            return View(owner);// return to create ???
        }
    }
}
