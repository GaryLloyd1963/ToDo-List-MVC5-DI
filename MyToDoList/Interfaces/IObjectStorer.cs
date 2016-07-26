namespace MyToDoList.Interfaces
{
    public interface IObjectStorer
    {
        void StoreObject(string name, object obj);
        T LoadObject<T>(string name);
    }
}