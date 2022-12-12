using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskManagerDbContext context;

        public TaskController(TaskManagerDbContext context) => this.context = context;

        public IActionResult Index() => View(context.Tasks.ToList());

        public IActionResult Daily() => View(context.Tasks.ToList());

        public IActionResult Outdated() => View(context.Tasks.ToList());

        public IActionResult SortByName() => View("Index", context.Tasks.ToList().OrderBy(task => task.Name));
        public IActionResult SortByDeadline() => View("Index", context.Tasks.ToList().OrderBy(task => task.Deadline));
        public IActionResult SortByPriority() => View("Index", context.Tasks.ToList().OrderBy(task => task.Priority));

        public IActionResult SortByNameOutdated() => View("Outdated", context.Tasks.ToList().OrderBy(task => task.Name).Where(task => task.Deadline < DateTime.Today));
        public IActionResult SortByDeadlineOutdated() => View("Outdated", context.Tasks.ToList().OrderBy(task => task.Deadline).Where(task => task.Deadline < DateTime.Today));
        public IActionResult SortByPriorityOutdated() => View("Outdated", context.Tasks.ToList().OrderBy(task => task.Priority).Where(task => task.Deadline < DateTime.Today));

        public IActionResult SortByNameDaily() => View("Daily", context.Tasks.ToList().OrderBy(task => task.Name).Where(task => task.Deadline.Date == DateTime.Now.Date));
        public IActionResult SortByDeadlineDaily() => View("Daily", context.Tasks.ToList().OrderBy(task => task.Deadline).Where(task => task.Deadline.Date == DateTime.Now.Date));
        public IActionResult SortByPriorityDaily() => View("Daily", context.Tasks.ToList().OrderBy(task => task.Priority).Where(task => task.Deadline.Date == DateTime.Now.Date));

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (!ModelState.IsValid) return View("Index");
            
            context.Tasks.Add(task);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = context.Tasks.Find(id);

            if (task == null) return NotFound();

            context.Tasks.Remove(task);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteOutDated(int id)
        {
            var task = context.Tasks.Find(id);

            if (task == null) return NotFound();

            context.Tasks.Remove(task);
            context.SaveChanges();

            return RedirectToAction("Outdated");
        }

        public IActionResult MarkAsDone(int id)
        {
            var task = context.Tasks.Find(id);

            if (task == null) return NotFound();

            task.IsDone = !task.IsDone;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteDaily(int id)
        {
            var task = context.Tasks.Find(id);

            if (task == null) return NotFound();

            context.Tasks.Remove(task);
            context.SaveChanges();

            return RedirectToAction("Daily");
        }

        public IActionResult MarkAsDoneDaily(int id)
        {
            var task = context.Tasks.Find(id);

            if (task == null) return NotFound();

            task.IsDone = !task.IsDone;
            context.SaveChanges();

            return RedirectToAction("Daily");
        }
    }
}
