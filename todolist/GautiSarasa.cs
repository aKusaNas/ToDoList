using System;
using System.IO;
using System.Collections;

public class RecursiveFileProcessor
{
    public static void KaYri(string[] args)
    {
        foreach (string path in args)
        {
            if (File.Exists(Directory.GetCurrentDirectory()))
            {
                // This path is a file
                ProcessFile(Directory.GetCurrentDirectory());
            }
            else if (Directory.Exists(Directory.GetCurrentDirectory()))
            {
                // This path is a directory
                ProcessDirectory(Directory.GetCurrentDirectory());
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", Directory.GetCurrentDirectory());
            }
        }
    }


    // Process all files in the directory passed in, recurse on any directories 
    // that are found, and process the files they contain.
    public static void ProcessDirectory(string targetDirectory)
    {
        // Process the list of files found in the directory.
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
            ProcessFile(fileName);

        // Recurse into subdirectories of this directory.
        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (string subdirectory in subdirectoryEntries)
            ProcessDirectory(subdirectory);
    }

    // Insert logic for processing found files here.
    public static void ProcessFile(string path)
    {
        Console.WriteLine("Processed file '{0}'.", path);
    }
}