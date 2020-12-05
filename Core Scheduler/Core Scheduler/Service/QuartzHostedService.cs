using Core_Scheduler.Models;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core_Scheduler.Service
{
    public class QuartzHostedService:IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<MyJob> _myJobs;


       public QuartzHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobFactory, IEnumerable<MyJob> myJobs)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _myJobs = myJobs;
        }


        public IScheduler Scheduler { get; set; }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Common.Logs($"StartAsync" + DateTime.Now.ToString("dd-MM-yyyy hh:mm"), "StartAsync" + DateTime.Now.ToString("hhmmss"));
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;
            foreach (var MyJob in _myJobs)
            {
                var job = CreateJob(MyJob);
                var trigger = CreateTrigger(MyJob);

                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            await Scheduler.Start(cancellationToken);
        }


        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Common.Logs($"StopAsync" + DateTime.Now.ToString("dd-MM-yyyy hh:mm"), "StopAsync" + DateTime.Now.ToString("hhmmss"));
            await Scheduler?.Shutdown(cancellationToken);
        }


        private static IJobDetail CreateJob(MyJob job)
        {
            var type = job.Type;
            return JobBuilder.Create(type).WithIdentity(type.FullName).WithDescription(type.Name).Build();
        }


        private static ITrigger CreateTrigger(MyJob job)
        {
            var type = job.Type;
            return TriggerBuilder.Create().WithIdentity($"{job.Type.FullName}.trigger").WithCronSchedule(job.Expression).WithDescription(job.Expression).Build();
        }



    }
}
