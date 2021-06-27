using System;
using Renci.SshNet;

namespace HotFi.App.Extensions
{
    public static class SshClientExtension
    {
        public static SshCommand MakeDir(this SshClient client, string directory, bool nested = true,
            bool useSudo = false)
        {
            var options = nested ? " -p " : string.Empty;
            return client.RunCommand($"mkdir{options}{directory}".CreateCommandString(useSudo));
        }

        public static SshCommand InstallCerts(this SshClient client, string directory, string domain)
        {
            return client.RunCommand($"/.acme.sh/acme.sh --install-cert -d {domain} --key-file {directory}/key.pem --fullchain-file {directory}/cert.pem  --reloadcmd 'sudo service nginx restart'".CreateCommandString());
        }

        public static SshCommand IssueCerts(this SshClient client, string accessToken, string domain, string directory)
        {
            return client.RunCommand($"export DO_API_KEY={accessToken} && /.acme.sh/acme.sh --issue --dns dns_dgon -d {domain} -w {directory} --standalone".CreateCommandString());
        }

        public static SshCommand CopyFiles(this SshClient client, string from, string to, bool useSudo = false)
        {
            return client.RunCommand($"cp {from} {to}".CreateCommandString(useSudo));
        }

        public static SshCommand SoftLinkFiles(this SshClient client, string origin, string dest, bool useSudo = false)
        {
            return client.RunCommand($"ln -s {origin} {dest}".CreateCommandString(useSudo));
        }

        public static SshCommand RunActionOnService(this SshClient client, string name, string action)
        {
            return client.RunCommand($"service {name} {action}".CreateCommandString(true));
        }

        private static string CreateCommandString(this string command, bool useSudo = false)
        {
            var suCmd = useSudo ? "sudo " : "";
            return $"{suCmd}{command}";
        }
    }
}