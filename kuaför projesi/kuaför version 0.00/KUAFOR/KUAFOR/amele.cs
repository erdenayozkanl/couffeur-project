using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KUAFOR
{
    class amele
    {
        public static void Ekle(string komut)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(komut, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MyConnection.Close();
        }
        public static DataTable BilgiGetir(string komut)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(komut, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MyConnection.Close();
            return dt;
        }
        public static void sil(string komut)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(komut, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MyConnection.Close();
        }
        public static void Update(string somut)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(somut, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MyConnection.Close();
        }
    }
}