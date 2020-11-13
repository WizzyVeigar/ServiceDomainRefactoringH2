using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDomainRefactoringH2
{
    public interface ILogger
    {
        /// <summary>
        /// generic message log method
        /// </summary>
        /// <param name="message"></param>
        void LogMessage(string message);
    }
}
