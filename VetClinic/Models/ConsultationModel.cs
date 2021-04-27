using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetClinic.Models
{
    public class ConsultationModel
    {
        public Guid IdConsultation { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IdVet { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IdPet { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public string Recomandation { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime EventDate { get; set; }

    }
}