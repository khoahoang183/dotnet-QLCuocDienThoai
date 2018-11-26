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
    class ThongTinSimDAL
    {
        DataAccessHelper con = new DataAccessHelper();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable data = new DataTable();

            cmd = new SqlCommand("SIM_Load");
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
        public DataTable GetData_Combobox_MaKH()
        {
            DataTable data = new DataTable();

            cmd = new SqlCommand("SIM_combobox_MAKH");
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

        public bool AddData(ThongTinSim SIM)
        {
            cmd = new SqlCommand("SIM_Add");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vSODT", SIM.GetSODT());
            cmd.Parameters.AddWithValue("@vMAKH", SIM.GetMAKH());
            cmd.Parameters.AddWithValue("@vTINHTRANG", SIM.GetTINHTRANG());

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

        public bool UpdateData(ThongTinSim SIM)
        {
            cmd = new SqlCommand("SIM_Update");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vMASIM",SIM.GetMASIM());
            cmd.Parameters.AddWithValue("@vSODT", SIM.GetSODT());
            cmd.Parameters.AddWithValue("@vMAKH", SIM.GetMAKH());
            cmd.Parameters.AddWithValue("@vTINHTRANG", SIM.GetTINHTRANG());
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

        public bool LockData(int MaSIM, int TinhTrang)
        {
            int temp = 0;
            if (TinhTrang == 0) temp = 1;
            else temp = 0;

            cmd = new SqlCommand("SIM_Lock");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vMASIM", MaSIM);
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
            cmd = new SqlCommand("SIM_Search");
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
