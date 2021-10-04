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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

       
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            Application.Exit();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.MdiParent = this;
            usuario.Show();
        }

        private void cuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Cuenta cuenta = new Cuenta();
            cuenta.MdiParent = this;

            cuenta.Show();
        }

        private void agregarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Prestamo prestamo = new Prestamo();
            prestamo.MdiParent = this;

            prestamo.Show();
        }

        private void historialPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Historila_Prestamo historila_Prestamo = new Historila_Prestamo();
            historila_Prestamo.MdiParent = this;
            historila_Prestamo.Show();
        }

        private void tipoPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tipo_Prestamo tipo_Prestamo = new Tipo_Prestamo();
            tipo_Prestamo.MdiParent = this;
            tipo_Prestamo.Show();
        }

        private void tipoTrasancionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tipo_Trasancion tipo_Trasancion = new Tipo_Trasancion();
           tipo_Trasancion.MdiParent = this;
            tipo_Trasancion.Show();
        }

        private void tipoCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tipo_Cuenta tipo_Cuenta = new Tipo_Cuenta();
            tipo_Cuenta.MdiParent = this;
            tipo_Cuenta.Show();
        }

        private void transaccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_Transaciones registro_Transaciones = new Registro_Transaciones();
           registro_Transaciones.MdiParent = this;
            registro_Transaciones.Show();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            this.Text += Login.Nombre_Empleado;
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Agregar_Empleado agregar_Empleado = new Agregar_Empleado();
            agregar_Empleado.MdiParent = this;
            agregar_Empleado.Show();
        }

        private void depositoRetiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Retirar_Padre retirar_Padre = new Retirar_Padre();
            retirar_Padre.MdiParent = this;
            retirar_Padre.Show();
        }

        private void MDIParent1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
