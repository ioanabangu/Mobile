using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;
using SQLite;

namespace Mobile.Tables
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public Note childNote { get; set; } // meking a connection the the foreign key
    }
}
