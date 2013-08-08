//////////////////////////////////////////////////////////////////////////////////
// Creadores:
// - Patricio Espinoza Salgado
// - Joel Mejias Morales
// - Fabian Cordobvez Arriagada
// - Manuel Irarrazabal Galvez
// - Valery Soto Lastra
//////////////////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WiimoteLib;
using System.Windows.Forms.DataVisualization.Charting;
using System.Media;

namespace WiimoteTest
{
	public partial class WiimoteInfo : UserControl
	{
		private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);
		private delegate void UpdateExtensionChangedDelegate(WiimoteExtensionChangedEventArgs args);
       
        // Definiendo la variable de sonido "alarma".
        System.Media.SoundPlayer alarma = new System.Media.SoundPlayer();


		private Bitmap b = new Bitmap(256, 192, PixelFormat.Format24bppRgb);
		private Graphics g;
		private Wiimote mWiimote;

        private DateTime minValue, maxValue;
        private Random random = new Random();

        
		public WiimoteInfo()
		{
			InitializeComponent();
			g = Graphics.FromImage(b);
		}

		public WiimoteInfo(Wiimote wm) : this()
		{
			mWiimote = wm;
		}

		public void UpdateState(WiimoteChangedEventArgs args)
		{
			BeginInvoke(new UpdateWiimoteStateDelegate(UpdateWiimoteChanged), args);
		}

		public void UpdateExtension(WiimoteExtensionChangedEventArgs args)
		{
			BeginInvoke(new UpdateExtensionChangedDelegate(UpdateExtensionChanged), args);
		}

		private void chkLED_CheckedChanged(object sender, EventArgs e)
		{
			mWiimote.SetLEDs(chkIndicador.Checked,false,false,false);
		}

		private void chkRumble_CheckedChanged(object sender, EventArgs e)
		{
			mWiimote.SetRumble(false);
		}

		private void UpdateWiimoteChanged(WiimoteChangedEventArgs args)
		{
			WiimoteState ws = args.WiimoteState;

            minValue = DateTime.Now;
            maxValue = minValue.AddSeconds(30);

            DateTime timeStamp = DateTime.Now;

            float Magnitud = ((Math.Abs(ws.AccelState.Values.X) * 10) + 1);
            float battlvl = ws.Battery;

            // Asigando el sonido a la variable alarma.
            alarma.Stream = Properties.Resources.alarma;

			
            // Magnitud maxima.
            if (Magnitud >= Convert.ToDouble(lblMagMax.Text) && Magnitud <= 10)
             {
                lblMagMax.Text = Magnitud.ToString("n1");
                lblTime.Text = timeStamp.ToString("hh:mm:ss");
                lblDate.Text = timeStamp.ToString("dd/MM/yyyy");
             }

            // Magnitud Actual.
            if (Magnitud <= 10)
            {
                lblMagAct.Text = Magnitud.ToString("n1");
            }

            // Activar alarma al sobrepasar el nivel seleccionado.
             if (chkAlarm.Checked && (Magnitud >= Convert.ToDouble(numUpDwn.Value)))
             {
                  alarma.Play();
                  lblMagAct.ForeColor = Color.Red; // Cambia color del label a rojo.
             }
             else
             {
                 lblMagAct.ForeColor = Color.Black; // Cambia color del label a negro.
             }

            // Simular alarma con boton A.
             if (ws.ButtonState.A == true)
             {
                 alarma.Play();
             }
            

            // Agregar nuevo punto al charts.
            chart1.Series[0].Points.AddXY(timeStamp.ToOADate(), ws.AccelState.Values.X*10);

            // Remover puntos antiguos mas de x segundos, donde x (double)(x).
            double removeBefore = timeStamp.AddSeconds((double)(10) * (-1)).ToOADate();

            // Remover valores antiguos y mantener un numero constante de valores
            while (chart1.Series[0].Points[0].XValue < removeBefore)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }

            chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.Series[0].Points[0].XValue).AddSeconds(15).ToOADate();

            chart1.Invalidate();

                //Resaltar colores en la escala.
                if (Magnitud <= 2)
                {
                    lblMag2.ForeColor = Color.Red; // Cambia color del label a rojo.
                }
                else
                {
                    lblMag2.ForeColor = Color.Black; // Cambia color del label a negro.
                }


                if (Magnitud > 2 && Magnitud <= 3)
                {
                    lblMag3.ForeColor = Color.Red; // Cambia color del label a rojo.
                }
                else
                {
                    lblMag3.ForeColor = Color.Black; // Cambia color del label a negro.
                }


                if (Magnitud > 3 && Magnitud <= 4)
                {
                    lblMag4.ForeColor = Color.Red; // Cambia color del label a rojo.
                }
                else
                {
                    lblMag4.ForeColor = Color.Black; // Cambia color del label a negro.
                }


                if (Magnitud > 4 && Magnitud <= 5)
                {
                    lblMag5.ForeColor = Color.Red; // Cambia color del label a rojo.
                }
                else
                {
                    lblMag5.ForeColor = Color.Black; // Cambia color del label a negro.
                }


                if (Magnitud > 5 && Magnitud <= 6)
                {
                    lblMag6.ForeColor = Color.Red; // Cambia color del label a rojo.
                }
                else
                {
                    lblMag6.ForeColor = Color.Black; // Cambia color del label a negro.
                }


                if (Magnitud > 6 && Magnitud <= 7)
                {
                    lblMag7.ForeColor = Color.Red; // Cambia color del label a rojo.
                }
                else
                {
                    lblMag7.ForeColor = Color.Black; // Cambia color del label a negro.
                }


                if (Magnitud > 7 && Magnitud <= 8)
                {
                    lblMag8.ForeColor = Color.Red; // Cambia color del label a rojo.
                }
                else
                {
                    lblMag8.ForeColor = Color.Black; // Cambia color del label a negro.
                }


                if (Magnitud > 8 && Magnitud <= 9)
                {
                    lblMag9.ForeColor = Color.Red; // Cambia color del label a rojo.
                }
                else
                {
                    lblMag9.ForeColor = Color.Black; // Cambia color del label a negro.
                }


                if (Magnitud > 9)
                {
                    lblMag10.ForeColor = Color.Red; // Cambia color del label a rojo.
                }
                else
                {
                    lblMag10.ForeColor = Color.Black; // Cambia color del label a negro.
                }


            //Simular Bateria
                if (battlvl > 0 && battlvl <= 10 )
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = false;
                }

                if (battlvl > 10 && battlvl <= 30)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = false;
                }

                if (battlvl > 30 && battlvl <= 50)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = false;
                }

                if (battlvl > 50 && battlvl <= 70)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = false;
                }

                if (battlvl > 70 && battlvl <= 90)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = false;
                }

                if (battlvl > 70 && battlvl <= 90)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = true;
                }


            //Cerrar aplicacion con el boton "Home"
            if (ws.ButtonState.Home == true)
            {
                Application.Exit();
            }

			chkIndicador.Checked = ws.LEDState.LED1;
            
			g.Clear(Color.Black);

             

			if(ws.IRState.IRSensors[0].Found && ws.IRState.IRSensors[1].Found)
				g.DrawEllipse(new Pen(Color.Green), (int)(ws.IRState.RawMidpoint.X / 4), (int)(ws.IRState.RawMidpoint.Y / 4), 2, 2);


            lblBattery.Text = battlvl.ToString("0\\%");

			lblDevicePath.Text = "Ubicacion Dispositivo: " + mWiimote.HIDDevicePath;
		}

		private void UpdateIR(IRSensor irSensor, Label lblNorm, Label lblRaw, CheckBox chkFound, Color color)
		{
			chkFound.Checked = irSensor.Found;

			if(irSensor.Found)
			{
				lblNorm.Text = irSensor.Position.ToString() + ", " + irSensor.Size;
				lblRaw.Text = irSensor.RawPosition.ToString();
				g.DrawEllipse(new Pen(color), (int)(irSensor.RawPosition.X / 4), (int)(irSensor.RawPosition.Y / 4),
							 irSensor.Size+1, irSensor.Size+1);
			}
		}

		private void UpdateExtensionChanged(WiimoteExtensionChangedEventArgs args)
		{

		}

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblMagMax.Text = 0.ToString();
            lblTime.Text = "00:00:00";
            lblDate.Text = "00/00/00";
        }

		public Wiimote Wiimote
		{
			set { mWiimote = value; }
		}

	}
}
