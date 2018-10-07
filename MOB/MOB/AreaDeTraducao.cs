using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mob
{
	public partial class AreaDeTraducao : Form
	{
		public AreaDeTraducao()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			textBox1.Select();
			string texto = textBox1.Text;
			StreamWriter arquivoleitura = new StreamWriter(@"comandos\dialogos\traducoes\leitura.txt");
			var texto2 = texto.Replace('.', ',');
			arquivoleitura.WriteLine(texto2);
			arquivoleitura.Dispose();
			Close();
			//string leitor = File.ReadAllText(@"comandos\dialogos\traducoes\leitura.txt");
			string P = ("PT");
			string I = ("EN");
			string Traduzida = null;

			if (Skytells.Translator.TranslateText(texto2, I, P) == true)
			{
				Traduzida = Skytells.Translator.TranslatedWord;
				string emportugues = Traduzida;
				Assistente.Fala(emportugues);
				File.Delete(@"comandos\dialogos\traducoes\leitura.txt");
				
			
			}
			else
			{
				Assistente.Fala("Desculpe, estou sem conexão com a internet, mais posso traduzir agora.");
				File.Delete(@"comandos\dialogos\traducoes\leitura.txt");
				Close();
			}


		}

		private void AreaDeTraducao_Load(object sender, EventArgs e)
		{
			textBox1.Select();
			string texto = textBox1.Text;
			Assistente.Fala(texto);
		}
	}
}
