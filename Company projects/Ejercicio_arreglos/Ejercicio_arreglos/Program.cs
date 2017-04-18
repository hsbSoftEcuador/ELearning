using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_arreglos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pins = new int[4] { 9, 3, 7, 2 };
        
            foreach(int Pin in pins)
            {
                Console.WriteLine(Pin.ToString());
            }

            Console.ReadLine();
        }
    }
}

  