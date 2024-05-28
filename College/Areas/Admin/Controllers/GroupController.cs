using College.DataAccess.Repository.IRepository;
using College.Models;
using College.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace College.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GroupController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var objGroupList = _unitOfWork.Group.GetAll(includeProperties: "Specialization").ToList();

            return View(objGroupList);
        }

        public IActionResult Upsert(int? id)
        {
            GroupVM groupVM = new()
            {
                SpecializationList = _unitOfWork.Specialization
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Group = new Group()
            };
            if (id == null || id == 0)
            {
                //create
                return View(groupVM);
            }
            else
            {
                //update
                groupVM.Group = _unitOfWork.Group.Get(u => u.Id == id);
                return View(groupVM);
            }

        }
        [HttpPost]
        public IActionResult Upsert(GroupVM groupVM)
        {
            if (ModelState.IsValid)
            {
                

                if (groupVM.Group.Id == 0)
                {
                    _unitOfWork.Group.Add(groupVM.Group);
                }
                else
                {
                    _unitOfWork.Group.Update(groupVM.Group);
                }

                _unitOfWork.Save();
                TempData["success"] = "Продукт успешно создан";
                return RedirectToAction("Index");
            }
            else
            {
                groupVM.SpecializationList = _unitOfWork.Specialization
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(groupVM);
            }


        }


        

        [HttpGet]
        public IActionResult GetALL()
        {
            List<Group> objGrouptList = _unitOfWork.Group.GetAll(includeProperties: "Specialization").ToList();
            return View(objGrouptList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Group? teacherFromDb = _unitOfWork.Group.Get(u => u.Id == id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }
            return View(teacherFromDb);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Group? obj = _unitOfWork.Group.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Group.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Категория успешно удалена";
            return RedirectToAction("Index");


        }


    }
}
