using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace Mobile.Tables
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public Person PC { get; set; } //creating a connection with the parent key
        [ForeignKey(typeof(Person))]
        public int CID { get; set; }
    }
}
