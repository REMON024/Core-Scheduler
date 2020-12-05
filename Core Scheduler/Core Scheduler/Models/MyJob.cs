using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Scheduler.Models
{
    public class MyJob
    {
        public MyJob(Type type,string expression)
        {
            Common.Logs($"MyJob" + DateTime.Now.ToString("dd-MM-yyyy hh:mm"), "MyJobs" + DateTime.Now.ToString("hhmmss"));
            Type = type;
            Expression = expression;
        }
        public Type Type { get; }
        public string Expression { get; }
    }
}
