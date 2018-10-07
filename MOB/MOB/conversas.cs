using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace mob
{
	/// <summary>
	/// Classe que vai falar algo passando uma frase
	/// </summary>
	public class Conversas
	{
		public static void SaySomethingFor(string phrase)// método que vai falar algo
		{
			switch (phrase) // switch, método mais rápido que if-else para muitas comparações
			{
				case "bom dia":
					DateTime time = DateTime.Now; // pega as horas
					if (time.Hour >= 5 && time.Hour < 12) // for de manhã
					{
						Assistente.Fala("olá senhor, desejo que você tenha um bom dia!");
						break;
					}
					else if (time.Hour >= 12 && time.Hour < 18) // se for de tarde
					{
						Assistente.Fala("olá, boa tarde");
						break;
					}
					else if (time.Hour >= 18 && time.Hour < 24) // se for e noite
					{
						Assistente.Fala("oi, boa noite, senhor");
						break;
					}
					break;
				case "boa tarde": // boa tarde
					Assistente.Fala("boa tarde, senhor");
					break;

				case "boa noite":
					Assistente.Fala("boa noite, tudo bem?");
					break;
				case "ainda acordado jarvis?":
					Assistente.Fala("obrigado por perguntar senhor, mas eu não durmo..");
					break;
				case "alguma ideia jarvis?":
					Assistente.Fala("não senhor");
					break;
				case "obrigado jarvis":
					Assistente.Fala("por nada, senhor");
					break;
			}
		}
	}
}
