using Microsoft.AspNetCore.Mvc;
using todo_asp_mvc.Models;
using todo_asp_mvc.Data;

namespace todo_asp_mvc.Controllers
{
    public class TodoController: Controller
    {
        TodoContext _todoContext;
        public TodoController(TodoContext todoContext)
        {
             _todoContext = todoContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Todo> todo = _todoContext.Todo;
            return View(todo);
        }

        public IActionResult Delete(int id)
        {
            _todoContext.RetriveObjectByID(id, out Todo? todo);
            if (todo != null)
            {
                _todoContext.Remove(todo);
                _todoContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateTodo(Todo todo)
        {
            _todoContext.Add(todo);
            _todoContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            _todoContext.RetriveObjectByID(id, out Todo? todo);
            if (todo != null)
            {
                todo.IsDone = !todo.IsDone;
                _todoContext.SaveChanges();
            }
            return RedirectToAction("Index");
        } 
    }
}