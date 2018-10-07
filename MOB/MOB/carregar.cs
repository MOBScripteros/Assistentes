using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mob
{
	public class carregar
	{
		// saber que horas são
		public static void perguntarhoras()
		{
			Assistente.Fala(DateTime.Now.ToShortTimeString());
		}

		// saber a data
		public static void perguntardata()
		{
			Assistente.Fala(DateTime.Now.ToLongDateString());
		}


		
	}
}
