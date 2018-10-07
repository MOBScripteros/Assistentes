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
	public partial class YoutubeMusicas : Form
	{
		public YoutubeMusicas()
		{
			InitializeComponent();
		}

		private void axShockwaveFlash1_Enter(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			
				string url = textBox1.Text;
				axShockwaveFlash1.Movie = url;
				axShockwaveFlash1.Play();
			
		}

		private void YoutubeMusicas_Load(object sender, EventArgs e)
		{

		}
	}
}
