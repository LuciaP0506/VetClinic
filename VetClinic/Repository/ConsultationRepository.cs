using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetClinic.Models;
using VetClinic.Models.DBObject;

namespace VetClinic.Repository
{
    public class ConsultationRepository
    {
        private DataClasses1DataContext dbContext;

        public ConsultationRepository()
        {
            dbContext = new DataClasses1DataContext();
        }

        public ConsultationRepository(DataClasses1DataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<ConsultationModel> GetAllConsultations()
        {
            List<ConsultationModel> consultationsList = InitializeConsultationCollection();
            foreach (Consultation dbConsultation in dbContext.Consultations)
            {
                AddDbObjectToModelCollection(consultationsList, dbConsultation);
            }
            return consultationsList;
        }

        public List<ConsultationModel> OrderByDescendingParameter(string parameter)
        {
            List<ConsultationModel> consultationsList = InitializeConsultationCollection();
            foreach (Consultation dbConsultation in dbContext.Consultations)
            {
                AddDbObjectToModelCollection(consultationsList, dbConsultation);
            }
            if (parameter == "IdPet")
            {
                return consultationsList.OrderByDescending(x => x.IdPet).ToList();
            }
            if (parameter == "EventDate")
            {
                return consultationsList.OrderByDescending(x => x.EventDate).ToList();
            }
            return consultationsList;
        }

        public List<ConsultationModel> OrderByParameter(string parameter)
        {
            List<ConsultationModel> consultationsList = InitializeConsultationCollection();
            foreach (Consultation dbConsultation in dbContext.Consultations)
            {
                AddDbObjectToModelCollection(consultationsList, dbConsultation);
            }
            if (parameter == "IdPet")
            {
                return consultationsList.OrderBy(x => x.IdPet).ToList();
            }
            if (parameter == "EventDate")
            {
                return consultationsList.OrderBy(x => x.EventDate).ToList();
            }
            return consultationsList;
        }

        public ConsultationModel GetConsultationById(Guid ID)
        {
            var consultation = dbContext.Consultations.FirstOrDefault(x => x.IdConsultation == ID);
            return MapDbObjectToModel(consultation);
        }
        public List<ConsultationModel> GetConsultationByIdVet(Guid ID)
        {
            List<ConsultationModel> consultationsList = InitializeConsultationCollection();
            foreach (Consultation dbConsultation in dbContext.Consultations.Where(x => x.IdVet == ID))
            {
                AddDbObjectToModelCollection(consultationsList, dbConsultation);
            }
            return consultationsList;
        }
        public List<ConsultationModel> GetConsultationByIdPet(Guid ID)
        {
            List<ConsultationModel> consultationsList = InitializeConsultationCollection();
            foreach (Consultation dbConsultation in dbContext.Consultations.Where(x => x.IdPet == ID))
            {
                AddDbObjectToModelCollection(consultationsList, dbConsultation);
            }
            return consultationsList;
        }

        public void InsertConsultation(ConsultationModel consultation)
        {
            consultation.IdConsultation = Guid.NewGuid();

            dbContext.Consultations.InsertOnSubmit(MapModelToDbObject(consultation));
            dbContext.SubmitChanges();
        }

        public void UpdateConsultation(ConsultationModel consultation)
        {
            Consultation dbConsultation = dbContext.Consultations.FirstOrDefault(x => x.IdConsultation == consultation.IdConsultation);
            if (consultation != null)
            {
                dbConsultation.IdConsultation = consultation.IdConsultation;
                dbConsultation.IdVet = consultation.IdVet;
                dbConsultation.IdPet = consultation.IdPet;
                dbConsultation.Description = consultation.Description;
                dbConsultation.Recomandation = consultation.Recomandation;
                dbConsultation.EventDate = consultation.EventDate;
                dbConsultation.IdOwner = consultation.IdOwner;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteConsultation(Guid ID)
        {
            Consultation dbConsultation = dbContext.Consultations.FirstOrDefault(x => x.IdConsultation == ID);
            if (dbConsultation != null)
            {
                dbContext.Consultations.DeleteOnSubmit(dbConsultation);
                dbContext.SubmitChanges();
            }
        }

        private List<ConsultationModel> InitializeConsultationCollection()
        {
            return new List<ConsultationModel>();
        }

        private void AddDbObjectToModelCollection(List<ConsultationModel> consultationsList, Consultation dbConsultation)
        {
            consultationsList.Add(MapDbObjectToModel(dbConsultation));
        }

        private ConsultationModel MapDbObjectToModel(Consultation dbConsultation)
        {
            ConsultationModel consultation = new ConsultationModel();

            if (dbConsultation != null)
            {
                consultation.IdConsultation = dbConsultation.IdConsultation;
                consultation.IdVet = dbConsultation.IdVet;
                consultation.IdPet = dbConsultation.IdPet;
                consultation.Description = dbConsultation.Description;
                consultation.Recomandation = dbConsultation.Recomandation;
                consultation.EventDate = dbConsultation.EventDate;
                consultation.IdOwner = dbConsultation.IdOwner;
                return consultation;
            }
            return null;
        }

        private Consultation MapModelToDbObject(ConsultationModel consultation)
        {
            Consultation dbConsultation = new Consultation();

            if (consultation != null)
            {
                dbConsultation.IdConsultation = consultation.IdConsultation;
                dbConsultation.IdVet = consultation.IdVet;
                dbConsultation.IdPet = consultation.IdPet;
                dbConsultation.Description = consultation.Description;
                dbConsultation.Recomandation = consultation.Recomandation;
                dbConsultation.EventDate = consultation.EventDate;
                dbConsultation.IdOwner = consultation.IdOwner;
                return dbConsultation;
            }
            return null;
        }
    }
}