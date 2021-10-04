using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dll_LibreriaClase;

namespace CooperativaCoop
{
    public partial class Prestamo : Form
    {
        double Cuota_F;
        private string CadenaUsuario = "select ID_Usuario, Nombre_Usuario  from Usuario";
        bool Imprimir_MasPaginas = false;
        int fila = 0;
        int Pagina_Imprimir=0;
        int Maximo_Pagina_X_Hoja = 23;
        //string CadenaCuenta = string.Format("select ID_Cuenta,tipo from Cuenta where ID_Usuario='{0}'",2);

        public Prestamo()
        {
            InitializeComponent();
        }

        private void Prestamo_Load(object sender, EventArgs e)
        {
            try
            {
                ObtenerDatosUsuario(CadenaUsuario, "Nombre_Usuario", "ID_Usuario");


            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ObtenerDatosUsuario(string CadenaBd, string Display, string valuemember)
        {

            this.CbbUsuario.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa", CadenaBd).Tables[0];
            this.CbbUsuario.DisplayMember = Display;
            this.CbbUsuario.ValueMember = valuemember;
        }
        public void ObtenerDatosCuentas(string CadenaBd, string Display, string valuemember)
        {

            //this.CbbCuenta.DataSource = ObtenerDGV.LlenarCuenta("Cooperativa", CadenaBd).Tables.Add("Cuenta","ID_Cuenta");
            this.CbbCuenta.DataSource = ObtenerDGV.LlenarDataGV("Cooperativa", CadenaBd).Tables[0];
            this.CbbCuenta.DisplayMember = Display;
            this.CbbCuenta.ValueMember = valuemember;

        }

        public void calcuprestamo()
        {
            double Monto, tiempo, tasa;


            Monto = double.Parse(TxtMonto.Text);
            tiempo = double.Parse(this.TxtTiempo.Text);
            tasa = double.Parse(this.TxtTasa.Text) - double.Parse(TxtFondoEventualidad.Text);
            tasa = tasa / 100 / 12;


            tiempo = tiempo * (-1);
            double tasab = (1 + tasa);
            double Resultado = (1 - Math.Pow(tasab, tiempo)) / tasa;


            //Cuota Fija = Monto / A;
            Cuota_F = Monto / Resultado;

            this.TxtCuotaMensual.Text = Cuota_F.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));

            /*double Neto = ((Cuota_F * tiempo)*(-1));
            this.TxtNetoPagar.Text = Neto.ToString();
            this.TxtNetoPagar.Text = string.Format("{0:#,#.00}", Convert.ToDecimal(this.TxtNetoPagar.Text));*/
            DtpFecha_Primer_Pago.Value = DtpFecha_Solicitud.Value.AddMonths(1);
            DtpFecha_Vence.Value = DtpFecha_Primer_Pago.Value.AddMonths(Convert.ToInt32(tiempo * -1));

        }

