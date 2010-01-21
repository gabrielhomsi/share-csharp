using System;
using System.IO;
using System.Windows.Forms;

namespace Share
{
    class Program
    {
        static StreamReader ConfigurationReader()
        {
            return new StreamReader(@"C:\Share.txt");
        }

        static string ShareDirectory()
        {
            return ConfigurationReader().ReadLine() + @"/";
        }

        static string ShareUrl()
        {
            StreamReader configuration = ConfigurationReader();

            configuration.ReadLine();

            return configuration.ReadLine() + @"/";
        }

        static string RandomDirectory()
        {
            Random r = new Random();
            string result = "";

            for (int i = 0; i < 10; i++)
                result += r.Next(0, 10).ToString();
            
            return result + @"/";
        }

        [STAThread]
        static void Main(string[] args)
        {
            string source = args[0];
            string fileName = Path.GetFileName(source);
            string randomDir = RandomDirectory();
            string destination = ShareDirectory() + randomDir;

            Directory.CreateDirectory(destination);
            File.Copy(source, destination + fileName);
            Clipboard.SetText(ShareUrl() + randomDir + fileName);
        }
    }
}
