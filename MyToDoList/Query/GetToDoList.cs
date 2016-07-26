using System.Collections.Generic;
using MyToDoList.Interfaces;
using MyToDoList.Models;

namespace MyToDoList.Query
{
    public class GetToDoList : IGetToDoList
    {
        private readonly IObjectStorer _objectStorer;

        public GetToDoList(IObjectStorer fileStorageManager)
        {
            _objectStorer = fileStorageManager;
        }

        public List<ToDoItem> LoadToDoList()
        {
            return _objectStorer.LoadObject<List<ToDoItem>>("ToDoList") ?? new List<ToDoItem>();
        }
    }
}