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







        }
    }
}
