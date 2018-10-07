using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mob
{
	public partial class MediaPlayer : Form
	{
		public MediaPlayer()
		{
			InitializeComponent();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AbrirArquivo();
		}
		public void AbrirArquivo()
		{
			OpenFileDialog ofd = new OpenFileDialog();

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Play(ofd.FileName);

			}
		}

		public void Play(string file)
		{
			axWindowsMediaPlayer1.URL = file;
			axWindowsMediaPlayer1.Ctlcontrols.play();
		}

		private void MediaPlayer_Load(object sender, EventArgs e)
		{

		}
	}
}
