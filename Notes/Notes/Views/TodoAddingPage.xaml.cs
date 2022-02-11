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
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class TodoAddingPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadTodo(value);//подгрузка записки
            }
        }

        public TodoAddingPage()
        {
            InitializeComponent();

            BindingContext = new Todo();
        }

        private async void LoadTodo(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);   //получаем id в виде строки и конвертируем в int
                Todo todo = await App.TodoDB.GetTodoAsync(id);//получаем записку по этому id из БД
                BindingContext = todo;   //и связываем записку с данными на странице
            }
            catch
            {
            }
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Todo todo = (Todo)BindingContext;//получаем редактируемую записку
            todo.Deadline = DateTime.UtcNow;     //обновляем дату последнего редактирования


            if (!string.IsNullOrWhiteSpace(todo.Task))//если заголовок присутсвует и это не пробелы
            {
                await App.TodoDB.SaveTodoAsync(todo);//то сохраняем записку в БД
            }

            await Shell.Current.GoToAsync("..");//возвращаемся назад в список (".." означает шаг назад)
        }

        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            Todo todo = (Todo)BindingContext;//получаем редактируемую записку
            await App.TodoDB.DeleteTodoAsync(todo);

            await Shell.Current.GoToAsync("..");//возвращаемся назад в список (".." означает шаг назад)
        }
    }
}