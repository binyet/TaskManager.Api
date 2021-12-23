using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Model
{
    public class DBConnection
    {
        public string DBIP { get; set; }
        public int DBPort { get; set; }
        public string DBUser { get; set; }
        public string DBPassword { get; set; }
        public string DBName { get; set; }

        public string MySqlConnectionString => $"Server={DBIP};Port={DBPort};Database={DBName};Uid={DBUser};Pwd={DBPassword};CharSet=utf8;";
    }
}
