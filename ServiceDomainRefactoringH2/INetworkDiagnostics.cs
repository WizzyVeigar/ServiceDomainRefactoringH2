using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDomainRefactoringH2
{
    interface INetworkDiagnostics
    {
        string LocalPing();

        string TraceRoute(IPAddress ip);
    }
}
