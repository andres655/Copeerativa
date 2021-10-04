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
    public partial class Tipo_Prestamo : Form
    {
        public Tipo_Prestamo()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = String.Format("EXEC Agregar_Tipo_Prestamo '{0}','{1}'",
                TxtNombre_Tipo_Prestamo.Text, TxtDescripcion.Text);
                MessageBox.Show("El tipo de prestamo se agregro de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Utilidades.Ejecutar(cmd);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = String.Format("EXEC Actualizar_Tipo_Prestamo '{0}','{1}','{2}'",
                             int.Parse(TxtID.Text), TxtNombre_Tipo_Prestamo.Text, TxtDescripcion.Text);
                MessageBox.Show("El tipo de prestamo se modifico de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Utilidades.Ejecutar(cmd);
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
                string cmd = String.Format("EXEC eliminar_Tipo_prestamo '{0}'",
                             int.Parse(TxtID.Text));
                MessageBox.Show("El tipo de prestamo se Elimino de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Utilidades.Ejecutar(cmd);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }
    }
}
