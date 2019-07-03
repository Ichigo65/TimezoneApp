using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Program
    {
        static void Main(string[] args)
        {

            Parser timeZoneParser = new Parser();

            //Read records from the Timezone.txt file
            using (Reader fileReader = new Reader())
            {
                List<Tuple<string, string>> lTimes = fileReader.Read();
                string time;
                string timezone;
                DateTime? timezoneTime;

                //send each record to the parser
                foreach (var record in lTimes)
                {
                    time = record.Item1;
                    timezone = record.Item2;
                    timezoneTime = timeZoneParser.DisplayTime(time, timezone);
                    if (timezoneTime != null)
                    {
                        string convertedTime = ((DateTime)timezoneTime).ToShortTimeString();
                        //print output to console
                        Console.WriteLine("The time in the UK is {0} and the time in {1} is {2}", time, timezone, convertedTime);
                    }

                }

            }

            Console.ReadLine();
        }
    }
}
