using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;

namespace mob
{
	public partial class AdicionarComandos : Form
	{



		public AdicionarComandos()
		{
			InitializeComponent();

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void AdicionarComandos_Load(object sender, EventArgs e)
		{
			StreamReader arquivopergunta = new StreamReader(@"comandos\dialogos\perguntas.txt", Encoding.UTF8);
			while (arquivopergunta.EndOfStream == false)
			{
				listBox1.Items.Add(arquivopergunta.ReadLine());
			}
			
			arquivopergunta.Dispose();

			StreamReader arquivoresposta = new StreamReader(@"comandos\dialogos\respostas.txt", Encoding.UTF8);
			while (arquivoresposta.EndOfStream == false)
			{
				listBox2.Items.Add(arquivoresposta.ReadLine());
			}

			arquivoresposta.Dispose();

			StreamReader arquivosites = new StreamReader(@"comandos\sites\sitespersonalizados.txt", Encoding.UTF8);
			while (arquivosites.EndOfStream == false)
			{
				listBox3.Items.Add(arquivosites.ReadLine());
			}
			arquivosites.Dispose();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
		private static void OnTimedEvent(Object source, ElapsedEventArgs e)
		{
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			listBox2.Items.Clear();
			StreamReader arquivopergunta = new StreamReader(@"comandos\dialogos\perguntas.txt", Encoding.UTF8);
			while (arquivopergunta.EndOfStream == false)
			{
				listBox1.Items.Add(arquivopergunta.ReadLine());
			}
			StreamReader arquivoresposta = new StreamReader(@"comandos\dialogos\respostas.txt", Encoding.UTF8);
			while (arquivoresposta.EndOfStream == false)
			{
				listBox2.Items.Add(arquivoresposta.ReadLine());
			}

			arquivopergunta.Dispose();
			arquivoresposta.Dispose();
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			StreamWriter arquivopergunta = new StreamWriter(@"comandos\dialogos\perguntas.txt", true, Encoding.UTF8);
			StreamWriter arquivoresposta = new StreamWriter(@"comandos\dialogos\respostas.txt", true, Encoding.UTF8);

			string tagDia = "";
			// gera gravar arquivo de comando
			tagDia = "Dialogo#"; // adiciona a tag
			string cmd = textBox1.Text + "#" + textBox2.Text; // cria uma tag de comando
			File.AppendAllText(@"comandos\dialogos\falas.txt", tagDia + textBox1.Text + "#" + textBox2.Text + "$", Encoding.UTF8); // vamos escrever a tag do comando 
			 
			arquivoresposta.WriteLine(textBox2.Text);
			arquivopergunta.WriteLine(textBox1.Text);


			Assistente.Fala("comando adicionado!"); // diz algo

			textBox1.Text = "";
			textBox2.Text = "";
			textBox1.Focus();
			arquivoresposta.Dispose();
			arquivopergunta.Dispose();



		}

		private void button3_Click(object sender, EventArgs e)
		{
			StreamWriter arquivosites = new StreamWriter(@"comandos\sites\sitespersonalizados.txt", true, Encoding.UTF8);

			string tagSit = "";
			// gera gravar arquivo de comando
			tagSit = "Site#"; // adiciona a tag
			string cmd = textBox3.Text + "#" + textBox4.Text + "#" + textBox5.Text; // cria uma tag de comando
			File.AppendAllText(@"comandos\sites\sitesrespostas.txt", tagSit + textBox3.Text + "#" + textBox4.Text + "#" + textBox5.Text + "$", Encoding.UTF8); // vamos escrever a tag do comando 
			string cmsite = textBox3.Text;
			string ressite = textBox4.Text;
			string dessite = textBox5.Text;
			arquivosites.WriteLine(cmsite + "   " + "|" + "   "+ ressite + "   " + "|" + "   " + dessite);

			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox3.Focus();
			arquivosites.Dispose();


		}

		private void button4_Click(object sender, EventArgs e)
		{
			listBox3.Items.Clear();
			StreamReader arquivosites = new StreamReader(@"comandos\sites\sitespersonalizados.txt", Encoding.UTF8);
			while (arquivosites.EndOfStream == false)
			{
				listBox3.Items.Add(arquivosites.ReadLine());
			}
			
			arquivosites.Dispose();
			
		}
	}
}
