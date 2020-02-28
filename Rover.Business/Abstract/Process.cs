using Rover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business.Abstract
{
    public abstract class Process
    {
        protected Process NextProcess;
        protected string EnterValue { get; set; }

        public void SetNextProcess(Process process)
        {
            this.NextProcess = process;
        }

        public abstract bool Validate();
        public abstract void Run(ProcessModel processModel);
    }
}
