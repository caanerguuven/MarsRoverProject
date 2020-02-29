using Rover.Model.Process;

namespace Rover.Business.Process.Abstract
{
    public abstract class IProcess
    {
        protected IProcess NextProcess;
        protected string EnterValue { get; set; }

        public void SetNextProcess(IProcess process)
        {
            this.NextProcess = process;
        }

        public abstract bool Validate();
        public abstract void Run(ProcessModel processModel);
    }
}
