using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll_LibreriaClase;

namespace CooperativaCoop
{
    class Operar_Trasancion
    {
        public void Realizar_Trasancion(int cuenta, int Tipo_Trasancion,float Monto_trasancion, string comentario)
        {
           
                //llamar al store procedure  Agregar trasancion
                string cmd = String.Format("EXEC Agregar_Trasancio '{0}','{1}','{2}','{3}','{4}','{5}'",
                             cuenta,Tipo_Trasancion,Monto_trasancion,comentario,DateTime.Now,Login.Nombre_Empleado );

                Utilidades.Ejecutar(cmd);
                

          
        }
    }
}
