using System;

namespace FizzBuzz_Hexagon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nQuestão FizzBuzz");

            Console.WriteLine("\nDigite o tamanho do vetor:\n");

            int v = Convert.ToInt32(Console.ReadLine()) + 1;

            Console.WriteLine("\nDigite o valor de x:\n");

            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nDigite o valor de y:\n");

            int y = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n\n");

            for (int i = 1; i <= v; i++)
            {
                string saida = "";
                if (i % x == 0) { saida = "Fizz"; }
                if (i % y == 0) { saida += "Buzz"; }
                if (saida == "") { saida = i.ToString(); }
                if (i != v) saida += ", ";
                Console.Write(saida);
            }
            Console.Write("\n\n");
        }
    }
}
