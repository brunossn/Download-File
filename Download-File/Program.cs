using System;
using System.IO;
using System.Net;

namespace Download_File
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!ValidateArgs(args)) return;

            var fileUrl = args[0];
            var localFile = args[1];

            CreateDirectoryIfNotExists(localFile);
            DownloadFile(fileUrl, localFile);
        }

        private static bool ValidateArgs(string[] args)
        {
            const int EXPECTED_ARGS_NUMBER = 2;

            if(args == null || args.Length < EXPECTED_ARGS_NUMBER)
            {
                Console.WriteLine("Este aplicativo deve ser iniciado com dois parâmetros:");
                Console.WriteLine("1 - URL a ser feito o download");
                Console.WriteLine("2 - Caminho que o arquivo deve ser salvo");
                Console.WriteLine("");
                Console.WriteLine("Exemplo: Download-File.exe \"https://www.google.com.br/logo.png\" \"c:\\logo.png\"");

                return false;
            }

            return true;
        }

        private static void CreateDirectoryIfNotExists(string localFile)
        {
            var directory = Path.GetDirectoryName(localFile);
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static void DownloadFile(string urlFile, string localFile)
        {
            using (var webClient = new WebClient())
                webClient.DownloadFile(urlFile, localFile);
        }
    }
}
