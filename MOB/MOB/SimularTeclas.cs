using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput; //importando Dll InputSimulator

namespace mob
{
	public class SimularTeclas
	{

		public static void presionarTecla(string tecla)
		{
			tecla = tecla.ToLower();
			switch (tecla)
			{
				case "a": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_A); break;
				case "bê": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_B); break;
				case "cê": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_C); break;
				case "dê": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_D); break;
				case "é": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_E); break;
				case "efe": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_F); break;
				case "gê": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_G); break;
				case "agá": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_H); break;
				case "i": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_I); break;
				case "jota": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_J); break;
				case "cá": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_K); break;
				case "ele": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L); break;
				case "eme": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_M); break;
				case "ene": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_N); break;
				case "ó": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_O); break;
				case "pê": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_P); break;
				case "quê": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Q); break;
				case "érre": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_R); break;
				case "ésse": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_S); break;
				case "tê": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_T); break;
				case "dáblio": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_W); break;
				case "u": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U); break;
				case "vê": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_V); break;
				case "xis": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_X); break;
				case "ípsilon": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Y); break;
				case "zê": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Z); break;
				case "baixo": InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN); break;
				case "esquerda": InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT); break;
				case "anterior": InputSimulator.SimulateKeyPress(VirtualKeyCode.BROWSER_BACK); break;
				case "avançar": InputSimulator.SimulateKeyPress(VirtualKeyCode.BROWSER_FORWARD); break;
				case "enter": InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); break;
				case "tudo": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A); break;
				case "controlc": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C); break;
				case "controlv": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V); break;
				case "controlz": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_Z); break;
				case "volume": InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_UP); break;
				case "volume1": InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_DOWN); break;
				case "navegador": InputSimulator.SimulateKeyPress(VirtualKeyCode.BROWSER_STOP); break;
				case "janela atual": InputSimulator.SimulateModifiedKeyStroke(new[] { VirtualKeyCode.MENU, VirtualKeyCode.SPACE }, new[] { VirtualKeyCode.VK_N }); break;
				case "nova guia e acessá-la": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_T); break;
				case "nova janela no modo de navegação anônima": InputSimulator.SimulateModifiedKeyStroke(new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.SHIFT }, new[] { VirtualKeyCode.VK_N }); break;
				case "próxima guia aberta": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.TAB); break;
				case "guia aberta anterior": InputSimulator.SimulateModifiedKeyStroke(new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.SHIFT }, new[] { VirtualKeyCode.TAB }); break;
				case "guia atual": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_W); break;
				case "guias abertas e o navegador":	InputSimulator.SimulateModifiedKeyStroke(new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.SHIFT }, new[] { VirtualKeyCode.VK_W }); break;
				case "Google Chrome": InputSimulator.SimulateModifiedKeyStroke( new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.SHIFT },	new[] { VirtualKeyCode.VK_Q }); break;
			}

		}

		internal void presionarTecla()
		{
			throw new NotImplementedException();
		}
		public static void Colar()
		{
			SendKeys.Send("^(V)");
		}
	}
}
