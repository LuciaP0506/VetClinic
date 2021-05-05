using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetClinic.Models;
using VetClinic.Models.DBObject;

namespace VetClinic.Repository
{
    public class InvoiceRepository
    {
        private DataClasses1DataContext dbContext;

        public InvoiceRepository()
        {
            dbContext = new DataClasses1DataContext();
        }

        public InvoiceRepository(DataClasses1DataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<InvoiceModel> GetAllInvoices()
        {
            List<InvoiceModel> invoiceList = InitializationListCollection();
            foreach(Invoice dbinvoice in dbContext.Invoices)
            {
                AddDbObjectToModelCollection(invoiceList, dbinvoice);
            }
            return invoiceList;
        }

        public List<InvoiceModel> OrderByDescendingParameter(string parameter)
        {
            List<InvoiceModel> invoiceList = InitializationListCollection();
            foreach (Invoice dbinvoice in dbContext.Invoices)
            {
                AddDbObjectToModelCollection(invoiceList, dbinvoice);
            }
            if (parameter == "IdInvoice")
            {
                return invoiceList.OrderByDescending(x => x.IdInvoice).ToList();
            }
            if (parameter == "IdOwner")
            {
                return invoiceList.OrderByDescending(x => x.IdOwner).ToList();
            }
            if (parameter == "EventDate")
            {
                return invoiceList.OrderByDescending(x => x.EventDate).ToList();
            }
            return invoiceList;
        }

        public List<InvoiceModel> OrderByParameter(string parameter)
        {
            List<InvoiceModel> invoiceList = InitializationListCollection();
            foreach (Invoice dbinvoice in dbContext.Invoices)
            {
                AddDbObjectToModelCollection(invoiceList, dbinvoice);
            }

            if (parameter == "IdInvoice")
            {
                return invoiceList.OrderBy(x => x.IdInvoice).ToList();
            }
            if (parameter == "IdOwner")
            {
                return invoiceList.OrderBy(x => x.IdOwner).ToList();
            }
            if (parameter == "EventDate")
            {
                return invoiceList.OrderBy(x => x.EventDate).ToList();
            }
            return invoiceList;
        }

        public InvoiceModel GetInvoiceById(Guid ID)
        {
            var invoice = dbContext.Invoices.FirstOrDefault(x => x.IdInvoice == ID);
            return MapDbObjectToModel(invoice);
        }

        public InvoiceModel GetInvoiceByConsultation(Guid ID)
        {
            var invoice = dbContext.Invoices.FirstOrDefault(x => x.IdConsultation == ID);
            return MapDbObjectToModel(invoice);
        }

        public List<InvoiceModel> GetAllInvoicesbyOwner(Guid ID)
        {
            List<InvoiceModel> invoiceList = InitializationListCollection();
            foreach (Invoice dbinvoice in dbContext.Invoices.Where(x => x.IdOwner == ID))
            {
                AddDbObjectToModelCollection(invoiceList, dbinvoice);
            }
            return invoiceList;
        }

        public void InsertInvoice(InvoiceModel invoice)
        {
            invoice.IdInvoice = Guid.NewGuid();

            dbContext.Invoices.InsertOnSubmit(MapModelToDbObject(invoice));
            dbContext.SubmitChanges();
        }

        public void UpdateInvoice(InvoiceModel invoice)
        {
            Invoice dbInvoice = dbContext.Invoices.FirstOrDefault(x => x.IdInvoice == invoice.IdInvoice);
            if (invoice != null)
            {
                dbInvoice.IdInvoice = invoice.IdInvoice;
                dbInvoice.IdConsultation = invoice.IdConsultation;
                dbInvoice.IdOwner = invoice.IdOwner;
                dbInvoice.Price = invoice.Price;
                dbInvoice.EventDate = invoice.EventDate;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteInvoice(Guid ID)
        {
            Invoice dbInvoice = dbContext.Invoices.FirstOrDefault(x => x.IdInvoice == ID);
            if (dbInvoice != null)
            {
                dbContext.Invoices.DeleteOnSubmit(dbInvoice);
                dbContext.SubmitChanges();
            }
        }
        private List<InvoiceModel> InitializationListCollection()
        {
            return new List<InvoiceModel>();
        }
        private void AddDbObjectToModelCollection(List<InvoiceModel> invoiceList, Invoice dbinvoice)
        {
            invoiceList.Add(MapDbObjectToModel(dbinvoice));
        }
        private InvoiceModel MapDbObjectToModel(Invoice dbinvoice)
        {
            InvoiceModel invoice = new InvoiceModel();

            if(dbinvoice != null)
            {
                invoice.IdInvoice = dbinvoice.IdInvoice;
                invoice.IdConsultation = dbinvoice.IdConsultation;
                invoice.IdOwner = dbinvoice.IdOwner;
                invoice.Price = dbinvoice.Price;
                invoice.EventDate = dbinvoice.EventDate;
                return invoice;
            }
            return null;
        }

        private Invoice MapModelToDbObject(InvoiceModel invoice)
        {
            Invoice dbInvoice = new Invoice();

            if(invoice != null)
            {
                dbInvoice.IdInvoice = invoice.IdInvoice;
                dbInvoice.IdConsultation = invoice.IdConsultation;
                dbInvoice.IdOwner = invoice.IdOwner;
                dbInvoice.Price = invoice.Price;
                dbInvoice.EventDate = invoice.EventDate;
                return dbInvoice;
            }
            return null;
        }
    }
}