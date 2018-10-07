using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace mob
{
	public partial class SelecionarVoz : Form
	{
		private SpeechSynthesizer sp = new SpeechSynthesizer();
		public SelecionarVoz()
		{
			InitializeComponent();

			comboBox1.Items.Clear();
			foreach (InstalledVoice voice in sp.GetInstalledVoices()) // carregando a lista de vozes do pc
			{
				comboBox1.Items.Add(voice.VoiceInfo.Name); // mostra no combobox1 a lista de vozes
			}
			comboBox1.SelectedIndex = 0;
		}

		// form carregado
		private void SelecionarVoz_Load(object sender, EventArgs e)
		{

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Assistente.selecionar(comboBox1.SelectedItem.ToString());
			Assistente.Fala("que tal agora", "o que acha desta voz", "minha voz foi alterada", "feito");
		}
	}
}
