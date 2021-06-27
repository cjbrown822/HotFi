using System;
using System.IO;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace HotFi.App.Extensions
{
    public static class SftpClientExtension
    {
        public static async Task UpdateAndInstallSslNgnixConf(this SftpClient client, string name, string username, string domain, string port, string certPath)
        {
            var path = BuildDirectoryPath("nginx-ssl.conf");
            await client.AlterAndUploadNginx(name, username, domain, port, certPath, path);
        }
        
        public static async Task UpdateAndInstallNgnixConf(this SftpClient client, string name, string username, string domain, string port, string certPath)
        {
            var path = BuildDirectoryPath("nginx-no-ssl.conf");
            await client.AlterAndUploadNginx(name, username, domain, port, certPath, path);
        }

        private static async Task AlterAndUploadNginx(this SftpClient client, string name, string username, string domain, string port,
            string certPath, string path)
        {
            using (var file = File.OpenText(path))
            {
                var data = await file.ReadToEndAsync();
                var updatedConfig = data.Replace("<%app_name%>", name).Replace("<%app_domain%>", domain)
                    .Replace("<%app_port%>", port).Replace("<%cert_path%>", certPath).Replace("<%username%>", username).Trim();
                var stream = new MemoryStream();
                await using(var writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(updatedConfig);
                    await writer.FlushAsync();
                    stream.Position = 0;
                    client.UploadFile(stream, $"/home/{username}/{domain}/nginx/nginx.conf");
                }
            }
        }

        public static async Task UploadFileToServer(this SftpClient client, string fileName, string uploadPath)
        {
            try
            {
                var path =BuildDirectoryPath(fileName);
                using (var file = File.OpenText(path))
                {
                    var data = await file.ReadToEndAsync();
                    var stream = new MemoryStream();
                    await using (var writer = new StreamWriter(stream))
                    {

                        await writer.WriteAsync(data);
                        await writer.FlushAsync();
                        stream.Position = 0;
                        client.UploadFile(stream, $"{uploadPath}{fileName}");
                    }

                }
            }
            catch (SftpPathNotFoundException e)
            {
                await Console.Error.WriteAsync(e.StackTrace);
            }
        }

        public static string BuildDirectoryPath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Data", "composefiles", "nginx", fileName);
        }
    }
}