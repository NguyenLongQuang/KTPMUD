using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Models
{
    internal class Provider
    {
        string _connString;
        SqlConnection _conn;
        public Provider(string connectionString) { ConnectionString = connectionString; }
        //public Provider() : this(@"Data Source=.\SQLEXPRESS;Initial Catalog=Contact;Integrated Security=True") { }
        public Provider() : this(@"Data Source=.\SQLEXPRESS;Initial Catalog=Contact;Integrated Security=True") { }

        public string ConnectionString
        {
            get => _connString;
            set
            {
                if (_connString != value)
                {
                    Close();

                    _connString = value;
                    _conn = new SqlConnection(value);
                }
            }
        }

        public SqlConnection Open()
        {
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }
            return _conn;
        }

        public void Close()
        {
            if (_conn != null && _conn.State != ConnectionState.Closed)
            {
                _conn.Close();
            }
        }

        public DataTable Load(string sql)
        {
            var cmd = new SqlCommand(sql, Open());
            var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();
            Close();
            return table;
        }

        public List<T> Select<T>(string sql) where T : new()
        {
            var lst = new List<T>();
            var props = typeof(T).GetProperties();
            foreach (DataRow r in Load(sql).Rows)
            {
                var one = new T();
                foreach (var prop in props)
                {
                    if (prop.CanWrite == false) continue;
                    var v = r[prop.Name];
                    prop.SetValue(one, v);
                }
                lst.Add(one);
            }
            return lst;
        }

    }

}
