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
    class HoaDonDangKyDAL
    {
        DataAccessHelper con = new DataAccessHelper();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable data = new DataTable();

            cmd = new SqlCommand("HoaDonDangKy_Load");
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
        public DataTable GetData_Combobox_MaSIM()
        {
            DataTable data = new DataTable();

            cmd = new SqlCommand("HoaDonDangKy_combobox_MASIM");
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

        public bool AddData(HoaDonDangKy hoadon)
        {
            cmd = new SqlCommand("HoaDonDangKy_Add");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vMASIM", hoadon.GetMASIM());
            cmd.Parameters.AddWithValue("@vPHIDANGKI", hoadon.GetPHIDANGKI());
            cmd.Parameters.AddWithValue("@vNGAYDANGKI", hoadon.GetNGAYDANGKI());

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

        public bool UpdateData(HoaDonDangKy hoadon)
        {
            cmd = new SqlCommand("HoaDonDangKy_Update");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vMAHDDK", hoadon.GetMAHDDK());
            cmd.Parameters.AddWithValue("@vMASIM", hoadon.GetMASIM());
            cmd.Parameters.AddWithValue("@vPHIDANGKI", hoadon.GetPHIDANGKI());
            cmd.Parameters.AddWithValue("@vNGAYDANGKI", hoadon.GetNGAYDANGKI());

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

        public bool DeleteData(int MaHDDK)
        {
            cmd = new SqlCommand("HoaDonDangky_Delete");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vMAHDDK", MaHDDK);
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

        public DataTable SearchData(int MaHDDK)
        {
            cmd = new SqlCommand("HoaDonDangKy_Search");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vMAHDDK", MaHDDK);
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
