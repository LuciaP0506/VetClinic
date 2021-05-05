using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetClinic.Models
{
    public class DropDownOwnerPet
    {
        public List<OwnerModel> ownerList = new List<OwnerModel>();

        public Guid IdPet { get; set; }

        public string FirstName { get; set; }

        public string Name { get; set; }
  
        public string Species { get; set; }
  
        public string Race { get; set; }

        public Guid IdOwner { get; set; }
    }
}