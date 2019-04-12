using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace VirusTotalGUI
{
    public class ScanResult
    {
        private string _fileName;
        private string _filePath;
        private DateTime _dateOfScan;
        private string _checksum;
        private Dictionary<string,bool> _result;
        public ScanResult(string filePath)
        {
            this._filePath = filePath;
            string [] temp= filePath.Split('/');
            this._fileName = temp.GetValue(temp.Length - 1).ToString();
            this._dateOfScan = DateTime.Now;
            this._checksum = CalculateMD5(filePath);
            this._result = new Dictionary<string, bool>();
        }

        public string FileName { get => _fileName; set => _fileName = value; }
        public DateTime DateOfScan { get => _dateOfScan; set => _dateOfScan = value; }

        public string GetChecksum()
        {
            return _checksum;
        }

        public void SetChecksum()
        {
            _checksum = CalculateMD5(_filePath);
        }

        public string FilePath { get => _filePath; set => _filePath = value; }
        public Dictionary<string, bool> Result { get => _result; set => _result = value; }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
         public string VerifyMalicious()
        {
            String mal = "";
            var result = this.Result;
            bool isMalicious = false; 
            foreach(KeyValuePair<string,bool> verify in result)
            {
                isMalicious = verify.Value | isMalicious;
    
            }
            if (isMalicious == true)
            {
                mal = "Malicious";
            }
            else
            {
                mal = "Not Malicious";
            }
            return mal;
        }
        public override string ToString()
        {
            string name = this._fileName;
            DateTime dos = this._dateOfScan;
            string res = this.VerifyMalicious();
            Dictionary<string, bool> dict = this._result;
            string store = "Filename: " + name + "\n" + "FinalResult: " + res + "\n" + "DateofScan: " + dos.ToString("MM/dd/yyyy HH:mm:ss") + "detailResult: \n\n" ;
            foreach (KeyValuePair<string, bool> verify in dict)
            {
                store += verify.Key + ":" + verify.Value.ToString() + "\n";

            }
            return store;

        }
    }
}