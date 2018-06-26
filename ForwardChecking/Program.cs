using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockedNQueen_FCH
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Blocked N-Queens with Forward Checking Algorithm");
            Console.Write("Type in the number of queens : ");
            int n = int.Parse(Console.ReadLine());


            Queen objQueen = new Queen(n);
            if (objQueen.Solution(0, n))
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
