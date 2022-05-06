using System;

namespace Exercício_HEXAGON
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n");
            Console.WriteLine("{[[]])}");
            Console.WriteLine("\n");
            Console.WriteLine("()([{}])");
            Console.WriteLine("\n");
            Console.WriteLine("{[()]}");
            Console.WriteLine("\n");

            Inicia();

            void Inicia()
            {
                if (ConfereSequencia() == 0)
                {
                    Console.WriteLine("\nSaída: 0. Sequência bem formada!\n");
                }
                else
                {
                    Console.WriteLine("\nSaída: 1. Sequência mal formada.\n");
                }
                Inicia();
            }

            int ConfereSequencia()
            {
                Console.WriteLine("Digite a sequência de chaves:"); Console.WriteLine("\n");
                String Sequencia = Console.ReadLine(); Console.WriteLine("\n");

                char[] Array_Sequencia = Sequencia.ToCharArray();

                if (Array_Sequencia.Length % 2 == 0 && Array_Sequencia.Length != 0)
                {
                    int n_par = 0;
                    for (int i = 0; i < Array_Sequencia.Length; i++)
                    {
                        for (int j = 0; j < Array_Sequencia.Length; j++)
                        {
                            if (j > i)
                            {
                                //Console.WriteLine("conferindo posição " + i + " = " + j + " | " + Array_Sequencia[i] + " = " + Array_Sequencia[j]);
                                if (Array_Sequencia[i] == '{' || Array_Sequencia[i] == '[' || Array_Sequencia[i] == '(')
                                {
                                    n_par = 0;
                                    //Console.WriteLine("conferindo posição " + i + " = " + j + " | " + Array_Sequencia[i] + " = " + Array_Sequencia[j]);
                                    if (Array_Sequencia[i] == '{' && Array_Sequencia[j] == '}')
                                    {
                                        Console.WriteLine("\n PAR " + i + " = " + j + " | " + Array_Sequencia[i] + " = " + Array_Sequencia[j] + " \n");
                                        n_par++; j = Array_Sequencia.Length;
                                    }
                                    if (Array_Sequencia[i] == '[' && Array_Sequencia[j] == ']')
                                    {
                                        Console.WriteLine("\n PAR " + i + " = " + j + " | " + Array_Sequencia[i] + " = " + Array_Sequencia[j] + " \n");
                                        n_par++; j = Array_Sequencia.Length;
                                    }
                                    if (Array_Sequencia[i] == '(' && Array_Sequencia[j] == ')')
                                    {
                                        Console.WriteLine("\n PAR " + i + " = " + j + " | " + Array_Sequencia[i] + " = " + Array_Sequencia[j] + " \n");
                                        n_par++; j = Array_Sequencia.Length;
                                    }
                                }
                            }
                        }
                    }
                    if (n_par == 0) { return 1; }
                }
                else
                {
                    return 1;
                }
                return 0;
            }
        }
    }
}
