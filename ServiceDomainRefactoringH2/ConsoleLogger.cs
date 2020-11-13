﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDomainRefactoringH2
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
