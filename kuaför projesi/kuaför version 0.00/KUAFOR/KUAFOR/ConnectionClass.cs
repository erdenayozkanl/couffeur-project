﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KUAFOR
{
    class ConnectionClass
    {

        public static string Connection_Path()
        {
            string path = "Data Source=DESKTOP-EO9QOQR\\SQLEXPRESS;Initial Catalog=KUAFOR;Integrated Security=True";
            return path;
        }

    }
}
