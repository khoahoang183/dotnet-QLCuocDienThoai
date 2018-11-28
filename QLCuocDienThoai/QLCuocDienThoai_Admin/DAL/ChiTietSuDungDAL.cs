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
    }
}
