//////////////////////////////////////////////////////////////////////////////////
// Creadores:
// - Patricio Espinoza Salgado
// - Joel Mejias Morales
// - Fabian Cordobvez Arriagada
// - Manuel Irarrazabal Galvez
// - Valery Soto Lastra
//////////////////////////////////////////////////////////////////////////////////

namespace WiimoteTest
{
	partial class SingleWiimoteForm
	{

		private System.ComponentModel.IContainer components = null;


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
            this.wiimoteInfo1 = new WiimoteTest.WiimoteInfo();
            this.SuspendLayout();
            // 
            // wiimoteInfo1
            // 
            this.wiimoteInfo1.BackColor = System.Drawing.Color.White;
            this.wiimoteInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wiimoteInfo1.Font = new System.Drawing.Font("Verdana", 9F);
            this.wiimoteInfo1.Location = new System.Drawing.Point(0, 0);
            this.wiimoteInfo1.Name = "wiimoteInfo1";
            this.wiimoteInfo1.Size = new System.Drawing.Size(1100, 643);
            this.wiimoteInfo1.TabIndex = 0;
            // 
            // SingleWiimoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 643);
            this.Controls.Add(this.wiimoteInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SingleWiimoteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wiimote Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private WiimoteInfo wiimoteInfo1;

	}
}

