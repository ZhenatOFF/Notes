using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Notes.Models;

namespace Notes.Views
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = await App.NotesDB.GetNotesAsync();

            base.OnAppearing();
        }
        
        private async void AddButtonClicked(object sender,EventArgs e)//обработчик нажатия кнопки добавления записки
        {
            await Shell.Current.GoToAsync(nameof(NoteAddingPage));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)//обработчик нажатия по записке
        {
            if (e.CurrentSelection != null)//если есть выделенный элемент в списке
            {
                Note note = (Note)e.CurrentSelection.FirstOrDefault(); //получаем объект, который мы выделили,
                                                                       //т.е. записку, и приводим к типу Note
                await Shell.Current.GoToAsync(
                    $"{nameof(NoteAddingPage)}?{nameof(NoteAddingPage.ItemId)}={note.ID.ToString()}"); 
            }
        }
    }
}