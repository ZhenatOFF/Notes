using Notes.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NoteAddingPage), typeof(NoteAddingPage));//маршрут при нажатии кнопки "Добавить записку"
            Routing.RegisterRoute(nameof(TodoAddingPage), typeof(TodoAddingPage));//маршрут при нажатии кнопки "Добавить задачу"
        }
    }
}