using Dll_LibreriaClase;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;


namespace CooperativaCoop
{
    public partial class Historila_Prestamo : Form
    {
        public int Cuotas_Pagada;
        private string ID_Transacion;
        public Historila_Prestamo()
        {
            InitializeComponent();
        }
        #region variables 
        float cuota_fija;
        int ID_Cuenta;
        DateTime Fecha;
        bool Imprimir_MasPaginas = false;
        int fila = 0;
        int Pagina_Imprimir = 0;
        int Maximo_Pagina_X_Hoja = 35;
#endregion

        private void Historila_Prestamo_Load(object sender, EventArgs e)
        {

        }
        public void Calcular_Neto()
        {
            int Tiempo;
            double Neto;
            double Monto;
            double Cuota;


            // double TotalP;
            double Gasto;
            // int C_Cuota;
            // int Tiemp;

            // double DescPret;


            // calulo el monto del prestamo
            //  Gasto = double.Parse(this.textPorciento.Text);

            Monto = double.Parse(this.TxtMonto.Text);
            Tiempo = Convert.ToInt32(this.TxtNCuotas.Text);
            Cuota = cuota_fija;
            Neto = double.Parse(this.TxtMonto.Text);



            //tasa de interes



            // calcula el 2% de de intere
            Gasto = (Monto);

            //this.TxtGasto.Text = string.Format("{0:#,#.00}", Convert.ToDecimal(this.TxtGasto.Text));
            //caulo el nesto a pagar
            // TotalP = (Mont - (porc));
            Neto = (Cuota * Tiempo);
            this.TxtMontoTotal.Text = Neto.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
            TxtTotal_Interes.Text = (Neto - double.Parse(TxtMonto.Text)).ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));



        }
        public void llenarDatosPrestamo(int ID_Prestamo)
        {


            DataSet Ds;
            string cmd = string.Format("SELECT * FROM Cuenta INNER JOIN Prestamo ON Cuenta.ID_Cuenta = Prestamo.ID_Cuenta inner join Usuario  on Usuario.ID_Usuario = Cuenta.ID_Usuario  where Prestamo.ID_Prestamo = '{0}' ", ID_Prestamo);
            Ds = Utilidades.Ejecutar(cmd);
            TxtCedula.Text = Ds.Tables[0].Rows[0]["Cedula"].ToString();
            ID_Cuenta = int.Parse(Ds.Tables[0].Rows[0]["ID_Cuenta"].ToString());
            TxtCorreo.Text = Ds.Tables[0].Rows[0]["Correo"].ToString();
            TxtNombre.Text = Ds.Tables[0].Rows[0]["Nombre_Usuario"].ToString();
            TxtTelefono.Text = Ds.Tables[0].Rows[0]["Telefono"].ToString();
            TxtDireccion.Text = Ds.Tables[0].Rows[0]["Direccion"].ToString();
            TxtMonto.Text = Ds.Tables[0].Rows[0]["Monto"].ToString();
            TxtTasa_Interes.Text = Ds.Tables[0].Rows[0]["tasa"].ToString();
            cuota_fija =(float) Math.Round( double.Parse(Ds.Tables[0].Rows[0]["cuota_fija"].ToString()),0);

            TxtMonto_Por_Cuotas.Text = cuota_fija.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
            TxtNCuotas.Text = Ds.Tables[0].Rows[0]["Periodo"].ToString();
            Cuotas_Pagada = int.Parse(Ds.Tables[0].Rows[0]["CuotaPagada"].ToString());
            TxtNCuotasPagar.Text = (Cuotas_Pagada + 1).ToString();
            DateTime Fecha_Inicio_Pago = DateTime.Parse(Ds.Tables[0].Rows[0]["Fecha_Inicio_Pago"].ToString());
            TxtFecha_Limita_Pago.Text = Fecha_Inicio_Pago.AddMonths(Cuotas_Pagada).AddDays(7).ToString("D", CultureInfo.CreateSpecificCulture("es-DO"));
            TxtImporte_Pagar.Text = cuota_fija.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
            Fecha = DateTime.Parse(Ds.Tables[0].Rows[0]["Fecha"].ToString());
            pictureBox1.ImageLocation = Ds.Tables[0].Rows[0]["Imagen"].ToString();


            if (Cuotas_Pagada >= int.Parse(TxtNCuotas.Text))
            {
                LbEstado.Text = "Completado";
                LbEstado.ForeColor = System.Drawing.Color.Green;
                BtnPagar.Enabled = false;
            }
            else
            {
                LbEstado.Text = "Pendiente";
                LbEstado.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPrestamo buscarPrestamo = new BuscarPrestamo();
            buscarPrestamo.Show();

            this.Close();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            llenarDatosPrestamo(int.Parse(TxtBuscar.Text));
            GenerarTabla();
            Calcular_Neto();

        }
        public void GenerarTabla()
        {

            double PRESTAMO = double.Parse(TxtMonto.Text);//Monto del prestamo
            Int32 MESES = int.Parse(TxtNCuotas.Text);// tiempo del prestamo en meses
            double TIPO = double.Parse(TxtTasa_Interes.Text); // interes

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
            FFecha = Fecha.AddMonths(1);
            //   for (int tiempo1 = 0; tiempo1 <= 12; tiempo1++)
            // for (int tiempo1 = 0; tiempo1 <= tiempo; tiempo1++)
            //crea un objeto datateble para la datagridview
            DataTable dt = new DataTable();
            dt.Columns.Add("Periodo");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Cuota");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Debito");
            dt.Columns.Add("Interes");
            dt.Columns.Add("Saldo_Final");



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
                row["Fecha"] = FFecha.AddMonths(I - 1).Date.ToString("dd-MM-yyyy");
                row["Cuota"] = CUOTA.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
                if (Cuotas_Pagada >= I)
                {
                    row["Estado"] = "Completo";

                    dataGridView1.Columns["Estado"].DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    if (Cuotas_Pagada == I + 1 && DateTime.Now>= FFecha.AddMonths(I - 1).Date)
                    {
                        row["Estado"] = "Atrasado";
                        dataGridView1.Columns["Estado"].DefaultCellStyle.ForeColor = System.Drawing.Color.Yellow;
                        Agregar_retencion(int.Parse(TxtBuscar.Text), FFecha.AddMonths(I- 1).Date, cuota_fija);
                    }
                    else
                    {
                        row["Estado"] = "Pendiente";
                        dataGridView1.Columns["Estado"].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                      
                    }
                }
                row["Debito"] = TCUOTAS.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
                row["Interes"] = INTERESE.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));
                row["Saldo_Final"] = SALDOFINAL.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));

                dt.Rows.Add(row);
              
                continue;
            }
           

        }


        private void BtnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Seguro que quieres registrar este pago?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cuotas_Pagada++;
                    DataSet Ds;
                    string cmd = string.Format("update Prestamo SET CuotaPagada = {0} WHERE ID_Prestamo = {1} ", Cuotas_Pagada, int.Parse(TxtBuscar.Text));
                    Ds = Utilidades.Ejecutar(cmd);
                    MessageBox.Show("Operacion realizada con exito");
                    //agrega una trasancion a la cuenta
                    Operar_Trasancion operar_Trasancion = new Operar_Trasancion();
                    operar_Trasancion.Realizar_Trasancion(ID_Cuenta, 1, cuota_fija, "Se realizo pago a Prestamo");
                   
                     cmd = string.Format("select *from Transacion order by ID_Transacion desc");
                    Ds = Utilidades.Ejecutar(cmd);
                   ID_Transacion = Ds.Tables[0].Rows[0]["ID_Transacion"].ToString();

                    imprimir_Recibo();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }
       private void Agregar_retencion(int ID_Prestamo, DateTime Fecha_Pago,float Cuota_Fija)
        {
            try
            {
               const double Porcentaje_Retencion = 0.02;
              int Dias_Atrasados =  (Fecha_Pago - DateTime.Now).Days;
               float retencion = (cuota_fija * (float)Porcentaje_Retencion) * Dias_Atrasados;//multiplica el 2% de la cuota fija y la multiplica por los dias atrasados
                retencion = (float)(Math.Round((double)retencion, 0));
                string mensaje = string.Format("Este Prestamo está atrasado con {0} dias, tiene  una mora acumulada de:$RD{1}.00 ", Dias_Atrasados, retencion);
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    string cmd = string.Format("update Prestamo set Retencion = {0} where ID_Prestamo = {1} ", retencion, ID_Prestamo);
                   Utilidades.Ejecutar(cmd);

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }
        private void BtnDescargar_Click(object sender, EventArgs e)
        {
            imprimir();

        }
        public void Imprimir_Recibo(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float Monto_Pagado = cuota_fija * Cuotas_Pagada;
            string Monto_P = Monto_Pagado.ToString("C2", CultureInfo.CreateSpecificCulture("es-DO"));

            Font font = new Font("Arial", 24, FontStyle.Bold);
            int ancho = 500;
            int y = 10;
            int x = 10;

            e.Graphics.DrawString("Nombre de Cooperativa  ", font, Brushes.Black, new RectangleF(200, y += 40, ancho, 80));
            Font Subfont = new Font("Arial", 14, FontStyle.Italic);
            e.Graphics.DrawString("Av.Duarte, Bonao,Republica Dominicana ", Subfont, Brushes.Black, new RectangleF(215, y += 40, ancho, 80));
            e.Graphics.DrawString("Tel.829-296-7569 ", Subfont, Brushes.Black, new RectangleF(215, y += 40, ancho, 80));
            Font Pfont = new Font("Arial", 16, FontStyle.Italic);
            e.Graphics.DrawString(" ", Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            for (int i = 0; i < 100; i++)
            {
                e.Graphics.DrawString("-", Pfont, Brushes.Black, new RectangleF(x += 10, y += 0, ancho, 80));
            }
            e.Graphics.DrawString("No.Recibo: "+ID_Transacion, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            e.Graphics.DrawString("Socio: " + TxtNombre.Text, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            e.Graphics.DrawString("Cedula: " + TxtCedula.Text, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            e.Graphics.DrawString("Telefono: " + TxtTelefono.Text, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            e.Graphics.DrawString("Direccion: " + TxtDireccion.Text, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            x = 10;
            e.Graphics.DrawString(" ", Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            for (int i = 0; i < 100; i++)
            {
                e.Graphics.DrawString("-", Pfont, Brushes.Black, new RectangleF(x += 10, y += 0, ancho, 80));
            }
            e.Graphics.DrawString("Recibo de ingreso", Subfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            e.Graphics.DrawString("Prestamo: " + TxtBuscar.Text, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            e.Graphics.DrawString("Fecha: " + DateTime.Now, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            e.Graphics.DrawString("Monto Pagado: " + TxtMonto_Por_Cuotas.Text, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            e.Graphics.DrawString("Total Pagado: " + Monto_P, Pfont, Brushes.Black, new RectangleF(50, y +=40, ancho, 80));
            e.Graphics.DrawString("Monto a pagar " + TxtMontoTotal.Text, Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            e.Graphics.DrawString("Periodo: Mensual ", Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            x = 10;
            e.Graphics.DrawString(" ", Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            for (int i = 0; i < 100; i++)
            {
                e.Graphics.DrawString("-", Pfont, Brushes.Black, new RectangleF(x += 10, y += 0, ancho, 80));
            }
            
            e.Graphics.DrawString("Fecha Recibo: " + DateTime.Now.ToString(), Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            x = 10;
            e.Graphics.DrawString(" ", Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
            for (int i = 0; i < 100; i++)
            {
                e.Graphics.DrawString("-", Pfont, Brushes.Black, new RectangleF(x += 10, y += 0, ancho, 80));
            }
            e.Graphics.DrawString("Comentario ", Pfont, Brushes.Black, new RectangleF(50, y += 40, ancho, 80));
        }
        public void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            const int DGV_ALTO = 30;
            int left = e.MarginBounds.Left, top = 40;

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
                if (Imprimir_MasPaginas == false || fila >= Maximo_Pagina_X_Hoja * Pagina_Imprimir)
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


                    if (fila == Maximo_Pagina_X_Hoja * (Pagina_Imprimir + 1))
                    {
                        Imprimir_MasPaginas = false;
                    }
                }

                fila++;//cuenta las cantidades filas escrita

                //imprime otra hoja si sobrepasa la cantidad de fila por hoja
                if (fila >= Maximo_Pagina_X_Hoja && Imprimir_MasPaginas == false)
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
                    return;

                }

            }

            Imprimir_MasPaginas = false;
            fila = 0;
            Maximo_Pagina_X_Hoja = 23;

        }
        public void imprimir_Recibo()
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("MyPaper", 600, 800);
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.Margins = new Margins(60, 40, 20, 20);
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage +=Imprimir_Recibo;
            printPreviewDialog1.Document = printDocument1;
            printDialog1.Document = printDocument1;
            //printDialog1.ShowDialog();
            printPreviewDialog1.ShowDialog();
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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
       
    } 

  
