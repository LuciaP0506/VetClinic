using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models;
using VetClinic.Repository;

namespace VetClinic.Controllers
{
    public class InvoiceController : Controller
    {
        private InvoiceRepository invoiceRepository = new InvoiceRepository();
        // GET: Invoice
        public ActionResult Index(string sortOrder)
        {
            ViewBag.IdInvoiceSortParam = string.IsNullOrEmpty(sortOrder) ? "idInvoice_desc" : "";
            ViewBag.IdOwnerSortParam = sortOrder == "idOwner" ? "idOwner_desc" : "idOwner";
            ViewBag.EventDateSortParam = sortOrder == "eventDate" ? "eventDate_desc" : "eventDate";

            var invoices = from i in invoiceRepository.GetAllInvoices() select i;

            switch (sortOrder)
            {
                case "idInvoice_desc":
                    invoices = invoiceRepository.OrderByDescendingParameter("IdInvoice");
                    break;
                case "idOwner_desc":
                    invoices = invoiceRepository.OrderByDescendingParameter("IdOwner");
                    break;
                case "idOwner":
                    invoices = invoiceRepository.OrderByParameter("IdOwner");
                    break;
                case "eventDate_desc":
                    invoices = invoiceRepository.OrderByDescendingParameter("EventDate");
                    break;
                case "eventDate":
                    invoices = invoiceRepository.OrderByParameter("EventDate");
                    break;
                default:
                    invoices = invoiceRepository.OrderByParameter("IdInvoice");
                    break;
            }

            return View(invoices.ToList());
        }

        // GET: Invoice/Details/5
        public ActionResult Details(Guid id)
        {
            InvoiceModel invoiceModel = invoiceRepository.GetInvoiceById(id);
            return View("InvoiceDetails", invoiceModel);
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            return View("CreateInvoice");
        }

        // POST: Invoice/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                InvoiceModel invoiceModel = new InvoiceModel();
                UpdateModel(invoiceModel);
                invoiceRepository.InsertInvoice(invoiceModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateInvoice");
            }
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(Guid id)
        {
            InvoiceModel invoiceModel = invoiceRepository.GetInvoiceById(id);
            return View("EditInvoice", invoiceModel);
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                InvoiceModel invoiceModel = new InvoiceModel();
                UpdateModel(invoiceModel);
                invoiceRepository.UpdateInvoice(invoiceModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditInvoice");
            }
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(Guid id)
        {
            InvoiceModel invoiceModel = invoiceRepository.GetInvoiceById(id);

            return View("DeleteInvoice", invoiceModel);
        }

        // POST: Invoice/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                invoiceRepository.DeleteInvoice(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteInvoice");
            }
        }
    }
}
