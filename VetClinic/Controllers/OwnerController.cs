﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models;
using VetClinic.Repository;

namespace VetClinic.Controllers
{
    public class OwnerController : Controller
    {
        private OwnerRepository ownerRepository = new OwnerRepository();
        // GET: Owner
        public ActionResult Index()
        {
            List<OwnerModel> owners = ownerRepository.GetAllOwners();
            return View("Index", owners);
        }

        // GET: Owner/Details/5
        public ActionResult Details(Guid id)
        {
            OwnerModel ownerModel = ownerRepository.GetOwnerById(id);
            return View("OwnerDetails", ownerModel);
        }

        // GET: Owner/Create
        public ActionResult Create()
        {
            return View("CreateOwner");
        }

        // POST: Owner/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                OwnerModel ownerModel = new OwnerModel();
                UpdateModel(ownerModel);
                ownerRepository.InsertOwner(ownerModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateOwner");
            }
        }

        // GET: Owner/Edit/5
        public ActionResult Edit(Guid id)
        {
            OwnerModel ownerModel = ownerRepository.GetOwnerById(id);
            return View("EditOwner", ownerModel);
        }

        // POST: Owner/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                OwnerModel ownerModel = new OwnerModel();
                UpdateModel(ownerModel);
                ownerRepository.UpdateOwner(ownerModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditOwner");
            }
        }

        // GET: Owner/Delete/5
        public ActionResult Delete(Guid id)
        {
            OwnerModel ownerModel = ownerRepository.GetOwnerById(id);
            return View("DeleteOwner", ownerModel);
        }

        // POST: Owner/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                ownerRepository.DeleteOwner(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteOwner");
            }
        }
    }
}
