using System;
using System.IO;


public class FileManager
{

    public string currentDirectory;

    public FileManager()
    {
        currentDirectory = Directory.GetCurrentDirectory();
    }


    public void Starting()
        {
            Console.WriteLine("Welcome to the File Manager");
            /*Console.Write("Specify the directory you want to work with, otherwise the current one will be selected: ");
            var dir = Console.ReadLine();*/
            loadFilesAndDirectories(@"D:\");
        }
        
    public void loadFilesAndDirectories(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Current directory - " + currentDirectory);
            Console.WriteLine("This directory includes:");
            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs) { Console.WriteLine(Path.GetFileName(dir)); }

            var files = Directory.GetFiles(path);
            foreach (string file in files) { Console.WriteLine(Path.GetFileName(file)); }
        }
        else
        {
            Console.WriteLine("This directory doesn't exist");
        }
    }
    public void ChangingDirectory(string NewDirectory)
    {
        string newPath = Path.Combine(currentDirectory, NewDirectory);
        if (!Directory.Exists(newPath))
        {
            currentDirectory = newPath;
            Console.WriteLine("Changed directory to " + currentDirectory);
        }
        else
        {
            Console.WriteLine("This directory doesn't exist");
        }
    }

    public void CopyingObj(string fromPath, string toPath)
    {
        toPath = Path.Combine(currentDirectory, toPath);
        fromPath = Path.Combine(currentDirectory, fromPath);

        if (!File.Exists(fromPath) && File.Exists(toPath))
        {
            File.Copy(fromPath, toPath);
            Console.WriteLine("The directory was created successfully");
        }
        else {
            Console.WriteLine("One of theese objects doesn't exists");
        }
    }

    public void Deleting(string newPath)
    {
        string path = Path.Combine(currentDirectory, newPath);
        if (!File.Exists(path))
        {
            File.Delete(path);
            Console.WriteLine("This object was created successfully");
        }
        else
        {
            Console.WriteLine("This object doesn't exist");
        }
    }

    public void DirectoryCreating(string path)
    {
        path = Path.Combine(currentDirectory, path);
        if (Directory.Exists(path))
        {
            Console.WriteLine("That path exists already.");
        }
        else
        {
            Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully");
        }
    }

    public void GetInfo(string path)
    {
        path = Path.Combine(currentDirectory, path);
        if (!File.Exists(path))
        {
            Console.WriteLine("");
        }
    }


}

class Program
{
    static void Main(string[] args)
    {
        FileManager manager = new FileManager();
        manager.Starting();
        while (true)
        {
            Console.Write("Enter the command: ");
            var Command = Console.ReadLine();

            switch (Command)
            {
                case "cd":
                    try
                    {
                        Console.Write("Choose the directory: ");
                        var directory = Console.ReadLine();
                        manager.ChangingDirectory(directory);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;

                case "pwd":
                    try
                    {
                        Console.WriteLine(manager.currentDirectory);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;
                case "ls":
                    try
                    {
                        manager.loadFilesAndDirectories(manager.currentDirectory);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;
                case "mkdir":
                    try
                    {
                        Console.Write("Choose the path: ");
                        var directory = Console.ReadLine();
                        manager.DirectoryCreating(directory);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;

                case "rm":
                    try
                    {
                        Console.Write("Choose the path: ");
                        var directory = Console.ReadLine();
                        manager.Deleting(directory);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;

                case "cp":
                    try
                    {
                        Console.Write("Select the file to be copied: ");
                        var fromPath = Console.ReadLine();

                        Console.Write("Select the copy path: ");
                        var toPath = Console.ReadLine();

                        manager.CopyingObj(fromPath, toPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;



            }
        }
        
    }
}
