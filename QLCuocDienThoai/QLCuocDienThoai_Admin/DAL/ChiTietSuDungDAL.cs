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
    class ChiTietSuDungDAL
    {
        DataAccessHelper con = new DataAccessHelper();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable data = new DataTable();

            cmd = new SqlCommand("UsageDetail_Load");
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
        public int CountSIM()
        {
            int soluongsim = 0;

            cmd = new SqlCommand("EXEC ChiTietSuDung_Count_SIM");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connect;
            try
            {
                con.OpenConnection();
                soluongsim = int.Parse(cmd.ExecuteScalar().ToString());
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                String mex = ex.Message;
                cmd.Dispose(); // tat session hien tai
                con.CloseConnection();
            }
            return soluongsim;
        }
        public bool AddData(ChiTietSuDung chitiet)
        {
            cmd = new SqlCommand("UsageDetail_Add");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MASIM", chitiet.GetMASIM());
            cmd.Parameters.AddWithValue("@BATDAU", chitiet.GetBATDAU());
            cmd.Parameters.AddWithValue("@KETTHUC", chitiet.GetKETTHUC());
            cmd.Parameters.AddWithValue("@SAU23H", chitiet.GetSOPHUTSUDUNGSAU23H());
            cmd.Parameters.AddWithValue("@SAU7H", chitiet.GetSOPHUTSUDUNGSAU7H());
            cmd.Parameters.AddWithValue("@CUOCPHI", chitiet.GetCUOCPHI());

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
        public DataTable SearchData(int MaSIM)
        {
            cmd = new SqlCommand("UsageDetail_Search");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MASIM", MaSIM);
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
