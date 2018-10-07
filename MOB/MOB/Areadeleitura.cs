using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput; //importando Dll InputSimulator

namespace mob
{
	public partial class Areadeleitura : Form
	{
		public Areadeleitura()
		{
			InitializeComponent();
		}
		public void Areadeleitura_Load(object sender, EventArgs e)
		{
			textBox1.Select();
			string texto = textBox1.Text;
			Assistente.Fala(texto);
						
		}
		public void textBox1_TextChanged(object sender, EventArgs e)
		{
			textBox1.Select();
			string texto = textBox1.Text;
			StreamWriter arquivoleitura = new StreamWriter(@"comandos\dialogos\leitura.txt", true, Encoding.UTF8);
			arquivoleitura.WriteLine(texto);
			arquivoleitura.Dispose();
			string leitor = File.ReadAllText(@"comandos\dialogos\leitura.txt", Encoding.UTF8);
			Assistente.Fala(leitor);
			File.Delete(@"comandos\dialogos\leitura.txt");
			Close();
		}

	}
}
