using Core_Scheduler.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Scheduler.Service
{
    public class JobReminder : IJob
    {
        public JobReminder()
        {

        }

        public Task Execute(IJobExecutionContext context)
        {
            Common.Logs($"JobReminder" + DateTime.Now.ToString("dd-MM-yyyy hh:mm"), "JobReminder" + DateTime.Now.ToString("hhmmss"));

            return Task.CompletedTask;

        }
    }
}
