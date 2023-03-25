using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moment.Models.Extensions;

public static class DateTimeExtensions
{

    public static DateTime InTheWeek(this DateTime date)
    {
        return DateTime.Now;
    }

    public static bool IsWeekend(this DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;
        else return false;
    }
}
