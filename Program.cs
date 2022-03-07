using System;

namespace ProjetoJogoDaVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            int opc, linha = 0, coluna = 0, linha2 = 0, coluna2 = 0;

            JogoDaVelha novoJogo = null;

            Console.WriteLine("      #   ####    ####    ####\n" +
                "      #  #    #  #    #  #    #\n" +
                "      #  #    #  #       #    #\n" +
                "      #  #    #  #  ###  #    #\n" +
                " #    #  #    #  #    #  #    #\n" +
                " #    #  #    #  #    #  #    #\n" +
                "  ####    ####    ####    ####\n" +
                "                              \n" +
                "                              \n" +
                " #####     ##\n" +
                " #    #   #  #\n" +
                " #    #  #    #\n" +
                " #    #  ######\n" +
                " #    #  #    #\n" +
                " #####   #    #\n" +
                "                              \n" +
                "                              \n" +
                " #    #  ######  #       #    #    ##\n" +
                " #    #  #       #       #    #   #  #\n" +
                " #    #  #####   #       ######  #    #\n" +
                " #    #  #       #       #    #  ######\n" +
                "  #  #   #       #       #    #  #    #\n" +
                "   ##    ######  ######  #    #  #    #\n");

            Console.ReadLine();

            do
            {
                Console.Clear();
                Console.WriteLine("\t__________________________");
                Console.WriteLine("\t|++++++++| MENU |++++++++|");
                Console.WriteLine("\t|                        |");
                Console.WriteLine("\t|0| - SAIR DO JOGO       |");
                Console.WriteLine("\t|                        |");
                Console.WriteLine("\t|1| - INICIAR NOVO JOGO  |");
                Console.WriteLine("\t|________________________|");

                opc = int.Parse(Console.ReadLine());

                if (opc >= 3 || opc < 0)
                {
                    Console.WriteLine("digite uma opcao valida");
                }
                else
                {
                    switch (opc)
                    {
                        case 0:
                            Console.WriteLine("PROGRAMA ENCERRADO");
                            break;

                        case 1:
                            novoJogo = new JogoDaVelha('X', 'O');
                            Console.Clear();
                            Console.WriteLine("\t\t\tTODAS AS POSICOES ABAIXO ESTAO VAGAS\n");
                            novoJogo.Tabuleiro();
                            novoJogo.EscolheJogador(linha, coluna, linha2, coluna2);

                            break;
                    }
                }
            } while (opc != 0);
        }
    }
}
