using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary1;
using System.Net.Configuration;
using System.ServiceModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(WcfServiceLibrary1.Service1));
            host.Open();
            Console.WriteLine("Host start...");
            Console.ReadLine();
            host.Close();
        }
    }
}
