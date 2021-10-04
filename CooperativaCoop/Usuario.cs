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
    public partial class Usuario : Form
    {
        string direccion_Imagen = "";

       
        public Usuario()
        {
            InitializeComponent();
        }

        public string CadenaBD= "select * from Usuario";

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quieres agregar este usuario", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    Agregar_Usuario();
                }

                catch (Exception error)
                {

                    MessageBox.Show("Error" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

      private void Obtener_DatosDGV()
        {
           TxtID_Usuario.Text = dataGridView1.CurrentRow.Cells["ID_Usuario"].Value.ToString();
           
                DataSet Ds;
                string cmd = string.Format("select * from Usuario where ID_Usuario={0} ", TxtID_Usuario.Text);
                Ds = Utilidades.Ejecutar(cmd);
                TxtID_Usuario.Text = Ds.Tables[0].Rows[0]["ID_Usuario"].ToString();
                TxtID_Usuario.ReadOnly = true;
                TxtCedula.Text = Ds.Tables[0].Rows[0]["Cedula"].ToString();
                TxtCorreo.Text = Ds.Tables[0].Rows[0]["Correo"].ToString();
                TxtNombre.Text = Ds.Tables[0].Rows[0]["Nombre_Usuario"].ToString();
                TxtTelefono.Text = Ds.Tables[0].Rows[0]["Telefono"].ToString();
            TxtDireccion.Text = Ds.Tables[0].Rows[0]["Direccion"].ToString();
            pictureBox1.ImageLocation = Ds.Tables[0].Rows[0]["imagen"].ToString();
            

        }
        private void Buscar_Usuario(string Buscar)
        {
            //filtrar los usuarios del datagriidview
            CadenaBD = string.Format("SELECT *FROM Usuario WHERE Nombre_Usuario LIKE '%{0}%' or Cedula like '%{0}%'", Buscar);
            dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa",CadenaBD).Tables[0];
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa",CadenaBD).Tables[0];
            BtnModificar.Enabled = false;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar_Usuario(TxtBuscar.Text);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar_Usuario(TxtBuscar.Text);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere Modificar este usuario", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //no permite que se realize cambios en blanco
                if (TxtID_Usuario.Text == "")
                {
                    errorProvider1.SetError(TxtID_Usuario, "No se admite campos vacios");
                }
                else
                {
                    try
                    {

                        Modificar_Usuario(TxtID_Usuario.Text);
                    }
                    catch (Exception error)
                    {

                        MessageBox.Show("Error" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #region CRUD
        public void Agregar_Usuario()
        {
            //llamar al store procedure  Agregar Usuario
            string cmd = String.Format("EXEC Agregar_Usuario '{0}','{1}','{2}','{3}','{4}','{5}','{6}'",
                TxtNombre.Text, TxtTelefono.Text, TxtCorreo.Text, TxtCedula.Text, TxtDireccion.Text, DateTime.Now,direccion_Imagen);
            MessageBox.Show("El Usuario se agregro de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Utilidades.Ejecutar(cmd);
            dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa",CadenaBD).Tables[0];
            
            Limpiar();
        }
        public void Modificar_Usuario(string ID)
        {
            
                //llamar al store procedure  Modificar Usuario
                string cmd = String.Format("EXEC Actualizar_Usuario '{0}','{1}','{2}','{3}','{4}','{5}','{6}'",
                ID, TxtNombre.Text, TxtTelefono.Text, TxtDireccion.Text, TxtCorreo.Text, TxtCedula.Text,direccion_Imagen);
            MessageBox.Show("El Usuario se modifico de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Utilidades.Ejecutar(cmd);
            //llamar a la case ObtenerDGV
            dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa",CadenaBD).Tables[0];
            Limpiar();
        }
        public void Eliminar_Usuario(string ID)
        {
            
                //llamar al store procedure Eliminar Usuario
                string cmd = String.Format("EXEC Eliminar_Usuario '{0}'", ID);

                MessageBox.Show("El Usuario se elimino de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Utilidades.Ejecutar(cmd);
                dataGridView1.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa", CadenaBD).Tables[0];
                Limpiar();
            
        }
        #endregion
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere eliminar este usuario", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (TxtID_Usuario.Text == "")
                {
                    errorProvider1.SetError(TxtID_Usuario, "No se admite campos vacios");
                }
                else
                {
                    try
                    {

                        Eliminar_Usuario(TxtID_Usuario.Text);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void Limpiar()
        {
            TxtID_Usuario.Text = "";
            TxtNombre.Text = "";
            TxtCedula.Text = "";
            TxtCorreo.Text = "";
            TxtDireccion.Text = "";
            TxtTelefono.Text = "";
            pictureBox1.ImageLocation = "";

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                Obtener_DatosDGV();
                BtnModificar.Enabled = true;
            }

            catch(Exception error) {
                MessageBox.Show("Error" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Archivos de Imagen|*.jpg";
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                /// Si esto se cumple, capturamos la propiedad File Name y la guardamos en el control
                direccion_Imagen = BuscarImagen.FileName;
               
                this.pictureBox1.ImageLocation = direccion_Imagen;
          
                //Pueden usar tambien esta forma para cargar la Imagen solo activenla y comenten la linea donde se cargaba anteriormente 


            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
   
}
