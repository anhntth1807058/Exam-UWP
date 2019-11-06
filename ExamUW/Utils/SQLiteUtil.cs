using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace ExamUW.Utils
{
    public class SQLiteUtil
    {
        private const string DatabaseName = "demo.db";

        private static SQLiteUtil _instance;
        public SQLiteConnection Connection { get; }

        public static SQLiteUtil GetIntances()
        {
            if (_instance == null)
            {
                _instance = new SQLiteUtil();
            }
            return _instance;
        }

        private SQLiteUtil()
        {
            Connection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Contact (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Name VARCHAR( 140 ) NOT NULL, PhoneNumber UNSIGNED BIG INT NOT NULL UNIQUE);";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
        }
    }
}
