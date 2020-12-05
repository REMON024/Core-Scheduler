using Core_Scheduler.Models;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Scheduler.Service
{
    public class SingletonJobFactory:IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SingletonJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle triggerFiredBundle,IScheduler scheduler)
        {
            Common.Logs($"NewJob" + DateTime.Now.ToString("dd-MM-yyyy hh:mm"), "NewJob" + DateTime.Now.ToString("hhmmss"));

            return _serviceProvider.GetRequiredService(triggerFiredBundle.JobDetail.JobType) as IJob;

        }


        public void ReturnJob(IJob job)
        {

        } 
    }
}
