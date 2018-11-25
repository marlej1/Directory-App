using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryApp
{
    class Program
    {

        
        static void Main(string[] args)
        {
            bool showHelp = true;
            DirectoryView directoryView = new DirectoryView();
            
            while (true)
            {
               if(showHelp)
                {
                    Console.WriteLine("Opcje programu Directory app: \n help - wyswietla pomoc \n dir - wyswietla zawartosc folderu \n dir..- idź do folderu wyżej  \n details - wyswietla nazwe pliku, czas utworzenia, otworzenie oraz edycji pliku \n list desc - sortuje i wyswietla liste plików i folderów w odwrotnej kolejności alfabetycznej\n list when created - sortuje i wyswietla liste plików i folderów od najstarszego do najnowszego \n cd + nazwa katalogu lub ścieżki - zmienia bieżący katalog (działa dokładnie tak samo jak w windows command prompt) \n Wylistowane elementy mają różne kolory(foldery są niebieskie, pliki  zależnie od typu)\n cls - czysci zawartosc konsoli");

                 showHelp = false;
                }

                Console.Write(directoryView.Path + ">");
                directoryView.Input = Console.ReadLine();
                directoryView.PerformtAction();
               
            }

        }
    }
}
