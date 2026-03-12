using System;

namespace BigOLab
{
    // classe com os algoritmos que vamos usar para mostrar as complexidade de tempo
    internal static class Algorithms
    {
        private static readonly Random random = new Random();

        // O(1) - acesso dir eto em um array (so pega um valor rapido)
        public static void AcessoArray(int n)
        {
            int[] numeros = GerarArrayAleatorio(n);

            // acessa sempre a posicao do meio do vetor
            int indice = n / 2;
            int valor = numeros[indice];

            Console.WriteLine($"Acessando a posição {indice} do array. Valor encontrado: {valor}");
        }

        // O(n) - busca linear em um array (vai percorrendo um por um)
        public static void BuscaLinear(int n)
        {
            int[] numeros = GerarArrayAleatorio(n);

            // escolhe valor que sabemos que esta no final do vetor
            int alvo = numeros[n - 1];
            int posicao = -1;

            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] == alvo)
                {
                    posicao = i;
                    break;
                }
            }

            Console.WriteLine($"Valor alvo: {alvo}. Encontrado na posição: {posicao}");
        }

        // O(log n) - busca binaria em um array ordenado (divide no meio)
        public static void BuscaBinaria(int n)
        {
            int[] numeros = GerarArrayAleatorio(n);

            // para usar busca binaria o array precissa estar ordenado antes
            Array.Sort(numeros);

            int alvo = numeros[n - 1]; // escolhe um valor que existe
            int inicio = 0;
            int fim = numeros.Length - 1;
            int posicao = -1;

            while (inicio <= fim)
            {
                int meio = (inicio + fim) / 2;

                if (numeros[meio] == alvo)
                {
                    posicao = meio;
                    break;
                }
                else if (numeros[meio] < alvo)
                {
                    inicio = meio + 1;
                }
                else
                {
                    fim = meio - 1;
                }
            }

            Console.WriteLine($"Valor alvo: {alvo}. Encontrado na posição (após ordenação): {posicao}");
        }

        // O(n²) - ordenacao Bubble Sort (bem lento quando n e grande)
        public static void BubbleSort(int n)
        {
            int[] numeros = GerarArrayAleatorio(n);

            for (int i = 0; i < numeros.Length - 1; i++)
            {
                for (int j = 0; j < numeros.Length - 1; j++)
                {
                    if (numeros[j] > numeros[j + 1])
                    {
                        int aux = numeros[j];
                        numeros[j] = numeros[j + 1];
                        numeros[j + 1] = aux;
                    }
                }
            }

            if (numeros.Length <= 20) // se for pequeno mostra tudo na tela
            {
                Console.WriteLine("Array ordenado (todos os elementos):");
                Console.WriteLine(string.Join(", ", numeros));
            }
            else
            {
                Console.WriteLine("Bubble Sort finalizado para o array informado.");
            }
        }

        // O(2^n) - Fibonacci recursivo simples (bem pesado quando n sobe)
        public static void FibonacciRecursivo(int n)
        {
            // aqui para nao travar o computador, limitamos n para um valor razoavel
            if (n > 40)
            {
                Console.WriteLine("n muito grande para Fibonacci recursivo. Usando n = 40.");
                n = 40;
            }

            long resultado = Fibonacci(n);
            Console.WriteLine($"Fibonacci({n}) = {resultado}");
        }

        // implementacao recursiva de Fibonacci, bem direta
        private static long Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        // gera um array de inteiros aleatorios com tamanho n
        private static int[] GerarArrayAleatorio(int n)
        {
            int[] numeros = new int[n];

            for (int i = 0; i < n; i++)
            {
                numeros[i] = random.Next(0, 10000);
            }

            return numeros;
        }
    }
}

