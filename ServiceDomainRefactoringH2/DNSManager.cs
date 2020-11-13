using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDomainRefactoringH2
{
    public class DNSManager : Manager
    {
        public DNSManager(ILogger logger) : base(logger)
        {
        }
        /// <summary>
        /// Gets all Host adresses from the <paramref name="url"/>
        /// </summary>
        /// <param name="url"></param>
        /// <returns>returns an array of the ip adresses</returns>
        public IPAddress[] GetHostAddresses(string url)
        {
            try
            {
                return Dns.GetHostAddresses(url);

            }
            catch (Exception)
            {
                Logger.LogMessage("Couldn't retrieve host adresses");
                return null;
            }
        }

        public IPHostEntry GetHostEntry(string IpHostName)
        {
            try
            {
                return Dns.GetHostEntry(IpHostName);
            }
            catch (FormatException)
            {
                Logger.LogMessage("Please specify a valid IP address.");
            }
            catch (SocketException)
            {
                Logger.LogMessage("Unable to perform lookup - a socket error occured.");
            }
            catch (SecurityException)
            {
                Logger.LogMessage("Unable to perform lookup - permission denied.");
            }
            catch (Exception)
            {
                Logger.LogMessage("An unspecified error occured.");
            }

            return null;
        }
    }
}
