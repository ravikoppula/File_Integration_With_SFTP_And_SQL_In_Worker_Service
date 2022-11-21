using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Integration_With_SFTP_And_SQL_In_Worker_Service.Interfaces
{
    public interface IProcessRemoteFiles
    {
        Task ProcessRemoteFilesAsync();
    }
}
