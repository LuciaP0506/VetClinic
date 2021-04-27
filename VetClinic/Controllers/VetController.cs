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
        public ActionResult Index()
        {
            List<VetModel> vets = vetRepository.GetAllVets();
            return View("Index", vets);
        }

        // GET: Vet/Details/5
        public ActionResult Details(Guid id)
        {
            VetModel vetModel = vetRepository.GetVetById(id);
            return View("VetDetails", vetModel);
        }

        // GET: Vet/Create
        public ActionResult Create()
        {
            return View("CreateVet");
        }

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

        // GET: Vet/Edit/5
        public ActionResult Edit(Guid id)
        {
            VetModel vetModel = vetRepository.GetVetById(id);
            return View("EditVet", vetModel);
        }

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

        // GET: Vet/Delete/5
        public ActionResult Delete(Guid id)
        {
            VetModel vetModel = vetRepository.GetVetById(id);

            return View("DeleteVet", vetModel);
        }

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
