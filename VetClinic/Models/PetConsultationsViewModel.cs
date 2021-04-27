using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetClinic.Models
{
    public class PetConsultationsViewModel
    {
        public List<ConsultationModel> consultationList = new List<ConsultationModel>();
  
        public string Name { get; set; }

        public string Species { get; set; }

        public string Race { get; set; }

        public Guid IdOwner { get; set; }
    }
}