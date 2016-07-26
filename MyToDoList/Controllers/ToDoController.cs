using System.Collections.Generic;
using System.Web.Mvc;
using MyToDoList.Command;
using MyToDoList.Models;
using MyToDoList.Query;

namespace MyToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private List<ToDoItem> _toDoItems;
        private readonly IGetToDoList _getToDoListQuery;
        private readonly IToDoItemStorage _toDoItemStorage;

        public ToDoController(IGetToDoList getToDoListQuery, IToDoItemStorage toDoItemStorage)
        {
            _toDoItems = new List<ToDoItem>();
            _getToDoListQuery = getToDoListQuery;
            _toDoItemStorage = toDoItemStorage;
        }

        // GET: Home
        public ActionResult Index()
        {
            _toDoItems = _getToDoListQuery.LoadToDoList();
            return View(_toDoItems);
        }

        public ActionResult AddNewToDoItem(string newToDoItem)
        {
            _toDoItemStorage.AddNewToDoItem(newToDoItem);
            return RedirectToAction("Index");
        }

        public ActionResult ClearToDoList()
        {
            _toDoItemStorage.ClearToDoItems();
            return RedirectToAction("Index");
        }

        public ActionResult ClearToDoItem(int id)
        {
            _toDoItemStorage.RemoveToDoItem(id);
            return RedirectToAction("Index");
        }
    }
}