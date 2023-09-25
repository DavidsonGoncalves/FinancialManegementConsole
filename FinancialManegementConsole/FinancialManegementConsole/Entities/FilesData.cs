using System.IO;
using System.Reflection.Metadata;

namespace FinancialManegementConsole.Entities
{
    internal class FilesData
    {
        public DirectoryInfo FilePath { get; private set; }

        public DirectoryInfo LogPath { get; private set; }

        public FilesData() 
        {
            // C:\Users\Deivão\OneDrive - Educacional\Documentos\Personal\Projects\FinancialManegementConsole\FinancialManegementConsole\FinancialManegementConsole\files\Items
            FilePath = new DirectoryInfo(@"C:\Users\davidsoncgoncal\OneDrive - Educacional\Documentos\Personal\Projects\FinancialManegementConsole\FinancialManegementConsole\FinancialManegementConsole\files\Items");
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
                
                File.Create(FilePath + @"\Items.txt").Close();
            }

            using (StreamWriter sw = File.AppendText(FilePath + @"\Items.txt"))
            {
                sw.WriteLine(item);
            }

        }

        public void RemoveItem(string id)
        {
            DirectoryInfo temppath = new DirectoryInfo(FilePath + @"\Temp");
          
            if (!temppath.Exists) 
            {
                temppath.Create();
            }
            if (!temppath.Exists)
            {
                using (File.Create(temppath + @"\TempFile.txt"));
                
            }

            using (StreamReader sr = new StreamReader(FilePath + @"\Items.txt"))
           
            using (StreamWriter sw = File.AppendText(temppath + @"\TempFile.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains(id))
                    {
                        sw.WriteLine(line);
                    }
                }
            }


            File.Delete(FilePath + @"\Items.txt");

            File.Move(temppath + @"\TempFile.txt", FilePath + @"\Items.txt");
            if (File.Exists(temppath.ToString()))
            {
                File.Delete(temppath + @"\TempFile.txt");
            }
            
            

           
        }
    }
}
