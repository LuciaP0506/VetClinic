using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetClinic.Models;
using VetClinic.Models.DBObject;

namespace VetClinic.Repository
{
    public class PetRepository
    {
        private DataClasses1DataContext dbContext;

        public PetRepository()
        {
            dbContext = new DataClasses1DataContext();
        }

        public PetRepository(DataClasses1DataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<PetModel> GetAllPets()
        {
            List<PetModel> petList = InitializePetCollection();
            foreach(Pet dbPet in dbContext.Pets)
            {
                AddDbObjectToModelCollection(petList, dbPet);
            }
            return petList;
        }

        public List<PetModel> OrderByParameter( string parameter)
        {
            List<PetModel> petList = InitializePetCollection();
            foreach (Pet dbPet in dbContext.Pets)
            {
                AddDbObjectToModelCollection(petList, dbPet);
            }

            if (parameter == "Name")
            {
                return petList.OrderBy(x => x.Name).ToList();
            }
            if (parameter == "Species")
            {
                return petList.OrderBy(x => x.Species).ToList();
            }
            if (parameter == "Race")
            {
                return petList.OrderBy(x => x.Race).ToList();
            }
            return petList;
        }

        public List<PetModel> OrderByDescendingParameter(string parameter)
        {
            List<PetModel> petList = InitializePetCollection();
            foreach (Pet dbPet in dbContext.Pets)
            {
                AddDbObjectToModelCollection(petList, dbPet);
            }

            if (parameter == "Name")
            {
                return petList.OrderByDescending(x => x.Name).ToList();
            }
            if (parameter == "Species")
            {
                return petList.OrderByDescending(x => x.Species).ToList();
            }
            if (parameter == "Race")
            {
                return petList.OrderByDescending(x => x.Race).ToList();
            }
            return petList;
        }


        public PetModel GetPetById(Guid ID)
        {
            var pet = dbContext.Pets.FirstOrDefault(x => x.IdPet == ID);

            return MapDbObjectToModel(pet);
        }

        public PetModel GetPetByName(string name)
        {
            var pet = dbContext.Pets.FirstOrDefault(x => x.Name == name);

            return MapDbObjectToModel(pet);
        }

        public List<PetModel> GetPetsBySpecies(string species)
        {
            List<PetModel> petList = InitializePetCollection();
            foreach (Pet dbPet in dbContext.Pets.Where(x => x.Species == species))
            {
                AddDbObjectToModelCollection(petList, dbPet);
            }
            return petList;
        }
        public List<PetModel> GetPetsByRace(string race)
        {
            List<PetModel> petList = InitializePetCollection();
            foreach (Pet dbPet in dbContext.Pets.Where(x => x.Race == race))
            {
                AddDbObjectToModelCollection(petList, dbPet);
            }
            return petList;
        }              
        
        public List<PetModel> GetPetsByOwner(Guid ID)
        {
            List<PetModel> petList = InitializePetCollection();
            foreach (Pet dbPet in dbContext.Pets.Where(x => x.IdOwner == ID))
            {
                AddDbObjectToModelCollection(petList, dbPet);
            }
            return petList;
        }

        public void InsertPet(PetModel pet)
        {
            pet.IdPet = Guid.NewGuid();

            dbContext.Pets.InsertOnSubmit(MapModelToDbObject(pet));
            dbContext.SubmitChanges();
        }

        public void UpdatePet(PetModel pet)
        {
            Pet dbPet = dbContext.Pets.FirstOrDefault(x => x.IdPet == pet.IdPet);
            if(pet != null)
            {
                dbPet.IdPet = pet.IdPet;
                dbPet.Name = pet.Name;
                dbPet.Species = pet.Species;
                dbPet.Race = pet.Race;
                dbPet.IdOwner = pet.IdOwner;
                dbContext.SubmitChanges();
            }
        }

        public void DeletePet(Guid ID)
        {
            Pet dbPet = dbContext.Pets.FirstOrDefault(x => x.IdPet == ID);
            if(dbPet != null)
            {
                dbContext.Pets.DeleteOnSubmit(dbPet);
                dbContext.SubmitChanges();
            }
        }
        private List<PetModel> InitializePetCollection()
        {
            return new List<PetModel>();
        }

        private void AddDbObjectToModelCollection(List<PetModel> petList, Pet dbPet)
        {
            petList.Add(MapDbObjectToModel(dbPet));
        }

        private PetModel MapDbObjectToModel(Pet dbpet)
        {
            PetModel pet = new PetModel();

            if(dbpet != null)
            {
                pet.IdPet = dbpet.IdPet;
                pet.Name = dbpet.Name;
                pet.Species = dbpet.Species;
                pet.Race = dbpet.Race;
                pet.IdOwner = dbpet.IdOwner;
                return pet;
            }
            return null;
        }

        private Pet MapModelToDbObject(PetModel pet)
        {
            Pet dbPet = new Pet();

            if(pet != null)
            {
                dbPet.IdPet = pet.IdPet;
                dbPet.Name = pet.Name;
                dbPet.Species = pet.Species;
                dbPet.Race = pet.Race;
                dbPet.IdOwner = pet.IdOwner;
                return dbPet;
            }
            return null;
        }
    }
}