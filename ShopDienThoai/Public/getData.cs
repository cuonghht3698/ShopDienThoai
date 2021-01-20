using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopQuanAo.Public
{
    public class getData
    {
        private string connection = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        private SqlConnection conn;
        public getData()
        {
            conn = new SqlConnection(connection);
        }

        private void connect()

        {
            if (conn == null)

                conn = new SqlConnection(connection);

            if (conn.State == ConnectionState.Closed)

                conn.Open();

        }

        // đóng kết nối

        private void disconnect()

        {

            if ((conn != null) && (conn.State == ConnectionState.Open))

                conn.Close();

        }
        // trả về một DataTable .
        public DataTable getDataTable(string sql)

        {

            connect();

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            disconnect();

            return dt;

        }

        public void ExecuteNonQuery(string sql)

        {

            connect();

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

            disconnect();

        }

        // trả về DataReader

        public SqlDataReader getDataReader(string sql)

        {

            connect();

            SqlCommand com = new SqlCommand(sql, conn);

            SqlDataReader dr = com.ExecuteReader();
            return dr;

        }
    }
}
