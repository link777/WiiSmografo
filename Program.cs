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

namespace WiimoteTest
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MultipleWiimoteForm());
		}
	}
}