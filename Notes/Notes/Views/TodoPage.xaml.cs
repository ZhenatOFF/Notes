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
    public partial class TodoPage : ContentPage
    {
        public TodoPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            todoCollectionView.ItemsSource = await App.TodoDB.GetTodoAsync();

            base.OnAppearing();
        }

        private async void AddButtonClicked(object sender, EventArgs e)//обработчик нажатия кнопки добавления записки
        {
            await Shell.Current.GoToAsync(nameof(TodoAddingPage));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)//обработчик нажатия по записке
        {
            if (e.CurrentSelection != null)//если есть выделенный элемент в списке
            {
                Todo todo = (Todo)e.CurrentSelection.FirstOrDefault(); //получаем объект, который мы выделили,
                                                                       //т.е. записку, и приводим к типу Note
                await Shell.Current.GoToAsync(
                    $"{nameof(TodoAddingPage)}?{nameof(TodoAddingPage.ItemId)}={todo.ID.ToString()}");
            }
        }
    }
}