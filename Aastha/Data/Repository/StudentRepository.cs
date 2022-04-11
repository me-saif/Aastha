using Aastha.Data.IRepository;
using Aastha.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Aastha.Data.Repository
{
    public class StudentRepository:  Repository<Student>,IStudentRepository
    {
        public StudentRepository(AasthaContext context):base(context) { }

        public void GetTransaction(){
            var transaction = _context.Student_Master.FromSqlRaw("Select * from vw_StudentFeeCollection");
        }
    }
}