using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveImgSql.Repositorios
{
    public abstract class RepoMaster:Repositorio
    {
        protected List<SqlParameter> param;
        protected void NonQuery(string tran)
        {
            using(var conn = GetConn())
            {
                conn.Open();
                using (var comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = tran;
                    comm.CommandType = CommandType.Text;
                    foreach (SqlParameter item in param)
                    {
                        comm.Parameters.Add(item);
                    }
                    comm.ExecuteNonQuery();
                    param.Clear();
                }
            }
        }
        protected void NonQUerySP(string tran)
        {
            using(var con = GetConn())
            {
                con.Open();
                using(var comm = new SqlCommand())
                {
                    comm.Connection = con;
                    comm.CommandText = tran;
                    comm.CommandType = CommandType.StoredProcedure;
                    foreach(SqlParameter item in param)
                    {
                        comm.Parameters.Add(item);
                    }
                    comm.ExecuteNonQuery();
                    comm.Clone();
                }
            }
        }
        protected DataTable ExecuteReader(string tran)
        {
            using(var con = GetConn())
            {
                con.Open();
                using(var comm = new SqlCommand())
                {
                    comm.Connection = con;
                    comm.CommandText = tran;
                    comm.CommandType = CommandType.Text;
                    SqlDataReader reader = comm.ExecuteReader();
                    using(var table = new DataTable())
                    {
                        table.Load(reader);
                        reader.Dispose();
                        return table;
                    }
                }
            }
        }
    }
}
