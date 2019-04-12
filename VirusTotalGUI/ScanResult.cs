using System;
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
        private string _result;
        public ScanResult(string filePath, string res = "")
        {
            this._filePath = filePath;
            string [] temp= filePath.Split('/');
            this._fileName = temp.GetValue(temp.Length - 1).ToString();
            this._dateOfScan = DateTime.Now;
            this._checksum = CalculateMD5(filePath);
            this._result = res;
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

        public string Result { get => _result; set => _result = value; }
        public string FilePath { get => _filePath; set => _filePath = value; }
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
    }
}