namespace MyToDoList.Command
{
    public interface IToDoItemStorage
    {
        void AddNewToDoItem(string description);
        void ClearToDoItems();
        void RemoveToDoItem(int id);
    }
}