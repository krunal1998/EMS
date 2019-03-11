using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using System.Net.Http;

namespace EMS.Scheduled_Task
{
    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler =  StdSchedulerFactory.GetDefaultScheduler() as IScheduler;
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<Job>().Build();

           // ITrigger trigger = TriggerBuilder.Create()
            //    .WithCronSchedule("0 0/2 * * * ?").Build();
            ITrigger trigger = TriggerBuilder.Create()
             .WithCronSchedule("0 0 7 ? * MON,TUE,WED,THU,FRI,SAT").Build();

            scheduler.ScheduleJob(job, trigger);
        }
        
    }
}