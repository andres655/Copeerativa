
namespace CooperativaCoop
{
    partial class Prestamo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prestamo));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CbbUsuario = new System.Windows.Forms.ComboBox();
            this.TxtCuotaMensual = new System.Windows.Forms.MaskedTextBox();
            this.TxtMonto = new System.Windows.Forms.MaskedTextBox();
            this.TxtTiempo = new System.Windows.Forms.MaskedTextBox();
            this.TxtDescripcion = new System.Windows.Forms.RichTextBox();
            this.Calcular = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtGasto = new System.Windows.Forms.MaskedTextBox();
            this.TxtNetoPagar = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtTasa = new System.Windows.Forms.MaskedTextBox();
            this.TxtFondoEventualidad = new System.Windows.Forms.MaskedTextBox();
            this.DtpFecha_Solicitud = new System.Windows.Forms.DateTimePicker();
            this.DtpFecha_Primer_Pago = new System.Windows.Forms.DateTimePicker();
            this.DtpFecha_Vence = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.BtnAgregar_Prestamo = new System.Windows.Forms.Button();
            this.CbbCuenta = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 385);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(879, 276);
            this.dataGridView1.TabIndex = 0;
            // 
            // CbbUsuario
            // 
            this.CbbUsuario.FormattingEnabled = true;
            this.CbbUsuario.Location = new System.Drawing.Point(111, 78);
            this.CbbUsuario.Name = "CbbUsuario";
            this.CbbUsuario.Size = new System.Drawing.Size(170, 21);
            this.CbbUsuario.TabIndex = 2;
            this.CbbUsuario.SelectionChangeCommitted += new System.EventHandler(this.CbbUsuario_SelectionChangeCommitted);
            // 
            // TxtCuotaMensual
            // 
            this.TxtCuotaMensual.Location = new System.Drawing.Point(109, 227);
            this.TxtCuotaMensual.Name = "TxtCuotaMensual";
            this.TxtCuotaMensual.ReadOnly = true;
            this.TxtCuotaMensual.Size = new System.Drawing.Size(100, 20);
            this.TxtCuotaMensual.TabIndex = 3;
            this.TxtCuotaMensual.Text = "0";
            // 
            // TxtMonto
            // 
            this.TxtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMonto.ForeColor = System.Drawing.Color.Red;
            this.TxtMonto.Location = new System.Drawing.Point(109, 167);
            this.TxtMonto.Mask = "999999999";
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(100, 22);
            this.TxtMonto.TabIndex = 4;
            this.TxtMonto.Text = "0";
            this.TxtMonto.ValidatingType = typeof(int);
            // 
            // TxtTiempo
            // 
            this.TxtTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTiempo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtTiempo.Location = new System.Drawing.Point(109, 193);
            this.TxtTiempo.Mask = "999";
            this.TxtTiempo.Name = "TxtTiempo";
            this.TxtTiempo.Size = new System.Drawing.Size(100, 22);
            this.TxtTiempo.TabIndex = 6;
            this.TxtTiempo.Text = "1";
            this.toolTip1.SetToolTip(this.TxtTiempo, "Tiempo de pago en meses");
            this.TxtTiempo.ValidatingType = typeof(int);
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(166, 290);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(517, 96);
            this.TxtDescripcion.TabIndex = 7;
            this.TxtDescripcion.Text = "";
            // 
            // Calcular
            // 
            this.Calcular.Location = new System.Drawing.Point(735, 274);
            this.Calcular.Name = "Calcular";
            this.Calcular.Size = new System.Drawing.Size(132, 43);
            this.Calcular.TabIndex = 8;
            this.Calcular.Text = "Generar Tabla";
            this.Calcular.UseVisualStyleBackColor = true;
            this.Calcular.Click += new System.EventHandler(this.Calcular_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fecha de solicitud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre de Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Monto Solicitado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tiempo de pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cuota mensual";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Fecha primer pago";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Fecha_Vence";
            // 
            // TxtGasto
            // 
            this.TxtGasto.Location = new System.Drawing.Point(436, 94);
            this.TxtGasto.Name = "TxtGasto";
            this.TxtGasto.ReadOnly = true;
            this.TxtGasto.Size = new System.Drawing.Size(100, 20);
            this.TxtGasto.TabIndex = 18;
            this.TxtGasto.Text = "0";
            // 
            // TxtNetoPagar
            // 
            this.TxtNetoPagar.Location = new System.Drawing.Point(436, 120);
            this.TxtNetoPagar.Name = "TxtNetoPagar";
            this.TxtNetoPagar.ReadOnly = true;
            this.TxtNetoPagar.Size = new System.Drawing.Size(100, 20);
            this.TxtNetoPagar.TabIndex = 19;
            this.TxtNetoPagar.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(324, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Gasto (Eventualidad)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Neto a pagar";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(623, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Tasas de interes anual %";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(623, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Fondo de enventualidad%";
            // 
            // TxtTasa
            // 
            this.TxtTasa.Location = new System.Drawing.Point(754, 87);
            this.TxtTasa.Name = "TxtTasa";
            this.TxtTasa.Size = new System.Drawing.Size(100, 20);
            this.TxtTasa.TabIndex = 24;
            this.TxtTasa.Text = "0";
            // 
            // TxtFondoEventualidad
            // 
            this.TxtFondoEventualidad.Location = new System.Drawing.Point(754, 120);
            this.TxtFondoEventualidad.Name = "TxtFondoEventualidad";
            this.TxtFondoEventualidad.Size = new System.Drawing.Size(100, 20);
            this.TxtFondoEventualidad.TabIndex = 25;
            this.TxtFondoEventualidad.Text = "0";
            // 
            // DtpFecha_Solicitud
            // 
            this.DtpFecha_Solicitud.Location = new System.Drawing.Point(111, 45);
            this.DtpFecha_Solicitud.Name = "DtpFecha_Solicitud";
            this.DtpFecha_Solicitud.Size = new System.Drawing.Size(200, 20);
            this.DtpFecha_Solicitud.TabIndex = 26;
            // 
            // DtpFecha_Primer_Pago
            // 
            this.DtpFecha_Primer_Pago.Location = new System.Drawing.Point(436, 25);
            this.DtpFecha_Primer_Pago.Name = "DtpFecha_Primer_Pago";
            this.DtpFecha_Primer_Pago.Size = new System.Drawing.Size(200, 20);
            this.DtpFecha_Primer_Pago.TabIndex = 27;
            // 
            // DtpFecha_Vence
            // 
            this.DtpFecha_Vence.Location = new System.Drawing.Point(436, 56);
            this.DtpFecha_Vence.Name = "DtpFecha_Vence";
            this.DtpFecha_Vence.Size = new System.Drawing.Size(200, 20);
            this.DtpFecha_Vence.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(374, 263);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 24);
            this.label12.TabIndex = 29;
            this.label12.Text = "Descipcion";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(215, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "*";
            this.toolTip1.SetToolTip(this.label13, "Los campos con *  son obligatorios");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(215, 193);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 20);
            this.label15.TabIndex = 32;
            this.label15.Text = "*";
            this.toolTip1.SetToolTip(this.label15, "los campos con * son obligatorios");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(860, 89);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 20);
            this.label16.TabIndex = 33;
            this.label16.Text = "*";
            this.toolTip1.SetToolTip(this.label16, "los campos con * son obligatorios");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(217, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 13);
            this.label14.TabIndex = 31;
            // 
            // BtnAgregar_Prestamo
            // 
            this.BtnAgregar_Prestamo.Enabled = false;
            this.BtnAgregar_Prestamo.Location = new System.Drawing.Point(735, 323);
            this.BtnAgregar_Prestamo.Name = "BtnAgregar_Prestamo";
            this.BtnAgregar_Prestamo.Size = new System.Drawing.Size(132, 43);
            this.BtnAgregar_Prestamo.TabIndex = 34;
            this.BtnAgregar_Prestamo.Text = "Agregar Prestamo";
            this.BtnAgregar_Prestamo.UseVisualStyleBackColor = true;
            this.BtnAgregar_Prestamo.Click += new System.EventHandler(this.BtnAgregar_Prestamo_Click);
            // 
            // CbbCuenta
            // 
            this.CbbCuenta.FormattingEnabled = true;
            this.CbbCuenta.Location = new System.Drawing.Point(113, 107);
            this.CbbCuenta.Name = "CbbCuenta";
            this.CbbCuenta.Size = new System.Drawing.Size(170, 21);
            this.CbbCuenta.TabIndex = 2;
            this.CbbCuenta.SelectionChangeCommitted += new System.EventHandler(this.CbbCuenta_SelectionChangeCommitted);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 110);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "No.Cuenta";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Prestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(879, 661);
            this.Controls.Add(this.BtnAgregar_Prestamo);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.DtpFecha_Vence);
            this.Controls.Add(this.DtpFecha_Primer_Pago);
            this.Controls.Add(this.DtpFecha_Solicitud);
            this.Controls.Add(this.TxtFondoEventualidad);
            this.Controls.Add(this.TxtTasa);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtNetoPagar);
            this.Controls.Add(this.TxtGasto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Calcular);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.TxtTiempo);
            this.Controls.Add(this.TxtMonto);
            this.Controls.Add(this.CbbCuenta);
            this.Controls.Add(this.TxtCuotaMensual);
            this.Controls.Add(this.CbbUsuario);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Prestamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestamo";
            this.Load += new System.EventHandler(this.Prestamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CbbUsuario;
        private System.Windows.Forms.MaskedTextBox TxtCuotaMensual;
        private System.Windows.Forms.MaskedTextBox TxtMonto;
        private System.Windows.Forms.MaskedTextBox TxtTiempo;
        private System.Windows.Forms.RichTextBox TxtDescripcion;
        private System.Windows.Forms.Button Calcular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox TxtGasto;
        private System.Windows.Forms.MaskedTextBox TxtNetoPagar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox TxtTasa;
        private System.Windows.Forms.MaskedTextBox TxtFondoEventualidad;
        private System.Windows.Forms.DateTimePicker DtpFecha_Solicitud;
        private System.Windows.Forms.DateTimePicker DtpFecha_Primer_Pago;
        private System.Windows.Forms.DateTimePicker DtpFecha_Vence;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button BtnAgregar_Prestamo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox CbbCuenta;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}