using CSVtoJSONlib;
using System;
using System.IO;
using System.Reflection;

// This is my current solution to the C# Foundations 1
// project By: Matthew Hess
// Landon Johnson
// CGInfinity
// 03/13/2023
// ඞ

namespace CSVtoJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the CSV - to - JSON Utility!");
            Console.WriteLine("Please enter the path to the CSV file: ");

            string filePath = Console.ReadLine();

            if(!File.Exists(filePath))
            {
                // Console.WriteLine("File does not exist/invalid path!");
                throw new Exception("File Does not Exist/Invalid Path.");
            }
            int validAccounts = 0;
            int validTransactions = 0;
            try 
            {
                Processor.ProcessLines(filePath, out validAccounts, out validTransactions);
                Console.WriteLine("Success!");
                Console.WriteLine($"Total number of Valid Accounts: {validAccounts}. \nTotal number of Valid Transactions: {validTransactions}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Process line failed, Exception: {ex.ToString()}");
            }
        }
    }
}
