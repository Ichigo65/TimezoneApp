using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Parser : IParser
    {
        public DateTime? DisplayTime(string time, string timezone)
        {
            DateTime? parsedData = null;

            try
            {
                DateTime ukTime = Convert.ToDateTime(time);
                TimeZoneInfo timezoneCity = null;
                var timezoneList = TimeZoneInfo.GetSystemTimeZones();

                for (int i = 0; i < timezoneList.Count; i++)
                {
                    if (timezoneList[i].DisplayName.IndexOf(timezone) > -1)
                    {
                        timezoneCity = timezoneList[i];
                        var timezoneOffset = timezoneCity.BaseUtcOffset;

                        //DateTime convertedTime = TimeZoneInfo.ConvertTime(ukTime, TimeZoneInfo.Local, timezoneCity);

                        DateTime convertedTime = ukTime.AddHours(timezoneOffset.TotalHours);
                         parsedData = convertedTime;
                    }
                }

            }
            catch(Exception ex)
            {
                 Console.WriteLine("The time value supplied is in an unrecognised format");
            }

            return parsedData;
        }
    }
}
