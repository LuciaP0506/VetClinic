using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetClinic.Models;
using VetClinic.Models.DBObject;

namespace VetClinic.Repository
{
    public class VetRepository
    {
        private DataClasses1DataContext dbContext;

        public VetRepository()
        {
            dbContext = new DataClasses1DataContext();
        }

        public VetRepository(DataClasses1DataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<VetModel> GetAllVets()
        {
            List<VetModel> vetList = InitializeVetCollection();
            foreach(Vet dbVet in dbContext.Vets)
            {
                AddDbObjectToModelCollection(vetList, dbVet);
            }
            return vetList;
        }       

        public VetModel GetVetById(Guid ID)
        {
            var vet = dbContext.Vets.FirstOrDefault(x => x.IdVet == ID);
            return MapDbObjectToModel(vet);
        }

        public VetModel GetVetByName(string name)
        {
            var vet = dbContext.Vets.FirstOrDefault(x => x.FirstName == name || x.LastName == name);
            return MapDbObjectToModel(vet);
        }

        public List<VetModel> GetVetsBySpecialization(string specialization)
        {
            List<VetModel> vetList = InitializeVetCollection();
            foreach(Vet dbVet in dbContext.Vets)
            {
                AddDbObjectToModelCollection(vetList, dbVet);
            }
            return vetList;
        }

        public void InsertVet(VetModel vet)
        {
            vet.IdVet = Guid.NewGuid();

            dbContext.Vets.InsertOnSubmit(MapModelToDbObject(vet));
            dbContext.SubmitChanges();
        }

        public void UpdateVet(VetModel vet)
        {
            Vet dbVet = dbContext.Vets.FirstOrDefault(x => x.IdVet == vet.IdVet);
            if(vet != null)
            {
                dbVet.IdVet = vet.IdVet;
                dbVet.FirstName = vet.FirstName;
                dbVet.LastName = vet.LastName;
                dbVet.Specialization = vet.Specialization;
                dbVet.Phone = vet.Phone;
                dbVet.Email = vet.Email;
                dbContext.SubmitChanges();               
            }
        }

        public void DeleteVet(Guid ID)
        {
            Vet dbVet = dbContext.Vets.FirstOrDefault(x => x.IdVet == ID);
            if(dbVet != null)
            {
                dbContext.Vets.DeleteOnSubmit(dbVet);
                dbContext.SubmitChanges();
            }
        }

        private List<VetModel> InitializeVetCollection()
        {
            return new List<VetModel>();
        }

        private void AddDbObjectToModelCollection(List<VetModel> vetList, Vet dbVet)
        {
            vetList.Add(MapDbObjectToModel(dbVet));
        }

        private VetModel MapDbObjectToModel(Vet dbVet)
        {
            VetModel vet = new VetModel();

            if(dbVet != null)
            {
                vet.IdVet = dbVet.IdVet;
                vet.FirstName = dbVet.FirstName;
                vet.LastName = dbVet.LastName;
                vet.Specialization = dbVet.Specialization;
                vet.Phone = dbVet.Phone;
                vet.Email = dbVet.Email;
                return vet;
            }
            return null;
        }

        private Vet MapModelToDbObject(VetModel vet)
        {
            Vet dbVet = new Vet();

            if(vet != null)
            {
                dbVet.IdVet = vet.IdVet;
                dbVet.FirstName = vet.FirstName;
                dbVet.LastName = vet.LastName;
                dbVet.Specialization = vet.Specialization;
                dbVet.Phone = vet.Phone;
                dbVet.Email = vet.Email;
                return dbVet;
            }
            return null;
        }

    }
}