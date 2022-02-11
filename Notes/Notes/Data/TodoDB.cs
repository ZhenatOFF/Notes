using Notes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data
{
    public class TodoDB
    {
        readonly SQLiteAsyncConnection db;

        public TodoDB(string connectionString)
        {
            //инициализируем подключение
            db = new SQLiteAsyncConnection(connectionString);
            //создаем таблицу
            db.CreateTableAsync<Todo>().Wait();
        }

        //метод для получения всех записок
        public Task<List<Todo>> GetTodoAsync()
        {
            return db.Table<Todo>().ToListAsync();//возвращаем приведенные к списку строки из из таблицы с записками
        }

        //метод для поиска записки по id
        public Task<Todo> GetTodoAsync(int id)
        {
            return db.Table<Todo>()     //получаем таблицу записок
                .Where(i => i.ID == id) //проверяем совпадение на id
                .FirstOrDefaultAsync(); //и получаем первое совпадение или значение по умолчанию
        }

        //метод для добавления или сохранения сушествующей задачи
        public Task<int> SaveTodoAsync(Todo todo)//при успешной операции изменения в базе возвращается
                                                 //количество обработанных строк, поэтому тип возврата Task<int>
        {
            if (todo.ID != 0) //если записка уже есть в базе
                return db.UpdateAsync(todo); //то принимаем изменения
            else                             //если же такой записки нет
                return db.InsertAsync(todo); //то добавляем ее 
        }

        //метод для удаления записки
        public Task<int> DeleteTodoAsync(Todo todo)
        {
            return db.DeleteAsync(todo);
        }
    }
}
