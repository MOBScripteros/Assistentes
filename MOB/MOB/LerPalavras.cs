using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mob
{
    public class LerPalavras
    {
        static void Form1(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"comandos/dict.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string linha = reader.ReadLine();


                }


            }

                          

        }
    }
}
