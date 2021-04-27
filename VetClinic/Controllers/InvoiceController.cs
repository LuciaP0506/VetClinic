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
        public ActionResult Index()
        {
            List<InvoiceModel> invoices = invoiceRepository.GetAllInvoices();
            return View("Index", invoices);
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
