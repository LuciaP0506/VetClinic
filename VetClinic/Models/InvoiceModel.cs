using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetClinic.Models
{
    public class InvoiceModel
    {
        public Guid IdInvoice { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IdConsultation { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IdOwner { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime EventDate { get; set; }
    }
}