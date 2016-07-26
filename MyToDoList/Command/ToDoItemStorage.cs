using System.Collections.Generic;
using MyToDoList.Interfaces;
using MyToDoList.Models;
using MyToDoList.Query;

namespace MyToDoList.Command
{
    public class ToDoItemStorage : IToDoItemStorage
    {
        private readonly IGetToDoList _getToDoListQuery;
        private readonly IObjectStorer _objectStorer;

        public ToDoItemStorage(IGetToDoList getToDoListQuery, IObjectStorer objectStorer)
        {
            _getToDoListQuery = getToDoListQuery;
            _objectStorer = objectStorer;
        }
        public void AddNewToDoItem(string description)
        {
            if (description == string.Empty)
                return;

            var toDoList = _getToDoListQuery.LoadToDoList();
            toDoList.Add(new ToDoItem {Description = description});
            _objectStorer.StoreObject("ToDoList", toDoList);
        }

        public void ClearToDoItems()
        {
            var toDoList = new List<ToDoItem>();
            _objectStorer.StoreObject("ToDoList", toDoList);
        }

        public void RemoveToDoItem(int id)
        {
            var toDoList = _getToDoListQuery.LoadToDoList();
            if (id < 0 || id > toDoList.Count)
                return;
            toDoList.RemoveAt(id);
            _objectStorer.StoreObject("ToDoList", toDoList);
        }
    }
}