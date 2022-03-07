using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoDaVelha
{
    internal class JogoDaVelha
    {
        public char[,] Jogo { get; set; }
        public char X { get; set; }
        public char O { get; set; }

        public JogoDaVelha(char x, char o)
        {
            Jogo = new char[3, 3];
            X = 'X';
            O = 'O';
        }

        public void Tabuleiro()
        {
            for (int linha = 0; linha < Jogo.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < Jogo.GetLength(1); coluna++)
                {

                    Console.Write("\tPOSICAO: [{0}, {1}] = {2}   ", linha, coluna, Jogo[linha, coluna]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\tPRESSIONE A TECLA [ESPAÇO] PARA CONTINUAR O JOGO");
            Console.ReadKey();
        }

        public void EscolheJogador(int linha, int coluna, int linha2, int coluna2)
        {
            char aux;

            Console.Clear();
            Console.WriteLine("\t\t\t\tO JOGO COMEÇOU!!\n\tDECIDA COM SEU AMIGO QUEM COMEÇA JOGANDO E QUAL CARACTERE (X ou O) VOCES VAO UTILIZAR?\n\n\tDIGITE: 1 SE O JOGADOR QUE COMEÇA JOGANDO FOR REPRESENTADO POR: X \n\tDIGITE: 2 SE O JOGADOR QUE COMEÇA JOGANDO FOR REPRESENTADO POR: O");
            int jogadorComeco = int.Parse(Console.ReadLine());
            if (jogadorComeco == 1)
            {
                aux = X;

                Console.Clear();
                Console.WriteLine("\tO PRIMEIRO A JOGAR É REPRESENTADO POR JOGADOR 1: X");
                Console.WriteLine("\tO SEGUNDO A JOGAR É REPRESENTADO POR JOGADOR 2: O");
            }
            else
            {
                aux = O;
                Console.Clear();
                Console.WriteLine("\tO PRIMEIRO A JOGAR É REPRESENTADO POR JOGADOR 1: O");
                Console.WriteLine("\tO SEGUNDO A JOGAR É REPRESENTADO POR JOGADOR 2: X");
            }
            Console.WriteLine("\n\tPRESSIONE A TECLA [ESPAÇO] PARA COMEÇAR O DUELO CONTRA SEU AMIGO|}:)|");
            Console.ReadKey();
            if (aux == X)
            {
                JogadorX(linha, coluna, linha2, coluna2);
            }
            else
            {
                JogadorO(linha, coluna, linha2, coluna2);
            }
            Console.ReadKey();
        }

        public void JogadorX(int linha, int coluna, int linha2, int coluna2) //o cont tava como <=5
        {
            int cont = 0, aux = 0;
            bool flag = true;

            do
            {
                Console.Clear();
                do
                {
                    do
                    {
                        Console.WriteLine("\tVOCE ACHA QUE PODE SE TORNAR UM MESTRE NO JOGO DA VELHA?\n");
                        Console.WriteLine("\tJOGADOR 1: X");
                        linha = Linha(linha);
                        coluna = Coluna(coluna);

                    } while (linha > 2 && coluna > 2);

                    if (Verificacao(linha, coluna))
                    {
                        Jogo[linha, coluna] = X;

                        Console.WriteLine("\tA ESCOLHA FOI: POSICAO [{0}, {1}] = {2}", linha, coluna, Jogo[linha, coluna]);

                        Tabuleiro();
                        cont++;

                        flag = false;
                        aux = Vencedor(linha, coluna);

                    }
                    else
                    {
                        Console.WriteLine("\tA POSICAO JA FOI OCUPADA, TENTE OUTRA OPCAO");
                        Console.ReadKey();
                        flag = true;
                    }


                } while (flag);

                if (cont == 5)
                {
                    Empate();
                }
                else if ((cont < 5) && (aux == 0))
                {
                    do
                    {
                        do
                        {
                            Console.WriteLine("\tJOGADOR 2: O");
                            linha2 = Linha2(linha2);
                            coluna2 = Coluna2(coluna2);

                        } while (linha2 > 2 && coluna2 > 2);   //verifica se esta dentro do esperado

                        if (Verificacao2(linha2, coluna2))
                        {

                            Jogo[linha2, coluna2] = O;

                            Console.WriteLine("\tA ESCOLHA FOI: POSICAO [{0}, {1}] = {2}", linha2, coluna2, Jogo[linha2, coluna2]);

                            Tabuleiro();

                            flag = false;
                            aux = Vencedor2(linha2, coluna2);

                        }
                        else
                        {
                            Console.WriteLine("\tA POSICAO JA FOI OCUPADA, TENTE OUTRA OPCAO");
                            Console.ReadKey();
                            flag = true;
                        }

                    } while (flag);
                }

            } while (cont <= 4 && aux == 0);
        }

        public void JogadorO(int linha, int coluna, int linha2, int coluna2) //o cont ta como <=4
        {
            int cont = 0, aux = 0;
            bool flag = true;

            do
            {
                Console.Clear();
                do
                {
                    do
                    {
                        //Console.Clear();
                        Console.WriteLine("\tVOCE ACHA QUE PODE SE TORNAR UM MESTRE NO JOGO DA VELHA?\n");
                        Console.WriteLine("\tJOGADOR 1: O");
                        linha = Linha(linha);
                        coluna = Coluna(coluna);

                    } while (linha > 2 && coluna > 2);  //verifica se esta dentro do esperado

                    if (Verificacao(linha, coluna))
                    {
                        Jogo[linha, coluna] = O;

                        Console.WriteLine("\tA ESCOLHA FOI: POSICAO [{0}, {1}] = {2}", linha, coluna, Jogo[linha, coluna]);

                        Tabuleiro();
                        cont++;

                        flag = false;
                        aux = Vencedor(linha, coluna);

                    }
                    else
                    {
                        Console.WriteLine("\tA POSICAO JA FOI OCUPADA, TENTE OUTRA OPCAO");
                        Console.ReadKey();
                    }


                } while (flag);


                if (cont == 5)
                {
                    Empate();
                }
                else if ((cont < 5) && (aux == 0))
                {
                    do
                    {
                        do
                        {
                            //Console.Clear();
                            Console.WriteLine("\tJOGADOR 2: X");
                            linha2 = Linha2(linha2);
                            coluna2 = Coluna2(coluna2);

                        } while (linha2 > 2 && coluna2 > 2);    

                        if (Verificacao2(linha2, coluna2))
                        {

                            Jogo[linha2, coluna2] = X;

                            Console.WriteLine("\tA ESCOLHA FOI: POSICAO [{0}, {1}] = {2}", linha2, coluna2, Jogo[linha2, coluna2]);

                            Tabuleiro();


                            flag = false;
                            aux = Vencedor2(linha2, coluna2);

                        }
                        else
                        {
                            Console.WriteLine("\tA POSICAO JA FOI OCUPADA, TENTE OUTRA OPCAO");
                            Console.ReadKey();
                        }

                    } while (flag);
                }

            } while (cont <= 4 && aux == 0);
        }

        public int Linha(int linha)
        {
            Console.WriteLine("\tINFORME A LINHA DE SUA ESCOLHA");
            linha = int.Parse(Console.ReadLine());

            return linha;
        }
        public int Coluna(int coluna)
        {
            Console.WriteLine("\tINFORME A COLUNA DE SUA ESCOLHA");
            coluna = int.Parse(Console.ReadLine());

            return coluna;
        }

        public int Linha2(int linha2)
        {
            Console.WriteLine("\tINFORME A LINHA DE SUA ESCOLHA");
            linha2 = int.Parse(Console.ReadLine());

            return linha2;
        }
        public int Coluna2(int coluna2)
        {
            Console.WriteLine("\tINFORME A COLUNA DE SUA ESCOLHA");
            coluna2 = int.Parse(Console.ReadLine());

            return coluna2;
        }

        public bool Verificacao(int linha, int coluna)
        {
            if (Jogo[linha, coluna] == 0)  //&& Jogo[linha, coluna] < 4
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool Verificacao2(int linha2, int coluna2)
        {
            if (Jogo[linha2, coluna2] == 0)  //&& (Jogo[linha2, coluna2] < 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Vencedor(int linha, int coluna)        //se Jogo[linha, coluna] for != 0 executa, senao empata
        {
            int aux = 0;
            //vitoria pela diagonal principal
            if (Jogo[0, 0] == X && Jogo[1, 1] == X && Jogo[2, 2] == X)
            {

                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE X, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;

            }
            else if (Jogo[0, 0] == O && Jogo[1, 1] == O && Jogo[2, 2] == O)
            {

                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE O, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }

            //vitoria pela diagonal secundaria
            if (Jogo[0, 2] == X && Jogo[1, 1] == X && Jogo[2, 0] == X)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE X, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }
            else if (Jogo[0, 2] == O && Jogo[1, 1] == O && Jogo[2, 0] == O)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE O, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }

            //vitoria pela linha horizontal
            if (Jogo[linha, 0] == X && Jogo[linha, 1] == X && Jogo[linha, 2] == X)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE X, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }
            else if (Jogo[linha, 0] == O && Jogo[linha, 1] == O && Jogo[linha, 2] == O)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE O, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }

            //vitoria pela linha vertical
            if (Jogo[0, coluna] == X && Jogo[1, coluna] == X && Jogo[2, coluna] == X)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE X, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }
            else if (Jogo[0, coluna] == O && Jogo[1, coluna] == O && Jogo[2, coluna] == O)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE O, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }

            return aux;
        }

        public int Vencedor2(int linha2, int coluna2)
        {
            int aux = 0;
            //vitoria pela diagonal principal
            if (Jogo[0, 0] == O && Jogo[1, 1] == O && Jogo[2, 2] == O)
            {

                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE O, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;

            }
            else if (Jogo[0, 0] == X && Jogo[1, 1] == X && Jogo[2, 2] == X)
            {

                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE X, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }

            //vitoria pela diagonal secundaria
            if (Jogo[0, 2] == O && Jogo[1, 1] == O && Jogo[2, 0] == O)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE X, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }
            else if (Jogo[0, 2] == X && Jogo[1, 1] == X && Jogo[2, 0] == X)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE X, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }

            //vitoria pela linha horizontal
            if (Jogo[linha2, 0] == O && Jogo[linha2, 1] == O && Jogo[linha2, 2] == O)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE O, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }
            else if (Jogo[linha2, 0] == X && Jogo[linha2, 1] == X && Jogo[linha2, 2] == X)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE X, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }

            //vitoria pela linha vertical
            if (Jogo[0, coluna2] == O && Jogo[1, coluna2] == O && Jogo[2, coluna2] == O)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE O, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }
            else if (Jogo[0, coluna2] == X && Jogo[1, coluna2] == X && Jogo[2, coluna2] == X)
            {
                Console.WriteLine("\tPARABENS AO JOGADOR QUE ESCOLHEU O CARACTERE X, VOCE VENCEU");
                Console.ReadKey();
                aux = 1;
            }

            return aux;
        }

        public void Empate()
        {
            Console.WriteLine("\tO JOGO TERMINOU EMPATADO, NINGUEM VENCEU OU PERDEU ESSA PARTIDA");
            Console.ReadKey();
        }
    }
}
