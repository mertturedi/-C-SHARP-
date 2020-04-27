using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
   public class sqlBağlanti
    {

        private  int id;
        private  string mail;

        public  int Id { get => id; set => id = value; }
        public  string Mail { get => mail; set => mail = value; }

        //public static int Id { get { return sqlBağlanti.id; } set { id = value; } }
        //public static string Mail { get { return sqlBağlanti.mail; } set { mail = value; } }






        //public static int Id
        //{
        //    get { return Login.id; }
        //    set { id = value; }
        //}

    }
}
