using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.DirectoryServices;
using System.Net.NetworkInformation;
using System.Diagnostics;
using SamwiseClient.lib.monitoring;
using SamwiseClient.lib.metrics;
using SamwiseClient.lib.storages;


namespace SamwiseClient
{
    public partial class MainForm : Form
    {

        public static SecurityIdentifier GetComputerSid()
        {
            return new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void run_button_click(object sender, EventArgs e)
        {
            debugLog.Clear();
            debugLog.AppendText("Start running\n");


            // Research: PC Identification for monitoring
            var sid = GetComputerSid();
            var macs = "";
            var pc_name = System.Environment.MachineName;
            var user_name = System.Security.Principal.WindowsIdentity.GetCurrent().Name; 

            debugLog.AppendText("SID: "+sid+"\n");
            debugLog.AppendText("PC name: " + pc_name + "\n");
            debugLog.AppendText("User Name: " + user_name + "\n");


            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                string ips = "";

                foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                {
                    ips += ip.Address.ToString() + " ";
                }


                debugLog.AppendText(
                    "Found MAC Address: " + nic.GetPhysicalAddress() + "\n" +
                    "IP: " + ips + "\n" +
                    "Description: " + nic.Description + "\n" +
                    "Type: " + nic.NetworkInterfaceType+"\n");
               
            }
            //--------------


            // Research: Global PC resource utilization 
            // CPU
            // Memory
            // Disk
            // Network
            // GPU 


            /* List of counters 
            var performanceCounterCategories = PerformanceCounterCategory.GetCategories();
            foreach (var performanceCounterCategory in performanceCounterCategories)
            {
                var performanceCounters = performanceCounterCategory.GetCounters("");
                debugLog.AppendText("\n\n\n\n --------------------     Displaying performance counters for " + performanceCounterCategory.CategoryName + " category:--");

                foreach (PerformanceCounter performanceCounter in performanceCounters)
                {
                     debugLog.AppendText(performanceCounter.CounterName + "\n");
                }

                debugLog.AppendText("  -- instance: ");
                foreach (string instance in performanceCounterCategory.GetInstanceNames())
                {
                    debugLog.AppendText("{{"+instance+"}}");
                }

                debugLog.AppendText("\n");

            }
            //*/

            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            debugLog.AppendText(ramCounter.NextValue().ToString() + "\n");
            ramCounter = new PerformanceCounter("Memory", "System Code Total Bytes");
            debugLog.AppendText(ramCounter.NextValue().ToString() + "\n");

            //PerformanceCounter ramCounter = new PerformanceCounter("LogicalDisk", "Free Megabytes","C:");

            /*
            PerformanceCounter c = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            c.NextValue();
            for (var i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(1000);
                debugLog.AppendText((c.NextValue()).ToString() + "\n");
            }*/

            //    c = new PerformanceCounter("Processor Information", "% Idle Time", "_Total");
            //    debugLog.AppendText((c.NextValue()*100).ToString() + "\n");

        }

        private void monitoringStart_Click(object sender, EventArgs e)
        {
            IMetric me = new PerformaceCounterAbsolute("Memory", "Available MBytes");
            IMetric me1 = new PerformaceCounterAbsolute("Memory", "Page Faults/sec");
            IMetric me2 = new PerformaceCounterAbsolute("Memory", "Pages/sec");
            IMetric ms = new PerformaceCounterAbsolute("System", "File Read Operations/sec");
            IMetric ms1 = new PerformaceCounterAbsolute("System", "File Write Operations/sec");
            IMetric ms2 = new PerformaceCounterAbsolute("System", "Context Switches/sec");
            IMetric ms3 = new PerformaceCounterAbsolute("System", "System Calls/sec");
            IMetric ms4 = new PerformaceCounterAbsolute("System", "Processor Queue Length");
            IMetric ms5 = new PerformaceCounterAbsolute("System", "Processes");
            IMetric ms6 = new PerformaceCounterAbsolute("System", "Threads");
            IStorage storage = new LocalCsv("local_storage.csv");
            IMonitoring mon = new IterativeMonitoring(3000, new IMetric[] { me, me1, me2, ms, ms1, ms2, ms3, ms4, ms5, ms6  }, new IStorage[] { storage });
            mon.Start();
        }

        //--------------




    }
}
