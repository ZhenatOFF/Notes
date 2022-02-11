using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    [QueryProperty(nameof(ItemId),nameof(ItemId))]
    public partial class NoteAddingPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);//подгрузка записки
            }
        }

        public NoteAddingPage()
        {
            InitializeComponent();

            BindingContext = new Note();
        }

        private async void LoadNote(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);   //получаем id в виде строки и конвертируем в int
                Note note = await App.NotesDB.GetNoteAsync(id);//получаем записку по этому id из БД
                BindingContext = note;   //и связываем записку с данными на странице
            }
            catch 
            {
            }
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;//получаем редактируемую записку
            note.Date = DateTime.UtcNow;     //обновляем дату последнего редактирования

            if (string.IsNullOrWhiteSpace(note.Header))
                note.Header = note.Text;

            if (!string.IsNullOrWhiteSpace(note.Header))//если заголовок присутсвует и это не пробелы
            {
                await App.NotesDB.SaveNoteAsync(note);//то сохраняем записку в БД
            }

            await Shell.Current.GoToAsync("..");//возвращаемся назад в список (".." означает шаг назад)
        }

        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;//получаем редактируемую записку
            await App.NotesDB.DeleteNoteAsync(note);

            await Shell.Current.GoToAsync("..");//возвращаемся назад в список (".." означает шаг назад)
        }
    }
}