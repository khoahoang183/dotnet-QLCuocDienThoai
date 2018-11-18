using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLCuocDienThoai_Admin.DTO;

namespace QLCuocDienThoai_Admin.DAL
{
    class KhachHangDAL
    {
        DataAccessHelper con = new DataAccessHelper();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable data = new DataTable();

            cmd = new SqlCommand("Customer_Load");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.Connect;
            try
            {
                con.OpenConnection();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(data);
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose(); 
                con.CloseConnection();
            }
            return data;
        }

        public bool AddData(KhachHang khachhang)
        {
            cmd = new SqlCommand("Customer_Add");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vTEN", khachhang.GetTEN());
            cmd.Parameters.AddWithValue("@vTHONGTIN", khachhang.GetTHONGTIN());
            cmd.Parameters.AddWithValue("@vTINHTRANG", khachhang.GetTINHTRANG());

            cmd.Connection = con.Connect;
            try
            {
                con.OpenConnection();
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConnection();
            }
            return false;

        }

        public bool UpdateData(KhachHang khachhang)
        {
            cmd = new SqlCommand("Customer_Update");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vMAKH", khachhang.GetMAKH());
            cmd.Parameters.AddWithValue("@vTEN", khachhang.GetTEN());
            cmd.Parameters.AddWithValue("@vTHONGTIN", khachhang.GetTHONGTIN());
            cmd.Parameters.AddWithValue("@vTINHTRANG", khachhang.GetTINHTRANG());
            cmd.Connection = con.Connect;
            try
            {
                con.OpenConnection();
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConnection();
            }
            return false;
        }

        public bool LockData(int MaKH, int TinhTrang)
        {
            int temp=0;
            if (TinhTrang == 0) temp = 1;
            else temp = 0;
                    
            cmd = new SqlCommand("Customer_Lock");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vMAKH", MaKH);
            cmd.Parameters.AddWithValue("@vTINHTRANG", temp);
            cmd.Connection = con.Connect;
            try
            {
                con.OpenConnection();
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConnection();
            }
            return false;
        }

        public DataTable SearchData(int MaKH)
        {
            cmd = new SqlCommand("Customer_Search");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vMAKH", MaKH);
            cmd.Connection = con.Connect;
            DataTable data = new DataTable();
            try
            {
                con.OpenConnection();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(data);
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose(); // tat session (phien lam viec) hien tai
                con.CloseConnection();
            }
            return data;
        }
    }
}
