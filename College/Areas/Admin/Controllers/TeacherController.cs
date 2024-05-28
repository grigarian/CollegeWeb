using College.DataAccess.Repository.IRepository;
using College.Models;
using College.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace College.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeacherController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var objTeacherList = _unitOfWork.Teacher.GetAll().ToList();
            return View(objTeacherList);
        }
        public IActionResult Upsert(int? id)
        {
            TeacherVM teacherVM = new()
            {
                Teacher = new Teacher()
            };
            if (id == null || id == 0)
            {
                //create
                return View(teacherVM);
            }
            else
            {
                //update
                teacherVM.Teacher = _unitOfWork.Teacher.Get(u => u.Id == id);
                return View(teacherVM);
            }

            

        }
       
        [HttpPost]
        public IActionResult Upsert(TeacherVM teacherVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPatch = Path.Combine(wwwRootPath, @"images/teacher");

                    if (!string.IsNullOrEmpty(teacherVM.Teacher.ImageUrl))
                    {
                        //delete old file
                        var oldImagePath =
                            Path.Combine(wwwRootPath, teacherVM.Teacher.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPatch, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    teacherVM.Teacher.ImageUrl = @"\images\teacher\" + fileName;
                }

                if (teacherVM.Teacher.Id == 0)
                {
                    _unitOfWork.Teacher.Add(teacherVM.Teacher);
                }
                else
                {
                    _unitOfWork.Teacher.Update(teacherVM.Teacher);
                }

                _unitOfWork.Save();
                TempData["success"] = "Преподаватель успешно добавлен";
                return RedirectToAction("Index");
            }
            else
            {
                
                return View(teacherVM);
            }


        }


        [HttpGet]
        public IActionResult GetALL()
        {
            List<Teacher> objTeacherList = _unitOfWork.Teacher.GetAll().ToList();
            return View(objTeacherList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Teacher? teacherFromDb = _unitOfWork.Teacher.Get(u => u.Id == id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }
            return View(teacherFromDb);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Teacher? obj = _unitOfWork.Teacher.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Teacher.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Категория успешно удалена";
            return RedirectToAction("Index");


        }
    }


}

