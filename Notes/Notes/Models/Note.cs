using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
