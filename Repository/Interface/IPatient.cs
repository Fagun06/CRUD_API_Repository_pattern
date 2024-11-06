using CRUD_API_Repo.Models;

namespace CRUD_API_Repo.Repository.Interface
{
    public interface IPatient : IDisposable
    {
        IEnumerable<Patient> GetAll();

        Patient GetPatientById(int id);

        int CreatePatient(Patient patient);

        int UpdatePatient(Patient patient);

        int DeletePatient(int id);
    }
}
