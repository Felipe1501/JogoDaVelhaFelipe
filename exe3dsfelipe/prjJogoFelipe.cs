using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exe3dsfelipe
{
	public partial class prjJogoVelha : Form
	{
		bool xeis = true;
		public prjJogoVelha()
		{
			InitializeComponent();
		}


		private void prjJogoVelha_Load(object sender, EventArgs e)
		{
			btnLinha1.Click += new EventHandler(VClick);
			btnLinha2.Click += new EventHandler(VClick);
			btnLinha3.Click += new EventHandler(VClick);
			btnLinha4.Click += new EventHandler(VClick);
			btnLinha5.Click += new EventHandler(VClick);
			btnLinha6.Click += new EventHandler(VClick);
			btnLinha7.Click += new EventHandler(VClick);
			btnLinha8.Click += new EventHandler(VClick);
			btnLinha9.Click += new EventHandler(VClick);

			foreach (Control item in this.Controls)
			{
				if (item is Button)
				{
					item.TabStop = false;
				}
			}
		}

		private void VClick(object sender, EventArgs e)
		{
			((Button)sender).Text = this.xeis ? "X" : "O";
			((Button)sender).Enabled = false;
			verificarGanhador();

			xeis = !xeis;

			lblJogador.Text = String.Format("{0}, sua vez!", this.xeis ? "X" : "O");
		}
		private void verificarGanhador()
		{
			if (btnLinha1.Text != string.Empty && btnLinha1.Text == btnLinha2.Text && btnLinha2.Text == btnLinha3.Text ||
			btnLinha4.Text != string.Empty && btnLinha4.Text == btnLinha5.Text && btnLinha5.Text == btnLinha6.Text ||
			btnLinha7.Text != string.Empty && btnLinha7.Text == btnLinha8.Text && btnLinha8.Text == btnLinha9.Text ||

			btnLinha1.Text != string.Empty && btnLinha1.Text == btnLinha4.Text && btnLinha4.Text == btnLinha7.Text ||
			btnLinha2.Text != string.Empty && btnLinha2.Text == btnLinha5.Text && btnLinha5.Text == btnLinha8.Text ||
			btnLinha3.Text != string.Empty && btnLinha3.Text == btnLinha6.Text && btnLinha6.Text == btnLinha9.Text ||

			btnLinha1.Text != string.Empty && btnLinha1.Text == btnLinha5.Text && btnLinha5.Text == btnLinha9.Text ||
			btnLinha3.Text != string.Empty && btnLinha3.Text == btnLinha5.Text && btnLinha5.Text == btnLinha7.Text)
			{
				MessageBox.Show(string.Format("O GANHADOR FOI O JOGADOR {0}!!!", xeis ? "X" : "O"), "TEMOS UM VENCEDOR HOMO SAPIENS!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Resetar();
			}
			else
			{
				verificarEmpate();
			}
		}
		private void verificarEmpate()
		{
			bool tudoCheio = true;

			foreach (Control item in this.Controls)
			{
				if (item is Button && item.Enabled)
				{
					tudoCheio = false;
					break;
				}
			}
			if (tudoCheio)
			{
				MessageBox.Show(string.Format("POXA, DEU EMPATE!!!"), "NÃO ACREDITO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Resetar();
			}
		}

		private void Resetar()
		{
			foreach (Control item in this.Controls)
			{
				if (item is Button)
				{
					item.Enabled = true;
					item.Text = string.Empty;
				}
			}
		}
	}
}