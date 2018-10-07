using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; // tasking
using System.Windows.Forms;
using Microsoft.Speech.Recognition; // namespace usado pra o reconhecimento de voz, Microsoft Speech Server 11 SDK pt-BR
using System.Threading; // namespace para threading
using System.IO; // namespace para E/S de arquivos
using System.Diagnostics; // diágnosticos
using System.Web;
using System.Net;
using HtmlAgilityPack;
using WindowsInput; //importando Dll InputSimulator
using DarrenLee.Translator;

namespace mob
{
	public partial class Form1 : Form
	{

		// Janelas
		private SelecionarVoz selecionarVoz = null;
		private SpeechRecognitionEngine engine; // reconhecimento da voz
		private bool mobestaouvindo = true; // o assistente esta ouvindo?
		private Navegador navegador;
		private MediaPlayer mediaPlayer;
		private AdicionarComandos adicionarComandos;

		private Dictionary<string, string> dictCmdPersonalizados = new Dictionary<string, string>(); // dicionário dos comandos personalizados
		private Dictionary<string, string> dictCmdSites = new Dictionary<string, string>();

		Random rnd = new Random();
	
		public string pesquizar;
		private YoutubeMusicas youtube;

		public Form1()
		{
			InitializeComponent();

		}
		public Form1(string valor)
		{
			InitializeComponent();
			textBox1.Text = valor;

		}

		private void LoadSpeech()

		
		{
			try
			{

				engine = new SpeechRecognitionEngine(); // instancia
				engine.SetInputToDefaultAudioDevice(); // entrada do audio Microfone

                // vamos processar o AIML aqui
                Choices cAIML = new Choices(AIML.GetWordsOrSentences()); // obtendo frases e palavras

				
				
				//string[] words = {"ola"}; // palavras
				//Choices palavras = new Choices();
				//string[] linhas = File.ReadAllLines(Environment.CurrentDirectory + "\\comandos\\dict.txt");
				//palavras.Add(linhas);
				//Grammar wordlist = new Grammar(new GrammarBuilder(palavras));



				StreamReader reader = new StreamReader(@"comandos/dict.txt");
				string[] words = File.ReadAllLines(Environment.CurrentDirectory + "\\comandos\\dict.txt");
				reader.Close();



				// gramatica basica dos comandos
				/////////////////////////
				// Gramaticas de sistema
				/////////////////////////
				Choices c_commandsOfSystem = new Choices(); // gramatica do sistema
				c_commandsOfSystem.Add(Gramaticas.perguntarhoras.ToArray()); // habilitar comando saber as horas
				c_commandsOfSystem.Add(Gramaticas.perguntardata.ToArray()); // habilitar comando saber a data
				c_commandsOfSystem.Add(Gramaticas.mobparedeouvir.ToArray()); // habilitar comando parar de ouvir
				c_commandsOfSystem.Add(Gramaticas.mobvolteaouvir.ToArray()); // habilitar comando voltar a ouvir
				c_commandsOfSystem.Add(Gramaticas.minimizarmob.ToArray()); // habilitar comando para minimizar
				c_commandsOfSystem.Add(Gramaticas.maximizarmob.ToArray()); // habilitar comando para maximizar
				c_commandsOfSystem.Add(Gramaticas.mudarvoz.ToArray()); // habilitar comando para alterar a voz
				c_commandsOfSystem.Add(Gramaticas.abrirprograma.ToArray()); // habilitar comando para abrir um programa
				c_commandsOfSystem.Add(Gramaticas.feixarprograma.ToArray()); // habilitar comando para feixar um programa
				c_commandsOfSystem.Add(Gramaticas.ComandosMediaPlayer.ToArray()); // habilitar comando para abrir media player
				c_commandsOfSystem.Add(Gramaticas.AdcionarNovoComando.ToArray()); // habilitar comando para abrir painel de comandos
                c_commandsOfSystem.Add(Gramaticas.ContarPiada.ToArray()); // habilitar comando para contar piadas
				c_commandsOfSystem.Add(Gramaticas.ComandosPersonalizados.ToArray()); // habilitar comando para contar piadas
				c_commandsOfSystem.Add(Gramaticas.Teclado.ToArray());
				c_commandsOfSystem.Add(Gramaticas.Traducao.ToArray());

				// vamos processar o os comandos personalizados aqui
				Choices cCustomComandos = new Choices(); // lista de comandos do usuário
				// Vamos ler o arquivo das perguntas personalizadas
				string[] cmds = File.ReadAllText(@"comandos\dialogos\falas.txt", Encoding.UTF8).Split('$'); // lendo ele e dividindo em linhas
				string[] cmdsites = File.ReadAllText(@"comandos\sites\sitesrespostas.txt", Encoding.UTF8).Split('$');

				// vamos processar o falas.txt
				for (int i = 0; i < cmds.Length; i++)
				{
					try
					{
						if (cmds[i].StartsWith("Dialogo#"))
						{
							cmds[i] = cmds[i].Replace("Dialogo#", "");
							string[] temp = cmds[i].Split('#');
							cCustomComandos.Add(temp[0]); // adicionamos a palavra na gramática
							dictCmdPersonalizados.Add(temp[0], temp[1]);

						}
						
					}
					catch { }

				}
				// vamos processar o sitespersonalizados.txt
				for (int i = 0; i < cmds.Length; i++)
				{
					try
					{
						if (cmds[i].StartsWith("Sites#"))
						{
							cmds[i] = cmds[i].Replace("Sites#", "");
							string[] temp = cmds[i].Split('#');
							cCustomComandos.Add(temp[0]); // adicionamos a palavra na gramática
							dictCmdSites.Add(temp[0], temp[1]);

						}

					}
					catch { }

				}
				GrammarBuilder gbCustomComandos = new GrammarBuilder();
				gbCustomComandos.Append(cCustomComandos);
				

				Grammar gCustomComandos = new Grammar(gbCustomComandos); // gramáticas dos comandos
				gCustomComandos.Name = "Personalizados";

				GrammarBuilder gb_commandsOfSystem = new GrammarBuilder();
				gb_commandsOfSystem.Append(c_commandsOfSystem);

				Grammar g_commandsOfSystem = new Grammar(gb_commandsOfSystem);
				g_commandsOfSystem.Name = "sistema"; // nome dos comandos do sistema 
								
				Grammar gAIML = new Grammar(new GrammarBuilder(cAIML));
                gAIML.Name = "AIML";

							
				//////////////////////////
				// Gramaticas de calculos
				//////////////////////////
				Choices cNumero = new Choices(); // gramatica dos numeros

				for (int i = 0; i <= 100; i++) // gerando numeros de 1 a 100
					cNumero.Add(i.ToString());

				GrammarBuilder gbNumeros = new GrammarBuilder();
				gbNumeros.Append(cNumero); // perguntando um numero
				gbNumeros.Append(new Choices("vezes", "mais", "menos", "por"));
				gbNumeros.Append(cNumero);

				Grammar gNumeros = new Grammar(gbNumeros);
				gNumeros.Name = "calculos"; // nome da gramatica



				// carregar a gramatica
				engine.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(words))));

				engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);
				engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(audioLevel);
				engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(rej);

				engine.RecognizeAsync(RecognizeMode.Multiple); // iniciar reconhecimento

				engine.LoadGrammar(g_commandsOfSystem); // carregar gramaticas de logica de sistema
				engine.LoadGrammar(gNumeros); // carregar gramaticas de logica de calculos
                engine.LoadGrammar(gAIML); // carregar gramaticas de logica de AIML
				engine.LoadGrammar(gCustomComandos); // carregar gramaticas de logica de AIML


				

			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocorreu no LoadSpeech(): " + ex.Message);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Assistente.Fala("Olá, aguarde enquanto carrego o sistema");

			LoadSpeech(); // chama o reconhecimento de voz
			Assistente.Fala("Ok, todos os Arquivos forão carregados");
			//Assistente.Fala("Estou as suas ordens " + System.Windows.Forms.SystemInformation.ComputerName);

            AIML.ConfigAIMLFiles();



        }

		// metodo que é chamado quando algo é reconhecido
		public void rec(object s, SpeechRecognizedEventArgs e)
		{
			
			
			// resultado do audio
			// MessageBox.Show(e.Result.Text);
			string speech = e.Result.Text; // mostrar palavra reconhecida
			int Num = rnd.Next(1, 10);
			String QEvent;
			float conf = e.Result.Confidence;



			string date = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString(); // nomeando o arquivo com dia mes e ano
			string log_filename = "log\\" + date + ".txt"; // cria um arquivo .txt

			StreamWriter sw = File.AppendText(log_filename);
			if (File.Exists(log_filename)) // se o arquivo ja existir
				sw.WriteLine(speech); // criar nova linha com o comando falado no log
			else
			{
				sw.WriteLine(speech);
			}
			sw.Close();
			

				if (conf > 0.4) // se a confiança for maior que 0.65f
			{
				this.label1.ForeColor = Color.LawnGreen;
				this.label1.Text = "Você Falou: " + speech; // mostra na label1 o texto reconhecido

				if (e.Result.Text.Equals("pesquisar")) 
				{
					QEvent = speech;
					Assistente.Fala("o que deseja pesquisar");
					speech = string.Empty;
				}
				if (Gramaticas.mobparedeouvir.Any(x => x == speech)) // se falar um dos comandos para parar de ouvir
				{
					mobestaouvindo = false;
					Assistente.Fala("ok, quando quiser falar comigo basta me chamar", "certo, ficarei aqui quieto");
				}
				else if (Gramaticas.mobvolteaouvir.Any(x => x == speech)) // se falar um dos comandos para voltar a ouvir
				{
					mobestaouvindo = true;
					Assistente.Fala("ok, estou te ouvindo");
				}
				if (mobestaouvindo == true)
				{
					switch (e.Result.Grammar.Name) // alterner entre as gramaticas de comandos
				///////////////////////////////////
				// verificando comandos
				//////////////////////////////////
				
					{
						case "sistema": // caso o comando esteja nos comandos de sistema

							if (Gramaticas.perguntarhoras.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								carregar.perguntarhoras(); // execultar o commando de perguntar as horas
							}
                            else if (Gramaticas.ContarPiada.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
                            {
                                System.Diagnostics.Process.Start(@"E:\programação\mob assistente\mob\visualstudio\mob\mob\bin\Debug\scripts\Piadas.vbs"); // execultar o commando de perguntar data
                            }
                            else if (Gramaticas.perguntardata.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								carregar.perguntardata(); // execultar o commando de perguntar data
							}
							else if (Gramaticas.minimizarmob.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								MinimizarAssistente(); // execultar o commando para minimizar assistente
							}
							else if (Gramaticas.maximizarmob.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								maximizarassistente(); // execultar o commando para maximizar assistente
							}
							else if (Gramaticas.mudarvoz.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								if (selecionarVoz == null || selecionarVoz.IsDisposed == true)
									selecionarVoz = new SelecionarVoz(); // execultar o commando para alterar a voz
								selecionarVoz.Show();
							}
							else if (Gramaticas.AdcionarNovoComando.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								if (Application.OpenForms.OfType<AdicionarComandos>().Count() > 0)
								{
									Assistente.Fala("O painel de comandos já esta aberto");
									adicionarComandos.Focus();
								}
								else
								{
									Assistente.Fala("abrindo painel de comandos");
									adicionarComandos = new AdicionarComandos();
									adicionarComandos.Show();
								}
								//adicionarComandos = new AdicionarComandos();
								//Assistente.Fala("abrindo painel de comandos");
								//adicionarComandos.Show(); // execultar o commando para mostrar o painel de comandos
							}
							else if (Gramaticas.abrirprograma.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								switch (speech) // caso eu fale
								{
									case "Abrir Navegador":
										navegador = new Navegador();
										Assistente.Fala("abrindo", "abrindo mob explore");
										navegador.Show();
										break;
									case "Navegador":
										navegador = new Navegador();
										Assistente.Fala("abrindo", "abrindo navegador");
										navegador.Show();
										break;
									case "Abrir Media Player":
										mediaPlayer = new MediaPlayer();
										Assistente.Fala("abrindo", "mob player esta aberto");
										mediaPlayer.Show();
										break;
									case "Media Player":
										mediaPlayer = new MediaPlayer();
										Assistente.Fala("abrindo", "abrindo mob player");
										mediaPlayer.Show();
										break;
                                   
                                    
                                }
							
							}
							else if (Gramaticas.ComandosPersonalizados.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								switch (speech) // caso eu fale
								{
									case "atualizar comandos":
										Assistente.Fala("Aguarde, avisarei quando eu terminar de atualizar");
										LoadSpeech();
										Assistente.Fala("Os comandos forão atualizados");
										break;
									
								}

							}
							else if (Gramaticas.Teclado.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								switch (speech) // caso eu fale
								{
									case "Leia o texto":
										InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
										Lertexto.Leitura();
										break;
									case "copiar":
										InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
										break;
									case "colar":
										SimularTeclas.Colar();
										break;


								}

							}
							else if (Gramaticas.Traducao.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								switch (speech) // caso eu fale
								{
									case "Traduza o texto":
										Traducao.Traduzido();
										break;
									case "Leia o texto em portugues":
										Traducao.Traduzido();
										break;

								}

							}
							else if (Gramaticas.feixarprograma.Any(X => X == speech)) // se a pergunta estiver dentro da gramatica de sistema
							{
								switch (speech) // caso eu fale
								{
									case "Feixar Navegador":
										navegador.Close();
										Assistente.Fala("feixando", "feixando mob explore");
										break;

									case "Feixar Media Player":
										mediaPlayer.Close();
										Assistente.Fala("feixando", "feixando mob player");
										break;

									case "Feixar Painel de Comandos":
										Assistente.Fala("feixando painel de comandos");
										adicionarComandos.Close();
										break;

								}

							}
                            
                            else if (Gramaticas.ComandosMediaPlayer.Any(x => x == speech))
							{
								switch (speech)
								{
									case "Abrir Arquivo":
										if (mediaPlayer != null)
										{
											mediaPlayer.AbrirArquivo();
											Assistente.Fala("Selecione um arquivo");
										}
										else
										{
											Assistente.Fala("o media player não esta aberto");
										}
										break;
								}
							}
							else if (Gramaticas.Digitar.Any(x => x == speech))
							{
								switch (speech)
								{
									case "digitar":
										
										break;
								}
							}
							break;
						case "calculos":
							Assistente.Fala("é " + resolvercalculos.Resolver(speech), "muito fáciu. " + resolvercalculos.Resolver(speech), "essa é fáciu. " + resolvercalculos.Resolver(speech));
							break;

						case "Personalizados": // caso Personalizados
							string comando = e.Result.Text;
							comando = comando.Trim();
							foreach (KeyValuePair<string, string> entry in dictCmdPersonalizados)
							{
								if (entry.Key == comando)
								{
									Assistente.Fala(entry.Value);
								}
							}
							foreach (KeyValuePair<string, string> entry in dictCmdSites)
							{
								if (entry.Key == comando)
								{
									Assistente.Fala(entry.Value);
								}
							}
							break;
						default: // caso padrão
                            Assistente.Fala(AIML.GetOutputChat(speech)); // pegar resposta
                            break;
                    }
				}
				
			}
			else
			{
				this.label1.ForeColor = Color.Red;
				
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			
		}
		private void Reconhecedor_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			int Num = rnd.Next(1, 10);
			String speech = e.Result.Text;
		}
		private void audioLevel(object s, AudioLevelUpdatedEventArgs e)
		{
			this.progressBar1.Maximum = 100;
			this.progressBar1.Value = e.AudioLevel;

		}
		private void rej(object s, SpeechRecognitionRejectedEventArgs e)
		{
			this.label1.ForeColor = Color.Red;
		}

		// metodo para maximizar o assistente
		private void maximizarassistente()

		{
			if (this.WindowState == FormWindowState.Minimized) // se o assistente estiver minimizado
			{
				this.WindowState = FormWindowState.Normal;
				Assistente.Fala("ok, estou maximizando", "olha eu aqui", "ok", "beleza", "o que deseja", "olha eu de volta");
			}
			else
			{
				Assistente.Fala("Já estou maximizado", "Mais do que ja estou não da", "já estou", "já fiz isso", "creio que você nao seja sego");
			}
		}

		// metodo para minimizar o assistente
		private void MinimizarAssistente()
		{
			if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized) // verificar se o assistente ta minimizado ou maximizado
			{
				this.WindowState = FormWindowState.Minimized;
				Assistente.Fala("ok, estou minimizado", "estarei aqui embaixo", "ok", "beleza", "qualquer coisa estarei aqui", "ok, estou saindo");
			}
			else
			{
				Assistente.Fala("Já estou minimizado", "Mais do que ja estou não da", "já estou", "já fiz isso");
			}


		}

		private void pictureBox1_Click_1(object sender, EventArgs e)
		{

		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			if (Application.OpenForms.OfType<AdicionarComandos>().Count() > 0)
			{
				Assistente.Fala("O painel de comandos já esta aberto");
				adicionarComandos.Focus();
			}
			else
			{
				adicionarComandos = new AdicionarComandos();
				adicionarComandos.Show();
				
			}
			
		}

		private void progressBar1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			youtube = new YoutubeMusicas();
			youtube.Show();

		}
	}
}
