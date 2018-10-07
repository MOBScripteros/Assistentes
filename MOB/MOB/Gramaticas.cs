using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mob
{
	public class Gramaticas
	{
		public static IList<string> perguntarhoras = new List<string>()
		{
			"que horas são",
			"Me informe que horas são",
			"pode me falar as horas"
		};

		public static IList<string> perguntardata = new List<string>()
		{
			"que dia é hoje",
			"Me informe a data de hoje",
		};

		public static IList<string> mobparedeouvir = new List<string>()
		{
			"mobi pare de obedecer",
			"pare de ouvir",
			"mobi pare de ouvir",
			"pare de escutar",
			"mobi pare de escutar",
			"fique surdo"
		};

		public static IList<string> mobvolteaouvir = new List<string>()
		{
			"mob",
			"kauan 123"

		};
		public static IList<string> minimizarmob = new List<string>()
		{
			"minimizar",
			"mob minimizar"
			
		};
		public static IList<string> maximizarmob = new List<string>()
		{
			"maximizar",
			"mob maximizar",
			"mob apareça"

		};
		public static IList<string> mudarvoz = new List<string>()
		{
			"alterar voz",
			"altere a voz",
			"mude sua voz"

		};
		public static IList<string> abrirprograma = new List<string>()
		{
			"Abrir Navegador",
			"Navegador",
			"Abrir Media Player",
            "Abrir ragbrasil"

        };
		public static IList<string> feixarprograma = new List<string>()
		{
			"Feixar Navegador",
			"Feixar Media Player",
			"Feixar Painel de Comandos"

		};
        public static IList<string> ContarPiada = new List<string>()
        {
            "Conte uma piada",
            "Conte outra"

        };
        public static IList<string> ComandosMediaPlayer = new List<string>()
		{
			"Abrir Arquivo",
			
		};
		public static IList<string> ComandosPersonalizados = new List<string>()
		{
			"atualizar comandos"

		};
		public static IList<string> Teclado = new List<string>()
		{
			"Leia o texto",
			"copiar",
			"colar"

		};
		public static IList<string> Traducao = new List<string>()
		{
			"Traduza o texto",
			"Leia o texto em portugues"

		};
		public static IList<string> AdcionarNovoComando = new List<string>()
		{
			"adcionar novo comando",
			"adcionar comando",
			"adcionar comandos",
			"abrir painel de comando",
			"abrir painel de comandos",
			"painel de comandos",
			"painel de comando"
			
		};
        
		public static IList<string> Digitar = new List<string>()
		{
			"escreva para mim",
			"desativar teclado",
			"a",
			"bê",
			"cê",
			"dê",
			"é",
			"efe",
			"gê",
			"agá",
			 "i",
			"jota",
			"cá",
			"ele",
			"eme",
			"ene",
			"ó",
			"pê",
			"quê",
			"érre",
			"ésse",
			"tê",
			"dáblio",
			"u",
			"vê",
			"xis",
			"ípsilon",
			"zê",
			"baixo",
			"esquerda",
			"anterior",
			"avançar",
			"enter",
			"tudo",
			"controlc",
			"controlv",
			"controlz",
			"volume",
			"volume1",
			"navegador",
			"janela atual",
			"nova guia e acessá-la",
			"nova janela no modo de navegação anônima",
			 "próxima guia aberta",
			 "guia aberta anterior",
			"guia atual",
			"guias abertas e o navegador",
			"Google Chrome"
			};


		//internal static object gAIML;

		public static object AIML { get; internal set; }
    }
}
