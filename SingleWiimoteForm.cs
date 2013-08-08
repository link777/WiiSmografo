//////////////////////////////////////////////////////////////////////////////////
// Creadores:
// - Patricio Espinoza Salgado
// - Joel Mejias Morales
// - Fabian Cordobvez Arriagada
// - Manuel Irarrazabal Galvez
// - Valery Soto Lastra
//////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using WiimoteLib;

namespace WiimoteTest
{
	public partial class SingleWiimoteForm : Form
	{
		Wiimote wm = new Wiimote();

		public SingleWiimoteForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			wiimoteInfo1.Wiimote = wm;

			wm.WiimoteChanged += wm_WiimoteChanged;
			wm.WiimoteExtensionChanged += wm_WiimoteExtensionChanged;
			wm.Connect();
			wm.SetReportType(InputReport.IRAccel, true);
			wm.SetLEDs(false, true, true, false);
		}

		private void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
		{
			wiimoteInfo1.UpdateState(args);
		}

		private void wm_WiimoteExtensionChanged(object sender, WiimoteExtensionChangedEventArgs args)
		{
			wiimoteInfo1.UpdateExtension(args);

			if(args.Inserted)
				wm.SetReportType(InputReport.IRExtensionAccel, true);
			else
				wm.SetReportType(InputReport.IRAccel, true);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			wm.Disconnect();
		}

	}
}
