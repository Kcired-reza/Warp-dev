using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarpDev_Derick.Models;
using System.Data.Entity;
using Warp_Derick.Models;

namespace Warp_Derick.Controllers
{
    public class PersonsController : Controller
    {
        private ApplicationDbContext context;

        public PersonsController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Persons
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("CreateForm");
        }

        public ActionResult CreateProcess(PersonModel personModel)
        {
            PersonModel person = context.Persons.SingleOrDefault(g => g.Email == personModel.Email);

            if (person != null)
            {
                ModelState.AddModelError("Email", "Person with this email already exists.");
                return View("CreateForm");
            }
            else
            {
                if (personModel.Colour == "")
                {
                    personModel.Colour = "None";
                }
                context.Persons.Add(personModel);
                context.SaveChanges();
                return View("SuccessView",personModel);
            }

        }


        public ActionResult Edit(int id)
        {
            PersonModel person = context.Persons.SingleOrDefault(g => g.ID == id);
            return View("AdminView", person);
        }

        public ActionResult Details(int id)
        {
            PersonModel person = context.Persons.SingleOrDefault(g => g.ID == id);
            return View("SuccessView", person);
        }

        public ActionResult UpdateProcess(PersonModel personModel)
        {
            PersonModel person = context.Persons.SingleOrDefault(g => g.ID == personModel.ID);
            person.Name = personModel.Name;
            person.Surname = personModel.Surname;
            person.Email = personModel.Email;
            person.Password = personModel.Password;
            person.Conf_Password = personModel.Conf_Password;
            person.Country = personModel.Country;
            person.Colour = personModel.Colour;
            person.Birthday = personModel.Birthday;
            person.Cell = personModel.Cell;
            person.Comments = personModel.Comments;
            context.SaveChanges();
            return View("SuccessView", personModel);
        }
    }
}