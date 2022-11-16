using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Integration_With_SFTP_And_SQL_In_Worker_Service
{
    public interface IServiceB
    {
        void Run();
    }
    public class ServiceB : IServiceB
    {
        private readonly ILogger<ServiceB> _logger;

        public ServiceB(ILogger<ServiceB> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("In Service B");
        }
    }

}
