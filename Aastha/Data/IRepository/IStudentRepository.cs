using Aastha.Data.Models;

namespace Aastha.Data.IRepository
{
    public interface IStudentRepository:IRepository<Student>
    {
         void GetTransaction();
    }
}