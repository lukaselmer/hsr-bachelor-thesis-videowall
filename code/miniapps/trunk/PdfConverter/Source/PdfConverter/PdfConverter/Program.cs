using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace PdfConverter
{
    static class Program
    {
        static void Main(string[] args)
        {
            Usage(args);

            var pdfs = Pdfs(args[0]);
            var pngFolder = PngFolder(args[1]);

            var size = args[2];

            Console.WriteLine(String.Format("Found {0} pdf files. Starting conversions now...", pdfs.Count));
            Console.WriteLine();

            var convertBarrier = new Barrier(pdfs.Count + 1);

            foreach (var pdf in pdfs)
            {
                var command = String.Format(@"convert -flatten -transparent-color white -background white -density 200x200 -resize ""{0}"" -quality 100 ""{1}"" ""{2}/{3}.jpg""",
                    size, pdf.FullName, pngFolder.FullName, pdf.Name);
                Console.WriteLine("> " + command);
                ExecuteCommandAsync(command, convertBarrier);
            }

            Console.WriteLine();
            Console.WriteLine("Waiting for all images to be converted...");
            convertBarrier.SignalAndWait();
            Console.WriteLine("Done! Press enter to exit.");
            Console.ReadLine();
        }

        private static void Usage(ICollection<string> args)
        {
            Console.WriteLine();
            Console.WriteLine("Please make shure you read the readme.txt file and that ImageMagick and Postscript are installed and in your system path.");
            Console.WriteLine();
            Console.WriteLine("Usage: pdfConverter.exe <pdf_folder> <destination_folder> <size>");
            Console.WriteLine(@"Example: pdfConverter.exe ""./PdfFiles"" ""c:/Png Files"" ""1000x1000""");
            Console.WriteLine();
            if (args.Count != 3) Exit("Wrong usage!");
        }

        private static List<FileInfo> Pdfs(string path)
        {
            Console.WriteLine("The PDF files are read from: " + path);
            var pdfFolder = new DirectoryInfo(path);

            if (!pdfFolder.Exists) Exit("Directory does not exist.");

            var pdfFiles = pdfFolder.EnumerateFiles("*.pdf").Where(f => f.FullName.EndsWith(".pdf")).ToList();

            if (pdfFiles.Count == 0) Exit("No PDF files found.");

            return pdfFiles;
        }

        private static DirectoryInfo PngFolder(string path)
        {
            Console.WriteLine("The PNG files are saved to: " + path);
            var pngFolder = new DirectoryInfo(path);

            if (!pngFolder.Exists) Exit("Directory does not exist.");
            if (pngFolder.EnumerateFiles().Any()) Exit("Destination directory must be empty.");

            return pngFolder;
        }

        private static void ExecuteCommandAsync(string command, Barrier convertBarrier)
        {
            try
            {
                //Asynchronously start the Thread to process the Execute command request.
                var objThread = new Thread(() =>
                    {
                        ExecuteCommandSync(command);
                        Console.WriteLine((convertBarrier.ParticipantsRemaining - 1) + " of " + (convertBarrier.ParticipantCount - 1) + " remaing...");
                        convertBarrier.SignalAndWait();
                    });
                //Make the thread as background thread.
                objThread.IsBackground = true;
                //Set the Priority of the thread.
                objThread.Priority = ThreadPriority.BelowNormal;
                //Start the thread.
                objThread.Start();
            }
            catch (Exception objException)
            {
                Exit(objException);
            }
        }

        private static void ExecuteCommandSync(object command)
        {
            // create the ProcessStartInfo using "cmd" as the program to be run,
            // and "/c " as the parameters.
            // Incidentally, /c tells cmd that we want it to execute the command that follows,
            // and then exit.
            var procStartInfo =
                new ProcessStartInfo("cmd", "/c " + command);

            // The following commands are needed to redirect the standard output.
            // This means that it will be redirected to the Process.StandardOutput StreamReader.
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = true;
            // Now we create a process, assign its ProcessStartInfo and start it
            var proc = new Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.WaitForExit();
        }

        private static void Exit(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
            Process.GetCurrentProcess().Kill();
        }

        private static void Exit(Exception objException)
        {
            Console.WriteLine("An exception occured.");
            Console.WriteLine("Please press enter");
            Console.ReadLine();
            throw objException;
        }

    }
}
