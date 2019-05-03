using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace runau
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    ProcessExtensions.StartProcessAsCurrentUser(args[0]);
                    break;
                case 2:
                    ProcessExtensions.StartProcessAsCurrentUser(args[0],args[1]);
                    break;
                case 3:
                    ProcessExtensions.StartProcessAsCurrentUser(args[0],args[1],args[2]);
                    break;
                case 4:
                    ProcessExtensions.StartProcessAsCurrentUser(args[0], args[1], args[2],(args[3]=="-h"));
                    break;
            }
        }
    }
}
