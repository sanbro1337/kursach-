using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ColorConsole
    {
        public string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        public string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        public string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
        public string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
    }
}
