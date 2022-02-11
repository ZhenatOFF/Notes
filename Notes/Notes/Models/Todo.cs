using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Models
{
    public class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Task { get; set; }
        public string Text { get; set; }
        public DateTime Deadline { get; set; }
    }
}
