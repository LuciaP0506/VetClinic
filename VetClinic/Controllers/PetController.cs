using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models;
using VetClinic.Repository;


namespace VetClinic.Controllers
{
    public class PetController : Controller
    {
        private PetRepository petRepository = new PetRepository();
        private ConsultationRepository consultationRepository = new ConsultationRepository();

        [Authorize(Roles = "Admin, Vet")]
        // GET: Pet
        public ActionResult Index(string sortOrder,  string searchString)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : ""; 
            ViewBag.SpeciesSortParam = sortOrder == "species" ? "species_desc" : "species";
            ViewBag.RaceSortParam = sortOrder == "races" ? "race_desc" : "races";
            //var pets = new List<PetModel>();
           
            var pets = from p in petRepository.GetAllPets() select p;
           
            if(!string.IsNullOrEmpty(searchString))
            {
                pets = pets.Where(p => p.Name.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "name_desc":
                    pets = petRepository.OrderByDescendingParameter("Name");
                    break;
                case "species_desc":
                    pets = petRepository.OrderByDescendingParameter("Species");
                    break;
                case "species":
                    pets = petRepository.OrderByParameter("Species");
                    break;
                case "race_desc":
                    pets = petRepository.OrderByDescendingParameter("Race");
                    break;
                case "races":
                    pets = petRepository.OrderByParameter("Race");
                    break;
                default:
                    pets = petRepository.OrderByParameter("Name");
                    break;
            }

           
                        
            return View(pets.ToList());
        }

        [AllowAnonymous]
        // GET: Pet/Details/5
        public ActionResult Details(Guid id)
        {
            PetConsultationsViewModel petConsultationViewModel = new PetConsultationsViewModel();

            PetModel pet = petRepository.GetPetById(id);

            petConsultationViewModel.Name = pet.Name;
            petConsultationViewModel.Race = pet.Race;
            petConsultationViewModel.Species = pet.Species;
            petConsultationViewModel.IdOwner = pet.IdOwner;

            List<ConsultationModel> consultations = consultationRepository.GetConsultationByIdPet(id);

            petConsultationViewModel.consultationList = consultations;
            
            return View("PetDetails", petConsultationViewModel);
        }

        // GET: Pet/Create
        public ActionResult Create()
        {
            return View("CreatePet");
        }

        // POST: Pet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                PetModel petModel = new PetModel();
                UpdateModel(petModel);
                petRepository.InsertPet(petModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreatePet");
            }
        }

        // GET: Pet/Edit/5
        public ActionResult Edit(Guid id)
        {
            PetModel petModel = petRepository.GetPetById(id);
            return View("EditPet", petModel);
        }

        // POST: Pet/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                PetModel petModel = new PetModel();
                UpdateModel(petModel);
                petRepository.UpdatePet(petModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditPet");
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Pet/Delete/5
        public ActionResult Delete(Guid id)
        {
            PetModel petModel = petRepository.GetPetById(id);

            return View("DeletePet", petModel);
        }

        // POST: Pet/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                petRepository.DeletePet(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeletePet");
            }
        }
    }
}
