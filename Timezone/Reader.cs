using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Reader : IReader, IDisposable
    {
        //Get filepath from App.config 
        public static string timeZoneFileLocation = ConfigurationManager.AppSettings["TimeZoneFileLocation"];

        public List<Tuple<string, string>> Read()
        {
            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();

            var fileRows = File.ReadAllLines(timeZoneFileLocation);

            for (int i = 0; i < fileRows.Length; i++)
            {
                string currentRow = fileRows[i];
                string[] columnValues = currentRow.Split(' ');
                Tuple<string, string> timeZone = new Tuple<string, string>(columnValues[0], columnValues[1]);
                lReturn.Add(timeZone);
            }

            return lReturn;
        }

        public void Dispose()
        {
        }
    }
}
