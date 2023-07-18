using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using System;
using System.Threading;

namespace EpiserverTraining.jobs
{
    [ScheduledPlugIn(DisplayName = "DemoScheduledJob")]
    public class DemoScheduledJob : ScheduledJobBase
    {
        private bool _stopSignaled;

        public DemoScheduledJob()
        {
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            OnStatusChanged(String.Format("Starting execution of {0} at {1}", this.GetType(), DateTime.Now.ToString()));

            //Add implementation
            Thread.Sleep(30000);
            //For long running jobs periodically check if stop is signaled and if so stop execution
            if (_stopSignaled)
            {
                return "Stop of job was called";
            }

            return "Executed successfully....!";
        }
    }
}
