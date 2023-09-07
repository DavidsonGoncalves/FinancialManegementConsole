using System.IO;

namespace FinancialManegementConsole.Entities
{
    internal class FilesData
    {
        public DirectoryInfo FilePath { get; private set; }

        public DirectoryInfo LogPath { get; private set; }

        public FilesData() 
        {
            FilePath = new DirectoryInfo(@"C:\Users\Deivão\OneDrive - Educacional\Documentos\Personal\Projects\FinancialManegementConsole\FinancialManegementConsole\FinancialManegementConsole\files\Items");
            LogPath = new DirectoryInfo(@"C:\Users\Deivão\OneDrive - Educacional\Documentos\Personal\Projects\FinancialManegementConsole\FinancialManegementConsole\FinancialManegementConsole\files");
        }

        public void SaveItem(Item item) 
        {
            if (!FilePath.Exists)
            {
                FilePath.Create();
            }
            if(!File.Exists(FilePath + @"\Items.txt"))
            {
                File.Create(FilePath + @"\Items.txt");
            }
            using (StreamWriter sw = File.AppendText(FilePath + @"\Items.txt"))
            {
                sw.WriteLine(item);
            }

        }
    }
}
