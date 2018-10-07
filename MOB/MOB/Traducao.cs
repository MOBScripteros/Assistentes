using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Skytells;
using WindowsInput; //importando Dll InputSimulator

namespace mob
{
	public class Traducao
	{
		public static void Traduzir()

		{
			string texto = null;
			string Portugues = ("PT");
			string Ingles = ("EN");
			string Traduzida = null;

			InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
			texto = Clipboard.GetText(TextDataFormat.Text);
			
			if (Skytells.Translator.TranslateText(texto, Ingles, Portugues) == true)
				Traduzida = Skytells.Translator.TranslatedWord;
			MessageBox.Show(Traduzida);

		}
	}
}
