using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpahQL_initial.Models
{
    public class ItemData
    {
        public long Id { get; init; }
        //Name of the city
        public string HolidayName { get; set; }
        public bool CountrySpecificHoliday { get; set; }
        public bool StateSpecificHoliday { get; set; }
        public bool CitySpecificHoliday { get; set; }
        public int RecurrenceType { get; set; }

    }
}
