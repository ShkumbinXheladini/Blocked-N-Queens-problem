using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockedNQueen_DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Blocked N-Queens with Depth-First Search Algorithm");
            Console.Write("Type in the number of Queens: ");
            int n = int.Parse(Console.ReadLine());


            Queen objQueen = new Queen(n);
            if (objQueen.Solution(0))
            {
                objQueen.Display();
            }
            else
            {
                Console.WriteLine("Error!");
            }


            Console.ReadLine();
        }
    }
}
