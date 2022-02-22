using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace AuctionHouse.Model
{
    public class Product : INotifyPropertyChanged
    {
        private string _name;
        private double _price;
        private int _time;
        private double _lastoffer;
        private string _lastbidder;
        private int _id;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Name { get { return _name; } set { _name = value; } }

        public double Price { get { return _price;} set { _price = value; } }

        public int Time { get { return _time; } set { if (_time == value) { return; } _time = value; OnPropertyChanged(new PropertyChangedEventArgs(nameof(Time))); } }

        public double LastOffer { get { return _lastoffer;} set { _lastoffer = value; } } 

        public string LastBidder { get { return _lastbidder; } set { _lastbidder = value; } }

        public int Id { get { return _id; } }

        public Product(string name, double price, double lastoffer, string lastbidder, int time, int id)
        {
            this._name = name;
            this._price = price;
            _time = time;
            this._lastoffer = lastoffer;
            this._lastbidder = lastbidder;
            _id = id;   

        }

        public Product(string name, int price)
        {
            _name = name;
            _price = price;
        }

        


        public Product()
        {
            
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public void Bid(string LastBidder)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["masterDatabase"].ToString();
                connection.Open();

                SqlCommand cmd = new SqlCommand("Update Product Set LastOffer=@LastOffer,LastBidder=@LastBidder,Time=@Time where ID=@Id", connection);
                SqlParameter LastOfferparam = new SqlParameter("@LastOffer",SqlDbType.Int);
                LastOfferparam.Value = LastOffer+1;
                cmd.Parameters.Add(LastOfferparam);

                SqlParameter LastBidderparam = new SqlParameter("@LastBidder",SqlDbType.NVarChar);
                LastBidderparam.Value = LastBidder;
                cmd.Parameters.Add(LastBidderparam);

                SqlParameter Timeparam = new SqlParameter("@Time", SqlDbType.Int);
                Timeparam.Value = Time + 120;
                cmd.Parameters.Add(Timeparam);


                SqlParameter idparam = new SqlParameter("@ID", SqlDbType.Int);
                idparam.Value= Id;
                cmd.Parameters.Add(idparam);

                cmd.ExecuteNonQuery();
            }
        }

        public void AddProduct()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["masterDatabase"].ToString();
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into Product(Name,Price,LastOffer) values(@Name,@Price,@LastOffer)", connection);

                SqlParameter nameparam = new SqlParameter("@Name",SqlDbType.NVarChar);
                nameparam.Value = Name;
                command.Parameters.Add(nameparam);

                SqlParameter priceparam = new SqlParameter("@Price",SqlDbType.Int); 
                priceparam.Value = Price;
                command.Parameters.Add(priceparam);

                SqlParameter lastparam = new SqlParameter("@LastOffer", SqlDbType.Int);
                lastparam.Value = Price;
                command.Parameters.Add(lastparam);

                command.ExecuteNonQuery();  
            }
        }

        public void DeleteProduct()
        {
            using (SqlConnection connection=new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["masterDatabase"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand("delete from Product where ID=@id", connection);
                SqlParameter idparam = new SqlParameter("ID",SqlDbType.Int);
                idparam.Value = Id;
                command.Parameters.Add(idparam);
                
                command.ExecuteNonQuery();
            }
        }


    }
}
