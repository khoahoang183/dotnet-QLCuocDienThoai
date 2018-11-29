﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLCuocDienThoai_Admin.DTO;
namespace QLCuocDienThoai_Admin.DAL
{
    class HoaDonTinhCuocDAL
    {
        DataAccessHelper con = new DataAccessHelper();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable data = new DataTable();

            cmd = new SqlCommand("HoaDonTinhCuoc_Load");
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
        public DataTable GetData_CapNhat(int PhiHangThang)
        {
            DataTable data = new DataTable();

            cmd = new SqlCommand("HoaDonTinhCuoc_AutoGeneration");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vPhiDichVu", PhiHangThang);

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
    }
}