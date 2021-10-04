using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dll_LibreriaClase;

namespace CooperativaCoop
{
    public partial class Retirar_Padre : Form
    {
        float saldo;
        public Retirar_Padre()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar_Cuenta buscar_Cuenta = new Buscar_Cuenta();
            buscar_Cuenta.Show();

            this.Close();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            llenarDatosPrestamo(int.Parse(TxtBuscar.Text));
        }
        public void llenarDatosPrestamo(int ID_Usuario)
        {


            DataSet Ds;
            string cmd = string.Format("select Nombre_Usuario,imagen,Telefono,Direccion,Correo,Cedula,Monto_Cuenta,cuenta.tipo from cuenta inner join Usuario on Cuenta.ID_Usuario = Usuario.ID_Usuario where cuenta.ID_Cuenta = '{0}' ", ID_Usuario);
            Ds = Utilidades.Ejecutar(cmd);
            TxtCedula.Text = Ds.Tables[0].Rows[0]["Cedula"].ToString();
            TxtCorreo.Text = Ds.Tables[0].Rows[0]["Correo"].ToString();
            TxtNombre.Text = Ds.Tables[0].Rows[0]["Nombre_Usuario"].ToString();
            TxtTelefono.Text = Ds.Tables[0].Rows[0]["Telefono"].ToString();
            TxtDireccion.Text = Ds.Tables[0].Rows[0]["Direccion"].ToString();
            saldo = float.Parse(Ds.Tables[0].Rows[0]["Monto_Cuenta"].ToString());
            LBSaldo.Text= saldo.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
            pictureBox2.ImageLocation= Ds.Tables[0].Rows[0]["imagen"].ToString();
            string tipo= Ds.Tables[0].Rows[0]["tipo"].ToString();
            if (tipo=="Aportaciones")
            {
                BtnRetirar.Enabled = false;
                toolTip1.SetToolTip(this.BtnRetirar, "Las cuentas de aportaciones no pueden retirar");
                toolTip1.Active=true;
                errorProvider1.SetError(BtnRetirar, "Las cuentas de aportaciones no pueden retirar");
            }
            else
            {
                BtnRetirar.Enabled = true;
            }

        }

        private void BtnDepositar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere realizar este deposito", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Deposito(saldo, float.Parse(TxtMonto.Text), int.Parse(TxtBuscar.Text));
            }
        }

        public void Deposito(float Saldo,float Deposito, int id)
        {
            try
            {
                string cmd = String.Format("UPDATE Cuenta SET Monto_Cuenta = {0} WHERE ID_Cuenta = {1}; ", (Saldo + Deposito), id);
                MessageBox.Show("El deposito se realizo de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Utilidades.Ejecutar(cmd);
                Operar_Trasancion operar_Trasancion = new Operar_Trasancion();
                operar_Trasancion.Realizar_Trasancion(id, 2, Deposito, "Deposito a Cuenta");
                llenarDatosPrestamo(int.Parse(TxtBuscar.Text));
            }
            catch(Exception error)
            {
                MessageBox.Show("Error" + error);
            }
          
        }

        public void retiro(float Saldo, float Retiro, int id)
        {
            if (Saldo>Retiro) {
                try
                {

                    string cmd = String.Format("UPDATE Cuenta SET Monto_Cuenta = {0} WHERE ID_Cuenta = {1}; ", (Saldo - Retiro), id);
                    MessageBox.Show("El retiro se realizo de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    Utilidades.Ejecutar(cmd);
                    Operar_Trasancion operar_Trasancion = new Operar_Trasancion();
                    operar_Trasancion.Realizar_Trasancion(id, 3, -Retiro, "Retiro a Cuenta");
                    llenarDatosPrestamo(int.Parse(TxtBuscar.Text));
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error" + error);
                }
            }
            else
            {
                MessageBox.Show("No tiene suficiente saldo para realizar está trasancción");
            }
        }

        private void BtnRetirar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere realizar este retiro", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                retiro(saldo, float.Parse(TxtMonto.Text), int.Parse(TxtBuscar.Text));
            }
        }
    }
}
