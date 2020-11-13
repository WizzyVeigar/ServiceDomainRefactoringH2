using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDomainRefactoringH2
{
    class NetWorkDiagnostics : INetworkDiagnostics
    {
        /// <summary>
        /// Method for pinging locally
        /// </summary>
        /// <returns></returns>
        public string LocalPing()
        {
            // Ping's the local machine.
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Loopback;
            PingReply reply = pingSender.Send(address);

            if (reply.Status == IPStatus.Success)
            {
                string temp = "Address: " + reply.Address.ToString() + "\n" +
                "RoundTrip time: " + reply.RoundtripTime + "\n" +
                "Time to live: " + reply.Options.Ttl + "\n" +
                "Don't fragment: " + reply.Options.DontFragment + "\n" +
                "Buffer size: " + reply.Buffer.Length;

                return temp;
            }
            else
            {
                return reply.Status.ToString();
            }

        }
        /// <summary>
        /// TraceRoute method, for showing path a ping takes
        /// </summary>
        /// <param name="ipAddress">The destination you want to trace towards</param>
        /// <returns>Returns the path the trace took</returns>
        public string TraceRoute(IPAddress ipAddress)
        {            
            StringBuilder traceResults = new StringBuilder();

            using (Ping pingSender = new Ping())
            {

                PingOptions pingOptions = new PingOptions();
                Stopwatch stopWatch = new Stopwatch();
                byte[] bytes = new byte[32];

                pingOptions.DontFragment = true;
                pingOptions.Ttl = 1;
                int maxHops = 30;

                traceResults.AppendLine(
                    string.Format(
                        "Tracing route to {0} over a maximum of {1} hops:",
                        ipAddress,
                        maxHops));

                traceResults.AppendLine();

                for (int i = 1; i < maxHops + 1; i++)
                {
                    stopWatch.Reset();
                    stopWatch.Start();

                    PingReply pingReply = pingSender.Send(
                        ipAddress,
                        5000,
                        new byte[32], pingOptions);

                    stopWatch.Stop();

                    traceResults.AppendLine(
                        string.Format("{0}\t{1} ms\t{2}",
                        i,
                        stopWatch.ElapsedMilliseconds,
                        pingReply.Address));



                    if (pingReply.Status == IPStatus.Success)
                    {
                        traceResults.AppendLine();
                        traceResults.AppendLine("Trace complete."); 
                        break;
                    }

                    pingOptions.Ttl++;
                }
            }
            return traceResults.ToString();
        }
    }
}
