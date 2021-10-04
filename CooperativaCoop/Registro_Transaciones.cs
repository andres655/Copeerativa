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
    public partial class Registro_Transaciones : Form
    {
        public string CadenaBD = "select * from Vista_Transacion ORDER BY [Numero Transancion] DESC";
        public Registro_Transaciones()
        {
            InitializeComponent();
        }

        private void Registro_Transaciones_Load(object sender, EventArgs e)
        {
          dataGridView1.DataSource=  ObtenerDGV.LlenarDataGV("Vista_Transacion", CadenaBD).Tables[0];

        }

        private void BtnBucar_Click(object sender, EventArgs e)
        {
            CadenaBD = string.Format("select * from Vista_Transacion WHERE [Numero Cuenta] LIKE '%{0}%' and  [Fecha] >= '{1}' and[Fecha] <= '{2}' ", TxtBuscar.Text, FechaInicio.Value.Date, FechaFinal.Value.Date);
            dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Vista_Transacion", CadenaBD).Tables[0];
        }
    }
}
