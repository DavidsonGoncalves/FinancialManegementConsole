using System;
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
            FilePath = new DirectoryInfo(@"C:\Users\Deivão\OneDrive - Educacional\Documentos\Personal\Projects\FinancialManegementConsole\FinancialManegementConsole\FinancialManegementConsole\files\Items");
            LogPath = new DirectoryInfo(@"C:\Users\Deivão\OneDrive - Educacional\Documentos\Personal\Projects\FinancialManegementConsole\FinancialManegementConsole\FinancialManegementConsole\files");
        }

        public void SaveItem(Item item) 
        {
            try
            {
                if (!FilePath.Exists)
                {
                    FilePath.Create();
                }

                if (!File.Exists(FilePath + @"\Items.txt"))
                {

                    File.Create(FilePath + @"\Items.txt").Close();
                }

                using (StreamWriter sw = File.AppendText(FilePath + @"\Items.txt"))
                {

                    sw.WriteLine(item);
                    SaveLog("- INFO: Item " + item.ID + " Added");
                }
            }catch(DirectoryNotFoundException e) 
            {
                SaveLog("- Errror: " + e.Message);
                throw new Exception("- Errror: " +e.Message);
            }
          

        }

        public void SaveLog(string text)
        {
            try
            {
                if (!LogPath.Exists)
                {
                    LogPath.Create();
                }
                if (!File.Exists(LogPath + @$"\log" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt"))
                {

                    File.Create(LogPath + @$"\log" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt").Close();
                }


                {
                    using (StreamWriter sw = File.AppendText(LogPath + @$"\log" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt"))
                    {

                        sw.WriteLine("[" + DateTime.Now + "] - " + text);
                    }
                }
            }
            catch (DirectoryNotFoundException e)
            {

                throw new Exception("- Errror: " + e.Message);
            }
            

        }

        public void RemoveItem(string id)
        {
            try
            {
                DirectoryInfo temppath = new DirectoryInfo(FilePath + @"\Temp");

                if (!temppath.Exists)
                {
                    temppath.Create();
                }
                if (!temppath.Exists)
                {
                    using (File.Create(temppath + @"\TempFile.txt")) ;

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
                SaveLog("- INFO: Item " + id + " removed");
            }
            catch (DirectoryNotFoundException e)
            {
                SaveLog("- Errror: " + e.Message);
                throw new Exception("- Errror: " + e.Message);
            }
            
        }

        public void CreateCsv()
        {
            try
            {
                File.Copy(FilePath + @"\Items.txt", FilePath + @"\Items"+DateTime.Now.Second.ToString()+".csv");
                SaveLog("INFO: csv file exported to: " + FilePath);
            }
            catch (DirectoryNotFoundException e)
            {
                SaveLog(" - Errror: " + e.Message);
                throw new Exception("- Errror: " + e.Message);
            }

        }
        public StreamReader ReadFile()
        {
            try
            {
                StreamReader sr = new StreamReader(FilePath + @"\Items.txt");

                return sr;
            }
            catch (DirectoryNotFoundException e)
            {
                SaveLog("- Errror: " + e.Message);
                throw new Exception("- Errror: " + e.Message);
            }

        }
    }
}
