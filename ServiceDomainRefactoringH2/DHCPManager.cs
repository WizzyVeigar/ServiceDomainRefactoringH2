using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDomainRefactoringH2
{
    public class DHCPManager : Manager
    {
        public DHCPManager(ILogger logger) : base(logger)
        {
        }
        /// <summary>
        /// Displays all DhcpServer addresses
        /// </summary>
        public void DisplayDhcpServerAddresses()
        {
            Logger.LogMessage("DHCP Servers");
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapteradapterProperties = adapter.GetIPProperties();
                IPAddressCollection addresses = adapteradapterProperties.DhcpServerAddresses;
                if (addresses.Count > 0)
                {
                    Console.WriteLine(adapter.Description);
                    foreach (IPAddress address in addresses)
                    {
                        Logger.LogMessage("  Dhcp Address ............................ : " + address.ToString());
                    }
                }
                else
                {
                    Logger.LogMessage("No addresses were found on " + adapter.Description);
                }
            }
        }
    }
}
