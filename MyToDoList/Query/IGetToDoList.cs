using System.Collections.Generic;
using MyToDoList.Models;

namespace MyToDoList.Query
{
    public interface IGetToDoList
    {
        List<ToDoItem> LoadToDoList();
    }
}