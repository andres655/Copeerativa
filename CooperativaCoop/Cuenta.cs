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
    public partial class Cuenta : Form
    {
        int id_Cuenta;
        public Cuenta()
        {
            InitializeComponent();
        }

        public string CadenaUsuario = "select ID_Usuario, Nombre_Usuario  from Usuario";
        public string CadenaTipo_Cuenta = "select ID_Tipo_Cuenta, Nombre_Tipo_Cuenta  from Tipo_Cuenta";
     

        public void  ObtenerDatosUsuario( string CadenaBd,string Display, string valuemember)
        {
            
            this.CbbCuenta.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa",CadenaBd).Tables[0];
            this.CbbCuenta.DisplayMember = Display;
           this.CbbCuenta.ValueMember = valuemember;
          
        }

        public void ObtenerDatosTipoCuenta(string CadenaBd, string Display, string valuemember)
        {

            this.CbbTipo_Cuenta.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa", CadenaBd).Tables[0];
            this.CbbTipo_Cuenta.DisplayMember = Display;
            this.CbbTipo_Cuenta.ValueMember = valuemember;

        }

  
        private void Cuenta_Load(object sender, EventArgs e)
        {
            try
            {
                //llenar el combobox de usuario
                ObtenerDatosUsuario(CadenaUsuario, "Nombre_Usuario", "ID_Usuario");
                ObtenerDatosTipoCuenta(CadenaTipo_Cuenta, "Nombre_Tipo_Cuenta", "ID_Tipo_Cuenta");
                
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CbbCuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string CadenaBD = string.Format("select Nombre_Usuario,ID_Cuenta,Tipo,Monto_Cuenta,Cuenta.Fecha_Creacion from Cuenta inner join  Usuario on Cuenta.ID_Usuario = Usuario.ID_Usuario where Usuario.ID_Usuario= '{0}'", int.Parse(CbbCuenta.SelectedValue.ToString()));

            dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa", CadenaBD).Tables[0];
           
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere agregar esta cuenta", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (TxtMonto.Text != "")
                {
                    try
                    {
                        Agregar_Cuenta(CbbCuenta.SelectedValue.ToString(), CbbTipo_Cuenta.Text, TxtMonto.Text);
                        Operar_Trasancion operar_Trasancion = new Operar_Trasancion();
                        operar_Trasancion.Realizar_Trasancion(id_Cuenta,1009, float.Parse(TxtMonto.Text),"Creaccion de una nueva cuenta");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("error" + error);
                    }
                }
                else
                {
                    errorProvider1.SetError(TxtMonto, "No se admite campos vacios");
                }
            }
        }

        public void Agregar_Cuenta(string ID_Usuario,string Tipo_Cuenta, string Monto)
        {
            //llamar al store procedure  Agregar Cuenta
            string cmd = String.Format("EXEC Agregar_Cuenta '{0}','{1}','{2}','{3}','{4}'",
                         int.Parse(ID_Usuario),Tipo_Cuenta,float.Parse(Monto),"DOM",DateTime.Now);
            MessageBox.Show("La cuenta se agregro de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Utilidades.Ejecutar(cmd);
            string CadenaBD = string.Format("select Nombre_Usuario,ID_Cuenta,Tipo,Monto_Cuenta,Cuenta.Fecha_Creacion from Cuenta inner join  Usuario on Cuenta.ID_Usuario = Usuario.ID_Usuario  where Usuario.ID_Usuario= '{0}' order by Cuenta.ID_Cuenta desc", int.Parse(CbbCuenta.SelectedValue.ToString()));
           
            dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa", CadenaBD).Tables[0];
            TxtID_Cuenta.Text = dataGridView1.CurrentRow.Cells["ID_Cuenta"].Value.ToString();
            id_Cuenta = int.Parse(TxtID_Cuenta.Text);
            

        }
        public void obtenerDatosGV()
        {
           TxtID_Cuenta.Text = dataGridView1.CurrentRow.Cells["ID_Cuenta"].Value.ToString();
            id_Cuenta = int.Parse(TxtID_Cuenta.Text);
            DataSet Ds;
            string cmd = string.Format("select * from Cuenta where ID_Cuenta={0} ", TxtID_Cuenta.Text);
            Ds = Utilidades.Ejecutar(cmd);
            CbbTipo_Cuenta.Text = Ds.Tables[0].Rows[0]["Tipo"].ToString();
           

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            try
            {
                obtenerDatosGV();
                BtnModificar.Enabled = true;
                BtnEliminar.Enabled = true;
                TxtID_Cuenta.Visible = true;
                LbCuenta.Visible = true;
            }

            catch(Exception error)
            {
                MessageBox.Show("error" + error);
            }
        }
        private void Actualizar_Cuenta(string ID_Usuario,string Tipo_Cuenta, string ID_Cuenta)
        {
            string cmd = String.Format("EXEC Actualizar_Cuenta '{0}','{1}','{2}','{3}'",
                       int.Parse(ID_Cuenta),int.Parse(ID_Usuario),Tipo_Cuenta,"DOM");
            MessageBox.Show("La cuenta se Modifico de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Utilidades.Ejecutar(cmd);
            string CadenaBD = string.Format("select Nombre_Usuario,ID_Cuenta,Tipo,Monto_Cuenta,Cuenta.Fecha_Creacion from Cuenta inner join  Usuario on Cuenta.ID_Usuario = Usuario.ID_Usuario where Usuario.ID_Usuario= '{0}'", int.Parse(CbbCuenta.SelectedValue.ToString()));
            dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa", CadenaBD).Tables[0];
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere Modificar esta  cuenta", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    Actualizar_Cuenta(CbbCuenta.SelectedValue.ToString(), CbbTipo_Cuenta.Text, TxtID_Cuenta.Text);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Errro" + error);
                }
            }
        
         }
        private void eliminar_Cuenta(string ID_Cuenta)
        {
            if (MessageBox.Show("Seguro que quiere Modificar este usuario", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string cmd = String.Format("EXEC eliminar_Cuenta '{0}'",
                       int.Parse(ID_Cuenta));
                MessageBox.Show("La cuenta se Elimino de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Utilidades.Ejecutar(cmd);
                string CadenaBD = string.Format("select Nombre_Usuario,ID_Cuenta,Tipo,Monto,Cuenta.Fecha_Creacion from Cuenta inner join  Usuario on Cuenta.ID_Usuario = Usuario.ID_Usuario where Usuario.ID_Usuario= '{0}'", int.Parse(CbbCuenta.SelectedValue.ToString()));
                dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa", CadenaBD).Tables[0];
            }
         }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                eliminar_Cuenta(TxtID_Cuenta.Text);
            }
            catch(Exception error)
            {
                MessageBox.Show("error" + error);
            }
        }
    }
}
