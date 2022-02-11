using System.Collections.Generic;
using SQLite;
using Notes.Models;
using System.Threading.Tasks;

namespace Notes.Data
{
    //класс для работы с базой записок
    public class NotesDB
    {
        readonly SQLiteAsyncConnection db;

        public NotesDB(string connectionString)
        {
            //инициализируем подключение
            db = new SQLiteAsyncConnection(connectionString);
            //создаем таблицу
            db.CreateTableAsync<Note>().Wait();
        }

        //метод для получения всех записок
        public Task<List<Note>> GetNotesAsync()
        {
            return db.Table<Note>().ToListAsync();//возвращаем приведенные к списку строки из из таблицы с записками
        }

        //метод для поиска записки по id
        public Task<Note> GetNoteAsync(int id)
        {
            return db.Table<Note>()     //получаем таблицу записок
                .Where(i => i.ID == id) //проверяем совпадение на id
                .FirstOrDefaultAsync(); //и получаем первое совпадение или значение по умолчанию
        }

        //метод для добавления или сохранения сушествующей записки
        public Task<int> SaveNoteAsync(Note note)//при успешной операции изменения в базе возвращается
                                                 //количество обработанных строк, поэтому тип возврата Task<int>
        {
            if (note.ID != 0) //если записка уже есть в базе
                return db.UpdateAsync(note); //то принимаем изменения
            else                             //если же такой записки нет
                return db.InsertAsync(note); //то добавляем ее 
        }

        //метод для удаления записки
        public Task<int> DeleteNoteAsync(Note note)
        {
            return db.DeleteAsync(note);
        }
    }
}
