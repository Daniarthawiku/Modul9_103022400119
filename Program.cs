using System;

namespace modul9_10302240119
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig config = BankTransferConfig.Load();
            Console.WriteLine("Current language: " + config.lang);

            bool status = false;
        }
    }
}