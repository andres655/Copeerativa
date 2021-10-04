using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dll_LibreriaClase;

namespace CooperativaCoop
{
    public partial class Tipo_Trasancion : Form
    {
        public Tipo_Trasancion()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Tipos.agregar("exec Agregar_Tipo_Trasancio", TxtNombre_Tipo_Prestamo.Text, TxtDescripcion.Text);
              
                MessageBox.Show("El tipo de Transaccion se agregro de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try {
                Tipos.actualizar(" exec Actualizar_Tipo_Trasancion",TxtNombre_Tipo_Prestamo.Text,TxtDescripcion.Text,int.Parse(TxtID.Text));
              
                MessageBox.Show("El tipo de Transaccion se modifico de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Tipos.eliminar("exec eliminar_Tipo_transancion",int.Parse(TxtID.Text));
                
                MessageBox.Show("El tipo de Transaccion se Elimino de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        private void Tipo_Trasancion_Load(object sender, EventArgs e)
        {

        }
    }
}
