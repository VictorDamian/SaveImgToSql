using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveImgSql.Repositorios
{
    public class DataImg:RepoMaster
    {
        private int id;
        private string usr;
        private string email;
        private string con;
        private Byte[] img;

        public DataImg()
        {
            this.id = Id;
            this.usr = Usr;
            this.email = Email;
            this.con = Con;
            this.img = Img;
        }

        public int Id { get => id; set => id = value; }
        public string Usr { get => usr; set => usr = value; }
        public string Email { get => email; set => email = value; }
        public string Con { get => con; set => con = value; }
        public byte[] Img { get => img; set => img = value; }

        public void saveIMG()
        {
            string tran = "insert into SAVEIMAGE values (@usr, @email, @pass, @img)";
            param = new List<SqlParameter>();
            param.Add(new SqlParameter("@usr", usr));
            param.Add(new SqlParameter("@email", email));
            param.Add(new SqlParameter("@pass", con));
            param.Add(new SqlParameter("@img", img));
            NonQuery(tran);
        }
        public DataTable VerUsr()
        {
            string tran = "select*from SAVEIMAGE";
            return ExecuteReader(tran);
        }
        public string SaveC()
        {
            string msj = null;
            try
            {
                saveIMG();
                msj = "yES";
            }
            catch (Exception e)
            {
                msj = e.ToString();
            }
            return msj;
        }
    }
}
