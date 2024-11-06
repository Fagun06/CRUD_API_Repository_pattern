using CRUD_API_Repo.Models;
using CRUD_API_Repo.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API_Repo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatient _patientrepo;

        public PatientController(IPatient ptnt)
        {
            _patientrepo = ptnt;
        }
        [HttpGet]
        public IActionResult index()
        {
            var result = _patientrepo.GetAll();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            Patient result = _patientrepo.GetPatientById(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]

        public IActionResult Creates(Patient patient) 
        { 
            int result = _patientrepo.CreatePatient(patient);

            if(result <= 0)
            {
                return BadRequest("Failed");
            }   
            else
            {
                return Ok("Add" + result);
            }
           
        }
        [HttpPut]

        public IActionResult Edit(Patient patient)
        {
            int result = _patientrepo.UpdatePatient(patient);

            if (result <= 0)
            {
                return BadRequest("Failed");
            }
            else
            {
                return Ok("Edit" + result);
            }

        }

        [HttpDelete]     
        public IActionResult Delete(int id)
        {
            int result = _patientrepo.DeletePatient(id);

            if (result <= 0)
            {
                return BadRequest("Failed");
            }
            else
            {
                return Ok("Deleted" + result);
            }

        }
    }
}
