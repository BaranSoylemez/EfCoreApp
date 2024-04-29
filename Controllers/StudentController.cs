using EfCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _dataContext;
        public StudentController(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Students.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student model)
        {
            _dataContext.Students.Add(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _dataContext.Students.Include(x=>x.CourseRegisters).ThenInclude(m=>m.Course).FirstOrDefaultAsync(x=>x.StudentId == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student model)
        {
            _dataContext.Students.Update(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return View(await _dataContext.Students.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int StudentId)
        {
            var tobedeleted = await _dataContext.Students.FindAsync(StudentId);
            _dataContext.Students.Remove(tobedeleted);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}
