using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        //-------------------------------------------------------<Globals>---------------------------------------------------------//

        public static int[] Numbers;
        public static Array[] Secondary { get; set; }
        public static int ArrSize;

        //-------------------------------------------------------</Globals>--------------------------------------------------------//
        //
        //-------------------------------------------------------<Classes>---------------------------------------------------------//

        public static Random randomizer = new Random();

        //-------------------------------------------------------</Classes>--------------------------------------------------------//
        //
        //-------------------------------------------------------<Main Code>-------------------------------------------------------//

        static void Main(string[] args)
        {
            Console.Write("Selecione o tamanho do Array: ");
            string SNumber = Console.ReadLine();
            while (!int.TryParse(SNumber, out ArrSize))
            {
                Console.WriteLine("Número não reconhecido");
                Console.Write("Selecione o Tamanho do Array: ");
                SNumber = Console.ReadLine();
            }
            Console.WriteLine("Tamanho do Array definido: " + ArrSize);
            Console.ReadKey();
            Console.Clear();
            Numbers = new int[ArrSize];
            //-----</Definir do tamanho do Array>-----//
            //
            //-----<Preencher Array aleatoriamente>------//
            for (int i = 0; i < ArrSize; i++)
            {
                Numbers[i] = randomizer.Next(100);
            }
            Array.Sort(Numbers);
            Console.Clear();
            Console.WriteLine("O seguinte Array foi gerado:");
            for (int i = 0; i < ArrSize; i++)
            {
                Console.Write("{0} ", Numbers[i]);
            }
            Console.WriteLine("", "Pressione qualquer tecla para Organizar o Array:");
            Secondary = new Array[Numbers.Length];
            for (int i = 0; i < Numbers.Length; i++)
            {
                int[] a = new int[1];
                a[0] = Numbers[i];
                Secondary[i] = a;
            }
            Console.ReadKey();
            for (int i = 0; i < Secondary.Length; i++)
            {
                Console.WriteLine("Array {0}: {1} ", i.ToString(), Secondary[i].GetValue(0));
            }
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("Escolha o Elemento a ser buscado: ");
            int n = int.Parse(Console.ReadLine());
            
            Console.Write( Finder(0, (Numbers.Length -1), n));
            Console.ReadKey();

        }

        // Buscador Rápido de Arrays ordenados

        public static string Finder (int first, int last, int target)
        {
            int middle;
            int ActualSize = last - first;
            if (ActualSize % 2 == 0)
            {
                middle = first + (ActualSize / 2);
            }
            else
            {
                middle = first + ((ActualSize + 1) / 2);
            }

            if (ActualSize == 1 && target != Numbers[middle])
            {
                    return "O elemento " + target + " não se encontra no Array"; 
            }
            else if (target < Numbers[middle])
            {
                return Finder(first, middle, target);
            }
            else if(target > Numbers[middle])
            {
                return Finder(middle, last, target);
            }
            else
            {
                return "O elemento "+ target +" foi encontrado no índice: " + middle + " ";
            }
        }
    }
}
