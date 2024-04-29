using EfCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _dataContext;

        public CourseController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Courses.Include(x=>x.Trainer).ToListAsync());
        }

        public  async Task<IActionResult> Create()
        {
            ViewBag.Trainers= new SelectList(await _dataContext.Trainers.ToListAsync(), "TrainerId", "Namesurname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course model)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Courses.Add(model);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Trainers = new SelectList(await _dataContext.Trainers.ToListAsync(), "TrainerId", "Namesurname");
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Trainers = new SelectList(await _dataContext.Trainers.ToListAsync(), "TrainerId", "Namesurname");
            return View(await _dataContext.Courses.Include(a=>a.Trainer).Include(m=>m.CourseRegisters).ThenInclude(z=>z.Student).FirstOrDefaultAsync(x=>x.CourseId==id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Course model)
        {
            _dataContext.Courses.Update(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return View(await _dataContext.Courses.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int CourseId)
        {
            var tobedeleted = await _dataContext.Courses.FindAsync(CourseId);
            _dataContext.Courses.Remove(tobedeleted);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
