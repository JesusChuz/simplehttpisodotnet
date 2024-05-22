using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace simplehttp
{
    public class Timerfunc
    {
        private readonly ILogger _logger;

        public Timerfunc(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Timerfunc>();
        }

        [Function("Timerfunc")]
        public void Run([TimerTrigger("* * * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
