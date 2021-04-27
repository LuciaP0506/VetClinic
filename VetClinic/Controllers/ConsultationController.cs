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
        // GET: Consultation
        public ActionResult Index()
        {
            List<ConsultationModel> consultations = consultationRepository.GetAllConsultations();
            return View("Index", consultations);
        }

        // GET: Consultation/Details/5
        public ActionResult Details(Guid id)
        {
            ConsultationModel consultationModel = consultationRepository.GetConsultationById(id);
            return View("ConsultationDetails", consultationModel);
        }

        // GET: Consultation/Create
        public ActionResult Create()
        {
            return View("CreateConsultation");
        }

        // POST: Consultation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ConsultationModel consultationModel = new ConsultationModel();
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
