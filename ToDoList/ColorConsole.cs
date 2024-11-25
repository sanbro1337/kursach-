using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ColorConsole
    {
        public string NL = Environment.NewLine; // shortcut
        public string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        public string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        public string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
        public string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
        public string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
        public string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
        public string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        public string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";
        public string BOLD = Console.IsOutputRedirected ? "" : "\x1b[1m";
        public string NOBOLD = Console.IsOutputRedirected ? "" : "\x1b[22m";
        public string UNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[4m";
        public string NOUNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[24m";
        public string REVERSE = Console.IsOutputRedirected ? "" : "\x1b[7m";
        public string NOREVERSE = Console.IsOutputRedirected ? "" : "\x1b[27m";
        public string DARKRED = Console.IsOutputRedirected ? "" : "\x1b[31m";
        public string DARKGREEN = Console.IsOutputRedirected ? "" : "\x1b[32m";
        public string DARKYELLOW = Console.IsOutputRedirected ? "" : "\x1b[33m";
        public string DARKBLUE = Console.IsOutputRedirected ? "" : "\x1b[34m";
        public string DARKMAGENTA = Console.IsOutputRedirected ? "" : "\x1b[35m";
        public string DARKCYAN = Console.IsOutputRedirected ? "" : "\x1b[36m";
        public string WHITE = Console.IsOutputRedirected ? "" : "\x1b[97m";
        public string BLACK = Console.IsOutputRedirected ? "" : "\x1b[30m";
    }
}
