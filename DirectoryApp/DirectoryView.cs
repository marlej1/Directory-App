using System;
using System.IO;
using System.Collections.Generic;


namespace DirectoryApp
{
    class DirectoryView
    {

        public string Path { get; set; }
        public string Input { get; set; }
        DirectoryAction action = new DirectoryAction();
        
     



        public DirectoryView()
        {
            Path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            
            

        }  

        

        public void PerformtAction()
        {
           string InputIgnoreCase = Input.ToLowerInvariant();
            DirectoryInfo directory = new DirectoryInfo(Path);


            switch (InputIgnoreCase)
            {

                case "list desc":
                    action.OrderDescending(Path);
                    break;
                case "list when created":
                    action.OrderNewestToOldest(Path);
                    break;

                case "dir":
                    try
                    {
                        action.DisplayAllItems(Path);
                    }               
                    catch(UnauthorizedAccessException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch(DirectoryNotFoundException directException)
                    {
                        Console.WriteLine(directException.Message);
                        Path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    }
                    break;
                case "cd..":
                   Path= action.GoUpOneLevel(Path);
                    break;

                case "help":
                    action.ShowHelpMenu();
                    break;
                case "cls":
                    action.ClearTheConsole();
                    break;
                case "details":
                    action.getFileNameCreatedAccessedModified(Path);
                    break;
                default:
                    if (InputIgnoreCase.Substring(0,2)=="cd"&& InputIgnoreCase.Length >2)
                    {
                        try
                        {

                            Path = action.ChangeDirectory(InputIgnoreCase.Substring(3), Path);
                        }
                        catch(UnauthorizedAccessException ex)
                        {
                            Console.WriteLine(ex.Message);
                            
                        }                                     
                    }
                    else
                        Console.WriteLine("Nieznana komenda");

                    break;                                   
            }
        }

        
    }

    //enum Commands
    //{
    //    DIR,
    //    CD
    //}
}
