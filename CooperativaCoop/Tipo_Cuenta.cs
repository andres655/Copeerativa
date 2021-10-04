using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CooperativaCoop
{
    public partial class Tipo_Cuenta : Form
    {
        public Tipo_Cuenta()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Tipos.agregar("exec Agregar_Tipo_Cuenta", TxtNombre_Tipo_Prestamo.Text, TxtDescripcion.Text);

                MessageBox.Show("El tipo de Cuenta se agregro de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (TxtID.Text!="") {
                try
                {
                    Tipos.actualizar("exec actualizar_Tipo_Cuenta", TxtNombre_Tipo_Prestamo.Text, TxtDescripcion.Text, int.Parse(TxtID.Text));

                    MessageBox.Show("El tipo de Cuenta se modifico de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error" + error);
                }
            }
            else
            {
                errorProvider1.SetError(TxtID, "No se admite campos vacios");
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "")
            {
                try
                {
                    Tipos.eliminar("exec eliminar_Tipo_Cuenta", int.Parse(TxtID.Text));

                    MessageBox.Show("El tipo de Cuenta se Elimino de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error" + error);
                }
            }
            else
            {
                errorProvider1.SetError(TxtID, "No se admite campos vacios");
            }
        }
    }
}
