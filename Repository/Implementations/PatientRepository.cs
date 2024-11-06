using CRUD_API_Repo.Data;
using CRUD_API_Repo.Models;
using CRUD_API_Repo.Repository.Interface;

namespace CRUD_API_Repo.Repository.Implementations
{
    public class PatientRepository : IPatient
    {
        private readonly ApplicationDBContext _Context;

        public PatientRepository (ApplicationDBContext Context)
        {
            _Context = Context;
        }
        public IEnumerable<Patient> GetAll()
        {
            var result = _Context.patients.ToList();
            return result;
        }
        public Patient GetPatientById(int id)
        {
            var result = _Context.patients.Where(x=>x.Id==id).FirstOrDefault()??null;
            return result;
        }
        public int CreatePatient(Patient patient)
        {
            int result = 0;
            if(patient == null)
            {
                result = 0;
            }
            else
            {
                _Context.patients.Add(patient);
                _Context.SaveChanges();
                result = patient.Id;
            }
            return result;
        }

        public int UpdatePatient(Patient patient)
        {
            var result = _Context.patients.Where(x => x.Id == patient.Id).FirstOrDefault() ?? null;
            if(result != null)
            {
                result.Id = patient.Id;
                result.Name = patient.Name;
                result.Description = patient.Description;
                result.Age = patient.Age;
                _Context.SaveChanges(); 
                return result.Id;
            }
            return -1;
        }

        public int DeletePatient(int id)
        {
            if(id == 0)
            {
                return 0;
            }
            else
            {
                var res = _Context.patients.Where(x=>x.Id == id).FirstOrDefault();
                if(res != null)
                {
                    _Context.patients.Remove(res);
                    _Context.SaveChanges();
                    return res.Id;
                }
                return 0;
            }
        }

        public void Dispose()
        {
           _Context?.Dispose();
        }
       
    }
}
