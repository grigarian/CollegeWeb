using College.DataAccess.Repository.IRepository;
using College.Models;
using College.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace College.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TeacherController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Teacher> teacherList = _unitOfWork.Teacher.GetAll();
            return View(teacherList);
        }
        public IActionResult Details(int teacherId)
        {
            TeacherVM teacherVM = new TeacherVM();
            teacherVM.Teacher = _unitOfWork.Teacher.Get(u => u.Id == teacherId);
            return View(teacherVM);
        }
       
    }
}
