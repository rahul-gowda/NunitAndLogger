using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProjectWithLogger.Helper.Logger
{
    public class Logger : LoggerBase
    {
        private readonly string FileName;
        private readonly string FilePath;
        private readonly string FolderPath;
        public static string osdelimiter = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "/" : "\\";
        public Logger(string filename, string folderPath)
        {
            FileName = filename;
            FilePath = $"{folderPath}{osdelimiter}{FileName}_{DateTime.Now:ddMMyyyy_HHmmss}.txt";
        }
        public Logger(string folderPath) => FolderPath = folderPath;
        public static string SetFolderPath()
        {
            var subFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"TestResults{osdelimiter}{DateTime.Now:ddMMyyyy_HHmmss}_ExecutionResults");
            Directory.CreateDirectory(subFolder);
            return subFolder;
        }
        public override void Log(string Messsage)
        {
            Console.WriteLine(Messsage);
            using StreamWriter streamWriter = File.AppendText(FilePath);
            streamWriter.WriteLine($"|{DateTime.Now:dd/MM/yyyy - HH:mm:ss}| : {Messsage}");
            streamWriter.WriteLine("!-----------------------------------------------!");
        }
        public void CombineMultipleFilesIntoSingleFile()
        {
            string[] inputFilePaths = Directory.GetFiles(FolderPath);
            Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);
            using var outputStream = File.Create($"{FolderPath}{osdelimiter}TestResult.txt");
            foreach (var inputFilePath in inputFilePaths)
            {
                using (var inputStream = File.OpenRead(inputFilePath))
                {
                    inputStream.CopyTo(outputStream);
                }
                Console.WriteLine("The file {0} has been processed.", inputFilePath);
            }
        }
    }
}
