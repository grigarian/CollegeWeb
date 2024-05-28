using College.DataAccess.Repository.IRepository;
using College.Models;
using College.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace College.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecializationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SpecializationController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var objSpecList = _unitOfWork.Specialization.GetAll().ToList();
            return View(objSpecList);
        }
        public IActionResult Upsert(Specialization obj)
        {
            
            if (obj.Id == null || obj.Id == 0)
            {
                //create
                return View(obj);
            }
            else
            {
                //update
                obj = _unitOfWork.Specialization.Get(u => u.Id == obj.Id);
                return View(obj);
            }



        }

        [HttpPost]
        public IActionResult Upsert(int? id, Specialization obj)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _unitOfWork.Specialization.Add(obj);
                }
                else
                {
                    _unitOfWork.Specialization.Update(obj);
                }

                _unitOfWork.Save();
                TempData["success"] = "Преподаватель успешно добавлен";
                return RedirectToAction("Index");
            }
            else
            {

                return View(obj);
            }

        }


        [HttpGet]
        public IActionResult GetALL()
        {
            List<Specialization> objSpecList = _unitOfWork.Specialization.GetAll().ToList();
            return View(objSpecList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Specialization? specFromDb = _unitOfWork.Specialization.Get(u => u.Id == id);

            if (specFromDb == null)
            {
                return NotFound();
            }
            return View(specFromDb);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Specialization? obj = _unitOfWork.Specialization.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Specialization.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Категория успешно удалена";
            return RedirectToAction("Index");


        }
    }
}
