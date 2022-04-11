using System.Threading.Tasks;
using Aastha.Data;
using Aastha.Data.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aastha.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _repository;
        private readonly AasthaContext _context;

        public StudentController(AasthaContext context, IStudentRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        [Route("student")]
        public IActionResult Index()
        {
            var students = _repository.GetAll();
            return View(students);
        }

        [Route("student/list")]
        public IActionResult List()
        {
            var transactions = _context.Student_Master
                .FromSqlRaw("Select * from Student_Master");
            return View(transactions);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Student_Master.Find(id);
            return View(student);
        }
    }
}