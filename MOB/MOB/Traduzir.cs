using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Skytells;
using WindowsInput; //importando Dll InputSimulator
using DarrenLee.Translator;

namespace mob
{
	public class Traducao
	{
		private static AreaDeTraducao areadetraducao;

		public static void Traduzido()

		{
			areadetraducao = new AreaDeTraducao();
			
			InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
			areadetraducao.Show();
			areadetraducao.TopMost = true;
			areadetraducao.Focus();
			areadetraducao.Activate();
			SimularTeclas.Colar();


		}
		
	}

}