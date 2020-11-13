using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDomainRefactoringH2
{
    /// <summary>
    /// Interface for contract for implementing an instance of the type ILogger
    /// </summary>
    public interface IUseLogger
    {
        ILogger Logger { get; }
    }
}
