using System;

namespace ConexionDB
{
    public class Class1
    {
        public class Utilidades
        {

            public static DataSet Ejecutar(String cmd)
            {
                SqlConnection con = new SqlConnection("Data Source=PCAG150OVRHKF\\MSSQLEXPRESS;Initial Catalog=Cooperativa;Integrated Security=True");
                con.Open();
                DataSet Ds = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, con);
                DP.Fill(Ds);
                con.Close();
                return Ds;
            }
        }
}
