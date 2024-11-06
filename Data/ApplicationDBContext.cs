using CRUD_API_Repo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CRUD_API_Repo.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions <ApplicationDBContext> options) : base(options) 
        {
        
        }
        public virtual DbSet<Patient> patients {  get; set; }
    }
}
