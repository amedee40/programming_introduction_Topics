using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converts_Euro_to_Usd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dollars = int.Parse(Console.ReadLine());
            var euro = dollars * 0.883795087;
            Console.WriteLine(euro);
        }
    }
}
