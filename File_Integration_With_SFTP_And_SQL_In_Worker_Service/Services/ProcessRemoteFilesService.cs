using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using File_Integration_With_SFTP_And_SQL_In_Worker_Service.Interfaces;

namespace File_Integration_With_SFTP_And_SQL_In_Worker_Service.Services
{
    public class ProcessRemoteFilesService : IProcessRemoteFiles
    {
        //public async Task ProcessRemoteFilesAsync()
        //{
        //    var credentials = new Credentials("host", "username", "password");
        //    var filePaths = new List<string>();

        //    // initializing filePaths ..

        //    var tasks = filePaths.Select(f => ParseRemoteFileAsync(credentials, f)).ToArray();

        //    var results = await Task.WhenAll(tasks).ConfigureAwait(false);

        //    // traverse through results..
        //}

        //public async Task<FileContent> ParseRemoteFileAsync(Credentials credentials, string filePath)
        //{
        //    using (var sftp = new SftpClient(credentials.host, credentials.username, credentials.password))
        //    {
        //        sftp.Connect();

        //        try
        //        {
        //            using (var remoteFileStream = sftp.OpenRead(filePath))
        //            {
        //                using (var reader = new StreamReader(remoteFileStream))
        //                {
        //                    using (var csv = new CsvReader(reader))
        //                    {
        //                        /*
        //                        // Example of CSV parsing:
        //                        var records = new List<Foo>();
        //                        csv.Read();
        //                        csv.ReadHeader();
        //                        while (csv.Read())
        //                        {
        //                            var record = new Foo
        //                            {
        //                                Id = csv.GetField<int>("Id"),
        //                                Name = csv.GetField("Name")
        //                            };
        //                            records.Add(record);
        //                        }
        //                        */
        //                    }
        //                }
        //            }
        //        }
        //        finally
        //        {
        //            sftp.Disconnect();
        //        }
        //    }
        //}
        Task IProcessRemoteFiles.ProcessRemoteFilesAsync()
        {
            throw new NotImplementedException();
        }

    }
}
