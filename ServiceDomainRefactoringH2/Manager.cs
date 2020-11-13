using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDomainRefactoringH2
{
    public abstract class Manager : IUseLogger
    {
        private ILogger logger;
        public ILogger Logger
        {
            get { return logger; }
            protected set { logger = value; }
        }
        public Manager(ILogger logger)
        {
            Logger = logger;
        }
    }
}
