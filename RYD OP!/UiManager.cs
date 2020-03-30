using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace RYD_OP_
{
    public class UiManager
    {
        DalManager dalManager = new DalManager();
        /// <summary>
        /// Den her metode Udskriver en string.
        /// </summary>
        public void GetDiskMetadata()
        {
            Console.WriteLine(dalManager.GetDiskMetadata());
        }
        /// <summary>
        /// Den her metode Udskriver en string.
        /// </summary>
        /// <param name="drive"></param>
        public void GetHardDiskSerialNumber(string drive)
        {
            Console.WriteLine(dalManager.GetHardDiskSerialNumber(drive)) ;
        }
        /// <summary>
        /// Den her metode Udskriver en string.
        /// </summary>
        public void GetCPU()
        {
            Console.WriteLine(dalManager.GetCPU());
        }
        /// <summary>
        /// Den her metode Udskriver en string.
        /// </summary>
        public void GetMainStorage()
        {
            Console.WriteLine(dalManager.GetMainStorage());
        }
        /// <summary>
        /// Den her metode Udskriver en string.
        /// </summary>
        public void GetUsers()
        {
            Console.WriteLine(dalManager.GetUsers());
        }/// <summary>
         /// Den her metode Udskriver flere strings.
         /// </summary>
        public void GetBootDrive()
        {
            Console.WriteLine("Boot drive start");
            Console.WriteLine(dalManager.GetBootDrive());
            Console.WriteLine("Boot drive done");
        }
        /// <summary>
        /// Den her metode Udskriver en string.
        /// </summary>
        public void ListAllServices()
        {
            Console.WriteLine(dalManager.ListAllServices());
        }
    }
}
