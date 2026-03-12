using System;

namespace BigOLab
{
    internal static class Menu
    {
        // mostra o menu principal na tela, bem simples
        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("===== LABORATORIO BIG O =====");
            Console.WriteLine();
            Console.WriteLine("1 - Acesso a Array O(1)");
            Console.WriteLine("2 - Busca Linear O(n)");
            Console.WriteLine("3 - Busca Binaria O(log n)");
            Console.WriteLine("4 - Bubble Sort O(n²)");
            Console.WriteLine("5 - Fibonacci Recursivo O(2^n)");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
        }

        // verifica se a opcao digitada esta cerrta (entre 0 e 5)
        public static bool OpcaoValida(int opcao)
        {
            return opcao >= 0 && opcao <= 5;
        }
    }
}

