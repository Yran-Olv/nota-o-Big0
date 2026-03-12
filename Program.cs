using System;
using System.Diagnostics;

namespace BigOLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            // laco principal do programa (fica repetindo ate escolher sair)
            while (continuar)
            {
                Menu.MostrarMenu();

                Console.Write("Escolha uma opcao: ");
                string opcaoTexto = Console.ReadLine();

                int opcao;
                if (!int.TryParse(opcaoTexto, out opcao))
                {
                    // se digitar letra ou coisa assim da erro simples
                    Console.WriteLine("Opcao invalida, nao e numero. Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                if (opcao == 0)
                {
                    continuar = false;
                    Console.WriteLine("Saindo do laboratorio Big O..."); // mensagem simples so para saber que saiu
                    break;
                }

                if (!Menu.OpcaoValida(opcao))
                {
                    // se digitar tipo 7, 8 etc cai aqui
                    Console.WriteLine("Opcao fora do intervalo. Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine();
                Console.Write("Digite o tamanho da entrada (n): "); // aqui e o valor que vamos usar no algoritmo
                string nTexto = Console.ReadLine();

                int n;
                if (!int.TryParse(nTexto, out n) || n <= 0)
                {
                    Console.WriteLine("Valor de n invalido (menor ou igual a zero). Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                ExecutarOpcao(opcao, n);
            }
        }

        // metodo que escolhe qual algoritimo chamar (tipo um controle)
        private static void ExecutarOpcao(int opcao, int n)
        {
            string nomeAlgoritmo = "";
            string bigO = "";

            Console.Clear();
            Console.WriteLine("===== LABORATÓRIO BIG O =====");
            Console.WriteLine();

            // define o nome e a complexidade (big o) que vai aparecer depois
            switch (opcao)
            {
                case 1:
                    nomeAlgoritmo = "Acesso a Array";
                    bigO = "O(1)";
                    break;
                case 2:
                    nomeAlgoritmo = "Busca Linear";
                    bigO = "O(n)";
                    break;
                case 3:
                    nomeAlgoritmo = "Busca Binária";
                    bigO = "O(log n)";
                    break;
                case 4:
                    nomeAlgoritmo = "Bubble Sort";
                    bigO = "O(n²)";
                    break;
                case 5:
                    nomeAlgoritmo = "Fibonacci Recursivo";
                    bigO = "O(2^n)";
                    break;
            }

            Console.WriteLine("Executando " + nomeAlgoritmo + " com n = " + n + "...");
            Console.WriteLine();

            Stopwatch relogio = Stopwatch.StartNew();

            if (opcao == 1)
            {
                Algorithms.AcessoArray(n);
            }
            else if (opcao == 2)
            {
                Algorithms.BuscaLinear(n);
            }
            else if (opcao == 3)
            {
                Algorithms.BuscaBinaria(n);
            }
            else if (opcao == 4)
            {
                Algorithms.BubbleSort(n);
            }
            else if (opcao == 5)
            {
                Algorithms.FibonacciRecursivo(n);
            }

            relogio.Stop();

            Console.WriteLine();
            Console.WriteLine("Tempo de execução: " + relogio.ElapsedMilliseconds + " ms");
            Console.WriteLine("Complexidade: " + bigO);
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
