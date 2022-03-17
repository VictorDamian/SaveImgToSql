using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveImgSql.Repositorios
{
    public abstract class Repositorio
    {
        private readonly string cadena;
        public Repositorio()
        {
            cadena = "Server = DANTES; Database = saveimg; Integrated security = true";
        }
        protected SqlConnection GetConn()
        {
            return new SqlConnection(cadena);
        }
    }
}
