using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace RYD_OP_
{
    class Program
    {
        
        static void Main(string[] args)
        {
            UiManager uiManager = new UiManager();

            uiManager.GetDiskMetadata();
            uiManager.GetHardDiskSerialNumber("C");

            uiManager.GetCPU();

            uiManager.GetMainStorage();
            uiManager.GetUsers();
            uiManager.GetBootDrive();

            Console.WriteLine("process søgmimg");
            uiManager.ListAllServices();

            Console.ReadKey();

        } //Slut main
    }
}
