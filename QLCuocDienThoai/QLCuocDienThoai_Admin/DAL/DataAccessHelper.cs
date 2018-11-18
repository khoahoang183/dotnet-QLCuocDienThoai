using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace QLCuocDienThoai_Admin.DAL
{
    class DataAccessHelper
    {
        private SqlConnection connect;
        private SqlCommand command;
        private string error;
        public string StrCon;

        //----------------------------------------------------------------
        public SqlCommand Command
        {
            get { return command; }
            set { command = value; }
        }
        public SqlConnection Connect
        {
            get { return connect; }
            //set { connect = value; }
        }
        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        //----------------------------------------------------------------

        public DataAccessHelper()
        {
            StrCon = @"Data Source=.;Initial Catalog=QLCUOCDIENTHOAI;Persist Security Info=True;User ID=sa;Password=123456";

            connect = new SqlConnection(StrCon);
        }

        public bool OpenConnection()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public bool CloseConnection()
        {
            try
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }
    }
}