        public void Calcular_Neto()
        {
            int Tiempo;
            double Neto;
            double Monto;
            double Cuota;
            float tasa;
            // double TotalP;
            double Gasto;
            // int C_Cuota;
            // int Tiemp;
            float tasa2;
            // double DescPret;


            // calulo el monto del prestamo
            //  Gasto = double.Parse(this.textPorciento.Text);

            Monto = double.Parse(this.TxtMonto.Text);
            Tiempo = Convert.ToInt32(this.TxtTiempo.Text);
            Cuota = double.Parse(Cuota_F.ToString());
            //Neto = double.Parse(this.TxtNetoPagar.Text);



            //tasa de interes
            tasa = float.Parse(this.TxtTasa.Text);
            tasa2 = float.Parse(this.TxtFondoEventualidad.Text);



            // calcula el 2% de de intere
            Gasto = (Monto * (tasa2) / Convert.ToInt32(100));
            this.TxtGasto.Text = Gasto.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
            //this.TxtGasto.Text = string.Format("{0:#,#.00}", Convert.ToDecimal(this.TxtGasto.Text));
            //caulo el nesto a pagar
            // TotalP = (Mont - (porc));
            Neto = (Cuota * Tiempo - Gasto);
            this.TxtNetoPagar.Text = Neto.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));



        }

        private void Calcular_Click(object sender, EventArgs e)
        {
            //llama al error provider si hay campos en blanco
            if (TxtMonto.Text == "" || TxtTiempo.Text == "" || TxtTasa.Text == "")
            {

                errorProvider1.SetError(TxtTiempo, "No se admite campos vacios");
                errorProvider1.SetError(TxtMonto, "No se admite campos vacios");
                errorProvider1.SetError(TxtTasa, "No se admite campos vacios");
            }
            else if (TxtTiempo.Text == "0" || TxtTasa.Text == "0")
            {

                errorProvider1.SetError(TxtTiempo, "el tiempo a pagar no puede ser cero");
                errorProvider1.SetError(TxtTasa, "la tasa de interes no puede ser 0 a pagar no puede ser cero");
            }
            else
            {
                calcuprestamo();
                GenerarTabla();
                Calcular_Neto();
            }



        }

        public void GenerarTabla()
        {
            double PRESTAMO = double.Parse(TxtMonto.Text);//Monto del prestamo
            Int32 MESES = int.Parse(TxtTiempo.Text);// tiempo del prestamo en meses
            double TIPO = double.Parse(TxtTasa.Text) - double.Parse(TxtFondoEventualidad.Text); // interes

            TIPO = TIPO / 100 / 12;

            double Resultado = (1 - Math.Pow(1 + TIPO, MESES * -1)) / TIPO;

            //Cuota Fija = Monto / A;
            double CUOTA = PRESTAMO / Resultado;
            //  double CUOTA= Convert.ToSingle(this.dtgPrestamo.CurrentRow.Cells[5].Value.ToString()); // prestamo


            ////--------------------------------------------------------------------------------------
            //  this.dtgPrestamo.CurrentRow .Cells [10].Value  = CUOTA.ToString("0:#,#.00");

            // int Periodo = 0;
            double INTERESE = 0;
            double TINTERESES = 0;//tasa de interes
            double CAPITAL = 0;
            double TAMORTIZACION = 0;
            double TCUOTAS = 0;
            double SALDOINICIAL = 0;
            double ACUMULADOINT = 0;//interes acumulado
            double SALDOFINAL = PRESTAMO;
            DateTime FFecha;
            FFecha = DateTime.Now.AddMonths(1);
            //   for (int tiempo1 = 0; tiempo1 <= 12; tiempo1++)
            // for (int tiempo1 = 0; tiempo1 <= tiempo; tiempo1++)
            //crea un objeto datateble para la datagridview
            DataTable dt = new DataTable();
            dt.Columns.Add("Periodo");
            dt.Columns.Add("Cuota");
            dt.Columns.Add("Fecha");
            //dt.Columns.Add("Saldo_Inicial");
            //dt.Columns.Add("Debito");
            dt.Columns.Add("Interes");
            dt.Columns.Add("Capital");
           dt.Columns.Add("Balance");
            //dt.Columns.Add("Interes_Acumulado");
           // dt.Columns.Add("Amortizacion");
            dataGridView1.DataSource = dt;
            /*DataGridViewCellStyle currencyCellStyle = new DataGridViewCellStyle();
            currencyCellStyle.Format = "C";*/
            /* dataGridView1.Columns["Saldo_Inicial"].DefaultCellStyle
                                                    .FormatProvider = CultureInfo.GetCultureInfo("en-US");
             dataGridView1.Columns["Saldo_Inicial"].DefaultCellStyle.Format = string.Format("C");
             dataGridView1.Columns["Saldo_Inicial"].ValueType = typeof(Double);
             dataGridView1.Columns["Saldo_Inicial"].DefaultCellStyle.BackColor = Color.Blue;
             */
            dataGridView1.Columns["Fecha"].DefaultCellStyle.Format = "yyyy-MM-dd";






            dataGridView1.DataSource = dt;
            for (int I = 1; I <= MESES; I++)
            {
                INTERESE = Math.Round(SALDOFINAL * TIPO, 2); //'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                TINTERESES += (INTERESE); //'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                ACUMULADOINT += (INTERESE);  /// I
                SALDOINICIAL = (SALDOFINAL);// INTDERES ACUMULADO
                CAPITAL = Math.Round(CUOTA - INTERESE, 2); //) 'DIFERENCIA ENTRE CUOTA Y LOS INTERESES DEL MES
                TAMORTIZACION += (CAPITAL); // 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                SALDOFINAL -= (CAPITAL); // 'VA REBAJANDO LA PART.E DE AMORTIZACION DE CADA CUOTA
                TCUOTAS += (CUOTA);// 'AC


                //crea una nueva fila en el datagriview
                DataRow row = dt.NewRow();

                row["Periodo"] = I;
                row["Cuota"] = CUOTA.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
                row["Fecha"] = FFecha.AddMonths(I - 1).Date.ToString("dd-MM-yyyy");
              //  row["Saldo_Inicial"] = SALDOINICIAL.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
              // row["Debito"] = TCUOTAS.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
                 row["Interes"] = INTERESE.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
                row["Capital"] = CAPITAL.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
                row["Balance"] = SALDOFINAL.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
                //row["Interes_Acumulado"] = TINTERESES.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
               // row["Amortizacion"] = TAMORTIZACION.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));

                dt.Rows.Add(row);

                continue;
            }
        }

        private void CbbUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string CadenaCuenta = string.Format("select ID_Cuenta from Cuenta where ID_Usuario='{0}'", int.Parse(CbbUsuario.SelectedValue.ToString()));

            ObtenerDatosCuentas(CadenaCuenta, "ID_Cuenta", "ID_Cuenta");
        }

        private void CbbCuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //activar el boton de agregar 
            BtnAgregar_Prestamo.Enabled = true;
        }

        private void BtnAgregar_Prestamo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere realizar este prestamo", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    //llamar al store procedure  Agregar Prestamo
                    string cmd = String.Format("EXEC Agregar_Prestamo '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'",
                                 int.Parse(CbbCuenta.Text), float.Parse(TxtMonto.Text), float.Parse(TxtTasa.Text), "Normal", int.Parse(TxtTiempo.Text),
                             Cuota_F.ToString(), DateTime.Now, TxtDescripcion.Text, "Activo", 0, DtpFecha_Primer_Pago.Value,Login.Nombre_Empleado) ;

                   Utilidades.Ejecutar(cmd);
                    Operar_Trasancion operar_Trasancion = new Operar_Trasancion();
                    operar_Trasancion.Realizar_Trasancion(int.Parse(CbbCuenta.Text), 1006, float.Parse(TxtMonto.Text), TxtDescripcion.Text);

                    MessageBox.Show("El Prestamo se agregro de manera sastifatoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception error)
                {
                    MessageBox.Show("Error" + error);
                }


                imprimir();
            }
        }

        public void imprimir()
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir;
            printPreviewDialog1.Document = printDocument1;
            printDialog1.Document = printDocument1;
            //printDialog1.ShowDialog();
            printPreviewDialog1.ShowDialog();
        }
        public void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
          


            Font font = new Font("Arial", 24, FontStyle.Bold);
            int ancho = 500;
            int y = 10;
            int x = 10;
          
            //int x = -100;
            // int XRow = -100;
            //RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            //GraphicsUnit units = GraphicsUnit.Pixel;
            if (Imprimir_MasPaginas != true)
            {
                e.Graphics.DrawString("Nombre de Cooperativa  ", font, Brushes.Black, new RectangleF(200, y += 40, ancho, 80));
                Font Subfont = new Font("Arial", 14, FontStyle.Italic);
                e.Graphics.DrawString("Av.Duarte, Bonao,Republica Dominicana ", Subfont, Brushes.Black, new RectangleF(215, y += 40, ancho, 80));
                e.Graphics.DrawString("Tabla de amortizacion ", font, Brushes.Black, new RectangleF(225, y += 20, ancho, 80));
                Font Pfont = new Font("Arial", 16, FontStyle.Italic);
                e.Graphics.DrawString(" " + DateTime.Now.ToString(), Pfont, Brushes.Black, new RectangleF(550, y += 40, ancho, 80));
                e.Graphics.DrawString("Socio: " + CbbUsuario.Text, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
                e.Graphics.DrawString("Cuenta: " + CbbCuenta.Text, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
                e.Graphics.DrawString("Fecha: " + DateTime.Now, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
                e.Graphics.DrawString("Monto: " + TxtMonto.Text, Pfont, Brushes.Black, new RectangleF(550, y += 0, ancho, 80));
                e.Graphics.DrawString("Periodo: Mensual ", Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
                e.Graphics.DrawString("Interes Anual:" + TxtTasa.Text + "%", Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
                e.Graphics.DrawString(" ", Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
                for (int i = 0; i < 100; i++)
                {
                    e.Graphics.DrawString("-", Pfont, Brushes.Black, new RectangleF(x += 10, y += 0, ancho, 80));
                }
            }
            const int DGV_ALTO = 30;
            int left = e.MarginBounds.Left, top = y += 40;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                e.Graphics.DrawString(col.HeaderText, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DeepSkyBlue, left, top);
                left += col.Width;

                if (col.Index < dataGridView1.ColumnCount - 1)
                    e.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dataGridView1.RowCount - 1) * DGV_ALTO);
            }
            left = e.MarginBounds.Left;
            e.Graphics.FillRectangle(Brushes.Black, left, top + 40, e.MarginBounds.Right - left, 3);
            top += 43;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //
                if (Imprimir_MasPaginas == false || fila >= Maximo_Pagina_X_Hoja*Pagina_Imprimir)
                {
                    e.HasMorePages = false;
                    if (row.Index == dataGridView1.RowCount - 1) break;

                    left = e.MarginBounds.Left;

                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        e.Graphics.DrawString(Convert.ToString(cell.Value), new Font("Segoe UI", 11), Brushes.Black, left, top + 4);
                        left += cell.OwningColumn.Width;
                    }
                    top += DGV_ALTO;
                    e.Graphics.DrawLine(Pens.Gray, e.MarginBounds.Left, top, e.MarginBounds.Right, top);

                    
                    if (fila== Maximo_Pagina_X_Hoja * (Pagina_Imprimir + 1))
                    {
                        Imprimir_MasPaginas = false;
                    }
                }

                fila++;//cuenta las cantidades filas escrita

                //imprime otra hoja si sobrepasa la cantidad de fila por hoja
                if (fila >= Maximo_Pagina_X_Hoja && Imprimir_MasPaginas==false )
                {
                    e.HasMorePages = true;
                    top = 50;
                    Imprimir_MasPaginas = true;
                    Pagina_Imprimir++;
                    fila = 0;
                    if (Pagina_Imprimir >= 2)
                    {
                        Maximo_Pagina_X_Hoja = 35;
                    }
               return ;
                    
                }
  
            }

            Imprimir_MasPaginas = false;
            fila = 0;
            Maximo_Pagina_X_Hoja = 23;

        }
    }
}
