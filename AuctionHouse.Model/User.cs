using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse.Model
{
    public class User : INotifyPropertyChanged
    {
        private int _id;
        private string _username;
        private string _password;
        private bool _isAdmin;

        private User _CurrentUser;

        public event PropertyChangedEventHandler? PropertyChanged;



        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Username { get { return _username; } set { _username = value; } }
        public string Password { get { return _password; } set { _password = value; } } 

        public bool IsAdmin { get { return _isAdmin; } set { _isAdmin = value; } }  

        public User CurrentUser { get { return _CurrentUser; } set { _CurrentUser = value; } }

        public User(int id,string username,string password,bool isAdmin)
        {
            _id = id;
            _username = username;
            _password = password;
            _isAdmin = isAdmin;
             
        }

        public User()
        {

        }

        public User(string username,string password)
        {
            this._username = username;  
            this._password = password;
        }

        public object Login()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["masterDatabase"].ToString();
                connection.Open();
                string query = "select * from Users";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                     
                    if (reader["UserName"].ToString() == _username && reader["UserPass"].ToString() == _password)
                    {
                        this.CurrentUser = new User((int)reader["ID"], (string)reader["UserName"], (string)reader["UserPass"], (bool)reader["IsAdmin"]);
                        return _CurrentUser;

                    }
                    else
                    {
                        this.CurrentUser = null;
                        return _CurrentUser;
                    }
                    
                
               }
                reader.Close();
                connection.Close();
                return this._CurrentUser;
            }
        }
    }
}
