using EfCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    public class CourseRegController : Controller
    {
        private readonly DataContext _dataContext;

        public CourseRegController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.CourseRegisters.Include(x=>x.Student).Include(z=>z.Course).ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(await _dataContext.Students.ToListAsync(), "StudentId", "NameSurname");
            ViewBag.Courses = new SelectList(await _dataContext.Courses.ToListAsync(), "CourseId", "CourseName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseRegister model)
        {
            model.RegDate = DateTime.Now;
            _dataContext.CourseRegisters.Add(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
