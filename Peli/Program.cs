using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Peli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();

            Unit unit = new Unit("testi", "testi2", 2, 2, 50, 50);

            unit.Fight();

           
        }
    }
}