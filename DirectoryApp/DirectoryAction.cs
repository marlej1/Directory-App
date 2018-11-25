using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryApp
{


    class DirectoryAction
    {

        public void OrderDescending(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            IEnumerable<FileSystemInfo> infos = directoryInfo.GetFileSystemInfos();
           IEnumerable<FileSystemInfo> orderedList =  infos.OrderByDescending(systemInfo => systemInfo.Name);
            Console.WriteLine();
            Console.WriteLine("Directory of  " + path);
            Console.WriteLine();
            foreach (var item in orderedList)
            {
                SetTheColor(item);

                Console.Write(item.CreationTime + "\t ");
                if (!(item is FileInfo))
                    Console.Write("<DIR>\t");
                else
                    Console.Write("   " + "\t");

                Console.WriteLine(item.Name);

            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void OrderNewestToOldest(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            IEnumerable<FileSystemInfo> infos = directoryInfo.GetFileSystemInfos();
            IEnumerable<FileSystemInfo> orderedList = infos.OrderBy(systemInfo => systemInfo.CreationTime);


            Console.WriteLine();
            Console.WriteLine("Directory of  " + path);
            Console.WriteLine();
            foreach (var item in orderedList)
            {
                SetTheColor(item);

                Console.Write(item.CreationTime + "\t ");
                if (!(item is FileInfo))
                    Console.Write("<DIR>\t");
                else
                    Console.Write("   " + "\t");

                Console.WriteLine(item.Name);

            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayAllItems(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            IEnumerable<FileSystemInfo> infos = directoryInfo.GetFileSystemInfos();
            Console.WriteLine();
            Console.WriteLine("Directory of  " + path);
            Console.WriteLine();
            foreach (var item in infos)
            {
                SetTheColor(item);

                Console.Write(item.CreationTime + "\t ");
                if(!(item is FileInfo))
                    Console.Write("<DIR>\t");
                else
                    Console.Write("   " + "\t");

                Console.WriteLine(item.Name); 

            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    
        public string GoUpOneLevel(string path)
        {
            if (path != @"C:")
            {
                int slashLastIndex = path.LastIndexOf(@"\");
                return path.Substring(0, slashLastIndex);
            }
            else return path;
        }

        public void ShowHelpMenu()
        {
          
            Console.WriteLine();
            Console.WriteLine("Opcje programu Directory app: \n help - wyswietla pomoc \n dir - wyswietla zawartosc folderu \n cd..- idź do folderu wyżej  \n details - wyswietla nazwe pliku, czas utworzenia, otworzenie oraz edycji pliku \n list desc - sortuje i wyswietla liste plików i folderów w odwrotnej kolejności alfabetycznej\n list when created - sortuje i wyswietla liste plików i folderów od najstarszego do najnowszego \n cd + nazwa katalogu lub ścieżki - zmienia bieżący katalog (działa dokładnie tak samo jak w windows command prompt) cls - czysci zawartosc konsoli  \n Wylistowane elementy mają różne kolory(foldery są niebieskie, pliki  zależnie od typu)\n cls - czysci zawartosc konsoli");
            Console.WriteLine();
            
        }

       internal string ChangeDirectory(string folder, string oldPath)
        {
            bool isFolderInDirectory= false;
            string newPath="";
            DirectoryInfo katalog = new DirectoryInfo(oldPath);
            IEnumerable<FileSystemInfo> systemInfo = katalog.GetFileSystemInfos();
            foreach (var item in systemInfo)
            {
                if(item is DirectoryInfo&& item.Name.ToLowerInvariant() == folder)
                {
                    newPath = oldPath + @"\" + item;
                    isFolderInDirectory = true;
                }            
            }
            if (!isFolderInDirectory)
            {
                newPath = folder;
            }
            return newPath;

        }

        public void  getFileNameCreatedAccessedModified(string path)
        {
            IEnumerable<string> directorList = Directory.GetFileSystemEntries(path);
            
            
            
            foreach (var item in directorList)
            {
                Console.WriteLine("");
                Console.WriteLine("File name: {0}", item);
                Console.WriteLine("Created: {0}", Directory.GetCreationTime(item));
                Console.WriteLine("Accessed: {0}", Directory.GetLastAccessTime(item));
                Console.WriteLine("Modified: {0}", Directory.GetLastWriteTime(item));


            }
}

        public void ClearTheConsole()
        {
            Console.Clear();
            
        }

        private void  SetTheColor(FileSystemInfo item)
        {

            if (item is FileInfo)
            {
                switch (item.Extension)
                {
                    case ".exe":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case ".wma":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case ".pdf":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case ".xls":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case ".txt":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
        }






       

        







    }
}