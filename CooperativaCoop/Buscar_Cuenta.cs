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
    public partial class Buscar_Cuenta : Form
    {
        string CadenaBD = "select Usuario.ID_Usuario, Cuenta.ID_Cuenta,Nombre_Usuario,Telefono,Direccion,Correo,Cedula,Monto_Cuenta from cuenta inner join Usuario on Cuenta.ID_Usuario = Usuario.ID_Usuario";
        public static int ID_Prestamo;
        public Buscar_Cuenta()
        {
            InitializeComponent();
        }

        private void Buscar_Cuenta_Load(object sender, EventArgs e)
        {
            ObtenerDatosCuenta(CadenaBD);
        }
        public void ObtenerDatosCuenta(string CadenaBd)
        {

            dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa", CadenaBd).Tables[0];

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CadenaBD = string.Format("select Usuario.ID_Usuario,Cuenta.ID_Cuenta, Nombre_Usuario,Telefono,Direccion,Correo,Cedula,Monto_Cuenta from cuenta inner join Usuario on Cuenta.ID_Usuario = Usuario.ID_Usuario where  Usuario.Nombre_Usuario LIKE '%{0}%'", TxtBuscar.Text);
            ObtenerDatosCuenta(CadenaBD);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
            ID_Prestamo = int.Parse(dataGridView1.CurrentRow.Cells["ID_Cuenta"].Value.ToString());
           Retirar retirar = new Retirar();
           
            retirar.TxtBuscar.Text = ID_Prestamo.ToString();
            this.Activate();
            retirar.Show();
            
             this.Close();
        }
    }
}
