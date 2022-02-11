using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Notes.Data;
using System.IO;

namespace Notes
{
    public partial class App : Application
    {
        static NotesDB notesDB;
        static TodoDB todoDB;
        public static NotesDB NotesDB
        {
            get
            {
                if (notesDB == null)
                {
                    notesDB = new NotesDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "NotesDatabase.db3"));
                }
                return notesDB;
            }
        }
        public static TodoDB TodoDB
        {
            get
            {
                if (todoDB == null)
                {
                    todoDB = new TodoDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "TodoDatabase.db3"));
                }
                return todoDB;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
             
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
