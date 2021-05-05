using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetClinic.Models;
using VetClinic.Models.DBObject;

namespace VetClinic.Repository
{
    public class OwnerRepository
    {
        private DataClasses1DataContext dbContext;

        public OwnerRepository()
        {
            dbContext = new DataClasses1DataContext();
        }

        public OwnerRepository(DataClasses1DataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<OwnerModel> GetAllOwners()
        {
            List<OwnerModel> ownerList = InitializationOwnerCollection();
            foreach(Owner dbOwner in dbContext.Owners)
            {
                AddDbObjectToModelCollection(ownerList, dbOwner);
            }
            return ownerList;
        }

        public List<OwnerModel> OrderByDescendingParameter(string parameter)
        {
            List<OwnerModel> ownerList = InitializationOwnerCollection();
            foreach(Owner dbowner in dbContext.Owners)
            {
                AddDbObjectToModelCollection(ownerList, dbowner);
            }
            if(parameter == "FirstName")
            {
                return ownerList.OrderByDescending(x => x.FirstName).ToList();
            }
            if (parameter == "LastName")
            {
                return ownerList.OrderByDescending(x => x.LastName).ToList();
            }
            return ownerList;
        }

        public List<OwnerModel> OrderByParameter(string parameter)
        {
            List<OwnerModel> ownerList = InitializationOwnerCollection();
            foreach (Owner dbowner in dbContext.Owners)
            {
                AddDbObjectToModelCollection(ownerList, dbowner);
            }

            if (parameter == "FirstName")
            {
                return ownerList.OrderBy(x => x.FirstName).ToList();
            }
            if (parameter == "LastName")
            {
                return ownerList.OrderBy(x => x.LastName).ToList();
            }
            return ownerList;
        }

        public List<OwnerModel> SearchString(string parameter)
        {
            List<OwnerModel> ownerList = InitializationOwnerCollection();
            foreach (Owner dbowner in dbContext.Owners)
            {
                AddDbObjectToModelCollection(ownerList, dbowner);
            }
            if (parameter != null)
            {
                return ownerList.Where(p => p.FirstName.Contains(parameter) || p.LastName.Contains(parameter)).ToList();
            }
            return ownerList;
        }
        public OwnerModel GetOwnerById(Guid ID)
        {
            var owner = dbContext.Owners.FirstOrDefault(x => x.IdOwner == ID);
            return MapDbObjectToModel(owner);
        }

        public OwnerModel GetOwnerByName(string name)
        {
            var owner = dbContext.Owners.FirstOrDefault(x => x.FirstName == name || x.LastName == name);
            return MapDbObjectToModel(owner);
        }

        public void InsertOwner(OwnerModel owner)
        {
            owner.IdOwner = Guid.NewGuid();

            dbContext.Owners.InsertOnSubmit(MapModelToDbObject(owner));
            dbContext.SubmitChanges();
        }

        public void UpdateOwner(OwnerModel owner)
        {
            Owner dbOwner = dbContext.Owners.FirstOrDefault(x => x.IdOwner == owner.IdOwner);
            if(owner != null)
            {
                dbOwner.IdOwner = owner.IdOwner;
                dbOwner.FirstName = owner.FirstName;
                dbOwner.LastName = owner.LastName;
                dbOwner.Phone = owner.Phone;
                dbOwner.Email = owner.Email;
                dbOwner.Address = owner.Address;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteOwner(Guid ID)
        {
            Owner dbOwner = dbContext.Owners.FirstOrDefault(x => x.IdOwner == ID);
            if (dbOwner != null)
            {
                dbContext.Owners.DeleteOnSubmit(dbOwner);
                dbContext.SubmitChanges();
            }
        }

        private List<OwnerModel> InitializationOwnerCollection()
        {
            return new List<OwnerModel>();
        }

        private void AddDbObjectToModelCollection(List<OwnerModel> ownerList, Owner dbOwner)
        {
            ownerList.Add(MapDbObjectToModel(dbOwner));
        }
        private OwnerModel MapDbObjectToModel(Owner dbowner)
        {
            OwnerModel owner = new OwnerModel();

            if(dbowner != null)
            {
                owner.IdOwner = dbowner.IdOwner;
                owner.FirstName = dbowner.FirstName;
                owner.LastName = dbowner.LastName;
                owner.Phone = dbowner.Phone;
                owner.Email = dbowner.Email;
                owner.Address = dbowner.Address;
                return owner;
            }
            return null;
        }

        private Owner MapModelToDbObject(OwnerModel owner)
        {
            Owner dbOwner = new Owner();
            
            if(owner != null)
            {
                dbOwner.IdOwner = owner.IdOwner;
                dbOwner.FirstName = owner.FirstName;
                dbOwner.LastName = owner.LastName;
                dbOwner.Phone = owner.Phone;
                dbOwner.Email = owner.Email;
                dbOwner.Address = owner.Address;
                return dbOwner;
            }
            return null;
        }    

    }
}