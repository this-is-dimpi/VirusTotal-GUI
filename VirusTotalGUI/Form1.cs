using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VirusTotalNET;
using VirusTotalNET.Objects;
using VirusTotalNET.ResponseCodes;
using VirusTotalNET.Results;
namespace VirusTotalGUI
{
    public partial class Form1 : Form
    {
        private Byte[] fileBytes = null;

        List<ScanResult> resultList = new List<ScanResult>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
            Debug.WriteLine("Application Started");
        }
        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private static void PrintScan(FileReport fileReport)
        {
            Console.WriteLine("Scan ID: " + fileReport.ScanId);
            Console.WriteLine("Message: " + fileReport.VerboseMsg);
            if (fileReport.ResponseCode == FileReportResponseCode.Present)
            {
                foreach (KeyValuePair<string, ScanEngine> scan in fileReport.Scans)
                {
                    Console.WriteLine("{0,-25} Detected: {1}", scan.Key, scan.Value.Detected);
                }
            }
            Console.ReadLine();
        }
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.RestoreDirectory = true;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileLocator.Text = openFileDialog1.FileName;

            }
        }

        private async void ScanButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(fileLocator.Text.EndsWith("png") || fileLocator.Text.EndsWith("jpg") || fileLocator.Text.EndsWith("gif")||fileLocator.Text.EndsWith("svg")))

                {
                    fileBytes = File.ReadAllBytes(fileLocator.Text);
                    if (fileBytes != null)
                    {
                        string API_KEY = System.Environment.GetEnvironmentVariable("API_KEY", EnvironmentVariableTarget.Machine);
                        VirusTotal virusTotal = new VirusTotal(API_KEY);
                        //Use HTTPS instead of HTTP
                        virusTotal.UseTLS = true;
                        virusTotal.UseTLS = true;
                        if (fileBytes.Length > 0)
                        {
                            //Check if the file has been scanned before.
                            FileReport report = await virusTotal.GetFileReportAsync(fileBytes);
                            if (report.ResponseCode == FileReportResponseCode.Present)
                            {
                                foreach (KeyValuePair<string, ScanEngine> scan in report.Scans)
                                {
                                    Console.WriteLine("{0,-25} Detected: {1}", scan.Key, scan.Value.Detected);
                                }
                                Console.WriteLine("Scan ID: " + report.ScanId);
                                Console.WriteLine("Message: " + report.VerboseMsg);
                                Console.WriteLine("Seen before: " + (report.ResponseCode == FileReportResponseCode.Present ? "Yes" : "No"));

                            }

                            addResultRecord(fileLocator.Text, report);
                        }
                        else
                        {
                            MessageBox.Show("Please Select a file having valid size");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Sorry We Currently Don't Support This Format, Next Release Will incorporat These Features");
                    fileLocator.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






    
    public void updateListView()
    {
        scannedFileListView.Items.Clear();
        foreach (var res in resultList)
        {

            var row = new string[] { res.FileName, res.DateOfScan.ToString("MM/dd/yyyy HH:mm:ss"), res.GetChecksum(), res.Result };
            var lvi = new ListViewItem(row);
            lvi.Tag = res;
            scannedFileListView.Items.Add(lvi);

        }
    }

    public void addResultRecord(string filepath, FileReport report)
    {
        string res = "";
        if (report.Scans != null)
        {
            foreach (KeyValuePair<string, ScanEngine> scan in report.Scans)
            {
                res += string.Format("{0,-25} Detected: {1} \n", scan.Key, scan.Value.Detected);
            }
        }
        ScanResult scr = new ScanResult(filepath, res);
        resultList.Add(scr);
        fileLocator.Text = "";
        fileBytes = null; 
        updateListView();

    }

    private void FileLocator_DoubleClick(object sender, EventArgs e)
    {


        this.openFileDialog1.InitialDirectory = "c:\\";
        this.openFileDialog1.FilterIndex = 1;
        this.openFileDialog1.RestoreDirectory = true;
        if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            fileLocator.Text = this.openFileDialog1.FileName;
        }

    }

    private void FileLocator_Leave(object sender, EventArgs e)
    {
        if (fileLocator.Text.Length > 0)
        {
            if (!File.Exists(fileLocator.Text))
            {
                MessageBox.Show("Invalid Path");
            }

        }
    }

    private void FileLocator_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (fileLocator.Text.Length > 0)
            {
                if (File.Exists(fileLocator.Text))
                {
                    if (fileBytes.Length > 0)
                    {
                        fileBytes = null;
                    }
                    if (!(fileLocator.Text.EndsWith("png") || fileLocator.Text.EndsWith("jpg") || fileLocator.Text.EndsWith("gif") || fileLocator.Text.EndsWith("svg")))
                    {

                        fileBytes = File.ReadAllBytes(fileLocator.Text);
                    }
                    else
                    {
                        MessageBox.Show("Sorry We Currently Don't Support This Format, Next Release Will incorporat These Features");
                        fileLocator.Text = "";
                    }

                    }
                else
                {
                    MessageBox.Show("Invalid Path");
                }
            }
        }
    }
}
}
    


