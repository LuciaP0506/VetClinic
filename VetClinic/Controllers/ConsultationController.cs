using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models;
using VetClinic.Repository;

namespace VetClinic.Controllers
{
    public class ConsultationController : Controller
    {
        private ConsultationRepository consultationRepository = new ConsultationRepository();
        private VetRepository vetRepository = new VetRepository();
        private PetRepository petRepository = new PetRepository();
        private OwnerRepository ownerRepository = new OwnerRepository();
        // GET: Consultation
        public ActionResult Index(string sortOrder)
        {
            ViewBag.IdPetSortParam = string.IsNullOrEmpty(sortOrder) ? "idPet_desc" : "";
            ViewBag.EventDateSortParam = sortOrder == "eventDate" ? "eventDate_desc" : "eventDate";

            var consultations = from c in consultationRepository.GetAllConsultations() select c;

            switch (sortOrder)
            {
                case "idPet_descc":
                    consultations = consultationRepository.OrderByDescendingParameter("IdPet");
                    break;
                case "eventDate_desc":
                    consultations = consultationRepository.OrderByDescendingParameter("EventDate");
                    break;
                case "eventDate":
                    consultations = consultationRepository.OrderByParameter("EventDate");
                    break;
                default:
                    consultations = consultationRepository.OrderByParameter("IdPet");
                    break;
            }

            
            return View(consultations.ToList());
        }

        // GET: Consultation/Details/5
        public ActionResult Details(Guid id)
        {
            ConsultationModel consultationModel = consultationRepository.GetConsultationById(id);
            return View("DetailsConsultation", consultationModel);
        }

        // GET: Consultation/Create
        public ActionResult Create()
        {
            var itemsVet = vetRepository.GetAllVets();
            if (itemsVet != null)
            {
                ViewBag.dataVet = itemsVet;
            }
            var itemsPet = petRepository.GetAllPets();
            if (itemsPet != null)
            {
                ViewBag.dataPet = itemsPet;
            }
            var itemsOwner = ownerRepository.GetAllOwners();
            if (itemsOwner != null)
            {
                ViewBag.dataOwner = itemsOwner;
            }

            return View("CreateConsultation");
        }

        // POST: Consultation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ConsultationModel consultationModel = new ConsultationModel();
                consultationModel.IdVet = Guid.Parse(Request.Form["FirstName"]);
                consultationModel.IdPet = Guid.Parse(Request.Form["Name"]);
                consultationModel.IdOwner = Guid.Parse(Request.Form["LastName"]);
                UpdateModel(consultationModel);
                consultationRepository.InsertConsultation(consultationModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateConsultation");
            }
        }

        // GET: Consultation/Edit/5
        public ActionResult Edit(Guid id)
        {
            ConsultationModel consultationModel = consultationRepository.GetConsultationById(id);
            return View("EditConsultation", consultationModel);
        }

        // POST: Consultation/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                ConsultationModel consultationModel = new ConsultationModel();
                UpdateModel(consultationModel);
                consultationRepository.UpdateConsultation(consultationModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditConsultation");
            }
        }

        // GET: Consultation/Delete/5
        public ActionResult Delete(Guid id)
        {
            ConsultationModel consultationModel = consultationRepository.GetConsultationById(id);
            return View("DeleteConsultation", consultationModel);
        }

        // POST: Consultation/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                consultationRepository.DeleteConsultation(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteConsultation");
            }
        }
    }
}
