//////////////////////////////////////////////////////////////////////////////////
// Creadores:
// - Patricio Espinoza Salgado
// - Joel Mejias Morales
// - Fabian Cordobvez Arriagada
// - Manuel Irarrazabal Galvez
// - Valery Soto Lastra
//////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WiimoteLib;

namespace WiimoteTest
{
	public partial class MultipleWiimoteForm : Form
	{
        

		Dictionary<Guid,WiimoteInfo> mWiimoteMap = new Dictionary<Guid,WiimoteInfo>();
		WiimoteCollection mWC;

		public MultipleWiimoteForm()
		{
			InitializeComponent();
		}

		private void MultipleWiimoteForm_Load(object sender, EventArgs e)
		{
			// Encontrar Wiimotes conectados.
			mWC = new WiimoteCollection();
			int index = 1;

			try
			{
				mWC.FindAllWiimotes();
			}
			catch(WiimoteNotFoundException ex)
			{
				MessageBox.Show(ex.Message, "Wiimote no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch(WiimoteException ex)
			{
				MessageBox.Show(ex.Message, "Error de Wiimote", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			foreach(Wiimote wm in mWC)
			{
				// Crear nueva pestaña
				TabPage tp = new TabPage("Wiimote " + index);
				tabWiimotes.TabPages.Add(tp);

				// Crear nuevo control de usuario
				WiimoteInfo wi = new WiimoteInfo(wm);
				tp.Controls.Add(wi);

	
				mWiimoteMap[wm.ID] = wi;

				// Conectar Wiimote y mantenerlo conectado.
				wm.WiimoteChanged += wm_WiimoteChanged;
				wm.WiimoteExtensionChanged += wm_WiimoteExtensionChanged;

				wm.Connect();
				if(wm.WiimoteState.ExtensionType != ExtensionType.BalanceBoard)
					wm.SetReportType(InputReport.IRExtensionAccel, IRSensitivity.Maximum, true);
				
				wm.SetLEDs(index++);
			}
		}

		void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
		{
			WiimoteInfo wi = mWiimoteMap[((Wiimote)sender).ID];
			wi.UpdateState(e);
		}

		void wm_WiimoteExtensionChanged(object sender, WiimoteExtensionChangedEventArgs e)
		{
			// Encontrar el controlador para este Wiimote
			WiimoteInfo wi = mWiimoteMap[((Wiimote)sender).ID];
			wi.UpdateExtension(e);

			if(e.Inserted)
				((Wiimote)sender).SetReportType(InputReport.IRExtensionAccel, true);
			else
				((Wiimote)sender).SetReportType(InputReport.IRAccel, true);
		}

		private void MultipleWiimoteForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			foreach(Wiimote wm in mWC)
				wm.Disconnect();
		}
	}
}
