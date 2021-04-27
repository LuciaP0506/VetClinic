using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetClinic.Models
{
    public class VetModel
    {
        public Guid IdVet { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Specialization { get; set; }

        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Phone { get; set; }

        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Email { get; set; }

    }
}