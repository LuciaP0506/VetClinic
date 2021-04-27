using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetClinic.Models
{
    public class PetModel
    {
        public Guid IdPet { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Species { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Race { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IdOwner { get; set; }

    }
}