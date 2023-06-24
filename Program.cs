using System;
using System.Diagnostics;

internal class Program
{
    private const string FAQ = "Hi User\n\nUnfortunately, there is no quick way to turn on power saving mode from the desktop on macOS, and as the owner of a Mac on M1, I really wanted to do this. So I had the (perhaps strange) idea to write this program. The source code is in the public domain, and the program itself is far from elegant, as it requires a password and does the whole trick by opening a terminal.\n\nHowever, this does the job for me. Perhaps in the future, I would like to rewrite the program under Swift, but we'll see.\n\nI hope this program will make your life a little easier.\n\nWith love from rainy Aachen.\n\nB.";
    private const string INTR = "Greetings.\n\nHere is the list of available commands:\n\nTo turn ON power saving mode, type 'on' or '1'.\n\nTo turn power saving mode OFF, type 'off' or '0'.\n\nFor FAQ, type 'faq'";

    public static void ExecuteCommand(string command)
    {
        Process proc = new Process();
        proc.StartInfo.FileName = "/usr/bin/env";
        proc.StartInfo.Arguments = command;
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.Start();

        while (!proc.StandardOutput.EndOfStream)
        {
            Console.WriteLine(proc.StandardOutput.ReadLine());
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(INTR);

        while (true)
        {
            string userInput = Console.ReadLine();

            if (userInput == "off")
            {
                ExecuteCommand("sudo pmset -a lowpowermode 0");
                break;
            }
            else if (userInput == "on")
            {
                ExecuteCommand("sudo pmset -a lowpowermode 1");
                break;
            }
            else if (userInput == "1")
            {
                ExecuteCommand("sudo pmset -a lowpowermode 1");
                break;
            }
            else if (userInput == "0")
            {
                ExecuteCommand("sudo pmset -a lowpowermode 0");
                break;
            }
            else if (userInput == "faq")
            {
                Console.WriteLine(FAQ);
            }
            else
            {
                Console.WriteLine("It looks like you provided the wrong argument, try again");
            }
        }
    }
}
