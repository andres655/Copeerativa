using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll_LibreriaClase;

namespace CooperativaCoop
{
    class Tipos
    {
       //agregar un nuevo tipo 
        public static void agregar(string tipo, string Nombre, string descripcion)
        {
            string cmd = String.Format("{0} '{1}','{2}'",
              tipo, Nombre, descripcion);
            Utilidades.Ejecutar(cmd);
        }
        //modificar tipo existente 
        public static void actualizar(string tipo, string Nombre, string descripcion, int id)
        {
            string cmd = String.Format("{0} '{1}','{2}','{3}'",
             tipo, id,Nombre,descripcion);

            Utilidades.Ejecutar(cmd);
        }
        //eliminar tipo existente 
        public static void eliminar(string tipo, int id)
        {
            string cmd = String.Format("{0} '{1}'",
             tipo,id);
            Utilidades.Ejecutar(cmd);
        }
       
    }
}
