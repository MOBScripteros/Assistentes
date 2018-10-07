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
	public class Lertexto
	{
		private static Areadeleitura arealeitura;
		private static Form1 primeiroform;

		public static void Leitura()
		{
			primeiroform = new Form1();
			arealeitura = new Areadeleitura();
			arealeitura.Show();
			arealeitura.TopMost = true;
			arealeitura.Focus();
			arealeitura.Activate();
			SimularTeclas.Colar();
				
		}
		public static void Retorno()
		{
			SendKeys.Send("^(A)");
			SendKeys.Send("^(V)");
			
		}

	}
}
