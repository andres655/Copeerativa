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
    public partial class BuscarPrestamo : Form
    {
        string CadenaBD = "SELECT Nombre_Usuario,Usuario.ID_Usuario,Cuenta.ID_Cuenta,ID_Prestamo,Telefono,Direccion,Cedula,Prestamo.Fecha FROM Cuenta INNER JOIN Prestamo ON Cuenta.ID_Cuenta = Prestamo.ID_Cuenta inner join Usuario  on Usuario.ID_Usuario= Cuenta.ID_Usuario";
        public static int ID_Prestamo;
        public BuscarPrestamo()
        {
            InitializeComponent();
        }
        
        private void BuscarPrestamo_Load(object sender, EventArgs e)
        {

            ObtenerDatosPrestamo(CadenaBD);
        }

        public void ObtenerDatosPrestamo(string CadenaBd)
        {

            dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa", CadenaBd).Tables[0];
            
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
             CadenaBD = string.Format("SELECT Nombre_Usuario,Usuario.ID_Usuario,Cuenta.ID_Cuenta,ID_Prestamo,Telefono,Direccion,Cedula,Prestamo.Fecha FROM Cuenta INNER JOIN Prestamo ON Cuenta.ID_Cuenta = Prestamo.ID_Cuenta inner join Usuario  on Usuario.ID_Usuario = Cuenta.ID_Usuario  where Usuario.Nombre_Usuario LIKE '%{0}%'", TxtBuscar.Text);
            ObtenerDatosPrestamo(CadenaBD);
        }

       public void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ID_Prestamo =int.Parse(dataGridView1.CurrentRow.Cells["ID_Prestamo"].Value.ToString());
            Historila_Prestamo historila_Prestamo = new Historila_Prestamo();
            historila_Prestamo.TxtBuscar.Text= ID_Prestamo.ToString();
            historila_Prestamo.Show();
            this.Close();
        }

    
    }
}
