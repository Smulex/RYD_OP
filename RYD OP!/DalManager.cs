using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace RYD_OP_
{
    public class DalManager
    {
        /// <summary>
        /// Den her returnere en string.
        /// </summary>
        /// <returns></returns>
        public string GetDiskMetadata()
        {
            ManagementScope managementScope = new ManagementScope();

            ObjectQuery objectQuery = new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);

            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            string s = string.Empty;

            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                s += "Disk Name : " + managementObject["Name"].ToString() + "\nFreeSpace: " + managementObject["FreeSpace"].ToString() + "\nDisk Size: " + managementObject["Size"].ToString() + "\n---------------------------------------------------\n";
            }
            return s;
        }
        /// <summary>
        /// Den her returnere en string.
        /// </summary>
        /// <param name="drive"></param>
        /// <returns></returns>
        public string GetHardDiskSerialNumber(string drive)
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");

            managementObject.Get();

            return managementObject["VolumeSerialNumber"].ToString();
        }
        /// <summary>
        /// Den her returnere en string.
        /// </summary>
        /// <returns></returns>
        public string GetCPU()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");

            string s = string.Empty;

            foreach (ManagementObject obj in searcher.Get())
            {
                object usage = obj["PercentProcessorTime"];
                object name = obj["Name"];
                s += (name + " : " + usage + "\nCPU\n");
            }
            return s;
        }
        /// <summary>
        /// Den her returnere en string.
        /// </summary>
        /// <returns></returns>
        public string GetMainStorage()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            string s = string.Empty;

            foreach (ManagementObject result in results)
            {
                s += "Total Visible Memory: " + result["TotalVisibleMemorySize"] + " KB"
                    + "\nFree Physical Memory: " + result["FreePhysicalMemory"] + " KB"
                    + "\nTotal Virtual Memory: " + result["TotalVirtualMemorySize"] + " KB"
                    + "\nFree Virtual Memory: " + result["FreeVirtualMemory"] + " KB\n";
            }
            return s;
        }
        /// <summary>
        /// Den her returnere en string.
        /// </summary>
        /// <returns></returns>
        public string GetUsers()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            string s = string.Empty;

            foreach (ManagementObject result in results)
            {
                s += "User:\t" + result["RegisteredUser"] + "\nOrg.:\t" + result["Organization"] + "\nO/S :\t" + result["Name"] + "\n";
            }
            return s;
        }
        /// <summary>
        /// Den her returnere en string.
        /// </summary>
        /// <returns></returns>
        public string GetBootDrive()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");

            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

            //create object searcher
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = searcher.Get();

            string s = string.Empty;

            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // access properties of the WMI object
                s += "BootDevice : " + m["BootDevice"] + "\n";
            }
            return s;
        }
        /// <summary>
        /// Den her returnere en string.
        /// </summary>
        /// <returns></returns>
        public string ListAllServices()
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();

            string s = "There are " + objectCollection.Count + " Windows services: \n";

            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        s += "Windows service property name: " + serviceProperty.Name + "\nWindows service property value: " + serviceProperty.Value + "\n";
                    }
                }
                s += "---------------------------------------\n";
            }
            return s;
        }
    }
}
