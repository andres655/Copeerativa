using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll_LibreriaClase;
using System.Windows.Forms;


namespace CooperativaCoop
{
    public partial class Login : Form
    {
        public static string Nombre_Empleado="";
        public Login()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            //envía una alerta si hay campos vacios
            if (TxtUsuario.Text == "" || TxtContrasena.Text == "")
            {
                errorProvider1.SetError(TxtContrasena, "No se admite campos vacios");
            }
            else
            {
                try
                {

                    Validar_Usuario();
                    this.Hide();

                }

                catch (Exception error)
                {
                    MessageBox.Show("Usuario incorrecto " + Environment.NewLine + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Validar_Usuario()
        {
            //busca en la base de datos 
            string cmd = string.Format("select Usuario_Empleado, Contraseña,Nombre_Empleado from Empleado where Usuario_Empleado = '{0}' and Contraseña = '{1}'",TxtUsuario.Text,TxtContrasena.Text);
           
            DataSet Ds = Utilidades.Ejecutar(cmd);

            string contraseña = Ds.Tables[0].Rows[0]["Contraseña"].ToString();
            string Usuario = Ds.Tables[0].Rows[0]["Usuario_Empleado"].ToString();
            
            if (TxtContrasena.Text == contraseña && TxtUsuario.Text == Usuario)
            {

               Nombre_Empleado= Ds.Tables[0].Rows[0]["Nombre_Empleado"].ToString();
                //abrir formulario MDI
                MDIParent1 m = new MDIParent1();
                m.Show();
                
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecto","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Se envió su nueva contraseña a su correo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }
    }
}
