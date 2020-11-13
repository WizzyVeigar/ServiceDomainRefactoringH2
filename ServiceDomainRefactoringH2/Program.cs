using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDomainRefactoringH2
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            DHCPManager dhcpManager = new DHCPManager(logger);
            DNSManager dnsManager = new DNSManager(logger);
            NetWorkDiagnostics diagnostics = new NetWorkDiagnostics();

            IPAddress[] array = dnsManager.GetHostAddresses("en.wikipedia.org");
            foreach (IPAddress ip in array)
            {
                logger.LogMessage(ip.ToString());
            }

            logger.LogMessage(diagnostics.LocalPing());

            logger.LogMessage("start");
            IPHostEntry entry = dnsManager.GetHostEntry("8.8.8.8");
            logger.LogMessage(entry.HostName);
            logger.LogMessage("slut");

            if (entry.AddressList.Length > 0)
            {
                //ip = ipHostEntry.AddressList[0].Address.ToString();                
                logger.LogMessage("Weee " + entry.AddressList[0].ToString());
            }
            else
            {
                logger.LogMessage("No information found.");
            }

            logger.LogMessage("route*** " + diagnostics.TraceRoute(entry.AddressList[0]));

            
            dhcpManager.DisplayDhcpServerAddresses();

            Console.ReadKey();
            //WIN-M69SG2Q0732.test.local
            //ZBC-RG01203MKC
            entry = dnsManager.GetHostEntry("ZBC-RG01203MKC");
            // Get the IP address list that resolves to the host names contained in the 
            // Alias property.
            IPAddress[] address = entry.AddressList;
            // Get the alias names of the addresses in the IP address list.
            string[] alias = entry.Aliases;

            logger.LogMessage("Host name : " + entry.HostName);
            logger.LogMessage("\nAliases : ");
            for (int index = 0; index < alias.Length; index++)
            {
                logger.LogMessage(alias[index]);
            }
            logger.LogMessage("\nIP address list : ");
            for (int index = 0; index < address.Length; index++)
            {
                logger.LogMessage(address[index].ToString());
            }
            Console.ReadKey();
        }
    }
}
