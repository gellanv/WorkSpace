using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Repositories
{
    interface IRepository<T> : IDisposable  //На случай, если контекст данных будет подразумевать освобождение или закрытие подключений, интерфейс репозитория применяет интерфейс IDisposable
        where T : class
    {
        IEnumerable<T> GetList(); // получение всех объектов
        T Get(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
