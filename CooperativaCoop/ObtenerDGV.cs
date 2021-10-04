using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll_LibreriaClase;

namespace CooperativaCoop
{
    public class ObtenerDGV
    {
        public static DataSet LlenarDataGV(string tabla, string CadenaBD)
        {
            
                DataSet Ds;
                string cmd = string.Format(CadenaBD);
                Ds = Utilidades.Ejecutar(cmd);
           

                return Ds;
            
            
        }

        public static DataSet LlenarCuenta(string tabla, string CadenaBD)
        {

            DataSet Ds;
            string cmd = string.Format(CadenaBD);
            Ds = Utilidades.Ejecutar(cmd);

            return Ds;


        }
    }
  
}
