using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Repositories;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoRepository _repository;

        public ToDoController(ToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _repository.GetAllAsync();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoItem item)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public async Task<IActionResult> ToggleComplete(string id)
        {
            await _repository.ToggleCompleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
