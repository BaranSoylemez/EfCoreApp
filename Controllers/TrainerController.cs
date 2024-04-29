using EfCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    public class TrainerController : Controller
    {
        private readonly DataContext _dataContext;
        public TrainerController(DataContext datacontext)
        {
            _dataContext = datacontext;   
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Trainers.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trainer model)
        {
            _dataContext.Trainers.Add(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _dataContext.Trainers.Include(x=>x.Courses).FirstOrDefaultAsync(x=>x.TrainerId==id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Trainer model)
        {
            _dataContext.Trainers.Update(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
