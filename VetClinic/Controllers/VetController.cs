using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models;
using VetClinic.Repository;

namespace VetClinic.Controllers
{
    public class VetController : Controller
    {
        private VetRepository vetRepository = new VetRepository();
        // GET: Vet
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.FirstNameSortParam = string.IsNullOrEmpty(sortOrder) ? "firstName_desc" : "";
            ViewBag.LastNameSortParam = sortOrder == "lastName" ? "lastName_desc" : "lastName";
            ViewBag.SpecializationSortParam = sortOrder == "specialization" ? "specialization_desc" : "specialization";

            var vets = from v in vetRepository.GetAllVets() select v;

            if (!string.IsNullOrEmpty(searchString))
            {
                vets = vetRepository.SearchString(searchString);
            }
            else
            {
                switch (sortOrder)
                {
                    case "firstName_desc":
                        vets = vetRepository.OrderByDescendingParameter("FirstName");
                        break;
                    case "lastName_desc":
                        vets = vetRepository.OrderByDescendingParameter("LastName");
                        break;
                    case "lastName":
                        vets = vetRepository.OrderByParameter("LastName");
                        break;
                    case "specialization_desc":
                        vets = vetRepository.OrderByDescendingParameter("Specialization");
                        break;
                    case "specialization":
                        vets = vetRepository.OrderByParameter("Specialization");
                        break;
                    default:
                        vets = vetRepository.OrderByParameter("FirstName");
                        break;
                }
            }               
                       
            return View(vets.ToList());
        }

        // GET: Vet/Details/5
        public ActionResult Details(Guid id)
        {
            VetModel vetModel = vetRepository.GetVetById(id);
            return View("VetDetails", vetModel);
        }

        [Authorize(Roles = "Admin")]
        // GET: Vet/Create
        public ActionResult Create()
        {
            return View("CreateVet");
        }

        [Authorize(Roles = "Admin")]
        // POST: Vet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                VetModel vetModel = new VetModel();
                UpdateModel(vetModel);
                vetRepository.InsertVet(vetModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateVet");
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Vet/Edit/5
        public ActionResult Edit(Guid id)
        {
            VetModel vetModel = vetRepository.GetVetById(id);
            return View("EditVet", vetModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: Vet/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                VetModel vetModel = new VetModel();
                UpdateModel(vetModel);
                vetRepository.UpdateVet(vetModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditVet");
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Vet/Delete/5
        public ActionResult Delete(Guid id)
        {
            VetModel vetModel = vetRepository.GetVetById(id);

            return View("DeleteVet", vetModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: Vet/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                vetRepository.DeleteVet(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteVet");
            }
        }
    }
}
