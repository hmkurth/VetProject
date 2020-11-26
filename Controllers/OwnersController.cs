using KurthProject2Vet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Index()
        {
            List<Owner> owners = _repository.GetAllOwners();
            
            return View(owners);
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
