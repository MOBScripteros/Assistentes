using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mob
{
    public class Inicializacao
    {
        public static void FraseInicial()
        {
            Assistente.Fala("Olá, aguarde enquanto carrego o sistema");
           
        }
        public static void ChekInicial()
        {
            Assistente.Fala("Ok, todos os Arquivos forão carregados");
            //Assistente.Fala("Estou as suas ordens " + System.Windows.Forms.SystemInformation.ComputerName);

            
        }
    }
}
