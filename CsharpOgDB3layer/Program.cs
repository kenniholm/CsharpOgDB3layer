using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpOgDB3layer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Run();
        }
        public void Run()
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
