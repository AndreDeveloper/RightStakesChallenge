using System;

namespace RightStakes.Challenge.Services.Crawler.Schedules
{
    public class JobSchedule
    {
        public Type JobType { get; }
        public string CronExpression { get; }
        public JobSchedule(Type jobType, string cronExpresion)
        {
            JobType = jobType;
            CronExpression = cronExpresion;
        }
    }
}
