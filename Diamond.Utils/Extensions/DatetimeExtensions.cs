using Diamond.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DatetimeExtensions
{
    public static string Format(this DateTime? date, DateTimeFormatEnum to)
    {
        if (!date.HasValue)
            return "";

        return date.Value.Format(to);
    }

    public static string Format(this DateTime date, DateTimeFormatEnum to)
    {
        string dateStr = date.ToString();

        switch (to)
        {
            case DateTimeFormatEnum.DataBase:
                dateStr = date.ToString("yyyy-MM-dd HH:mm:ss"); break;
            case DateTimeFormatEnum.DataBaseOnlyDate:
                dateStr = date.ToString("yyyy-MM-dd"); break;
            case DateTimeFormatEnum.Presentation:
                dateStr = $"{date.ToString("dd/MM/yyyy")} ás {date.ToString("HH:mm")}"; break;
            case DateTimeFormatEnum.PresentationOnlyDate:
                dateStr = $"{date.ToString("dd/MM/yyyy")}"; break;
            case DateTimeFormatEnum.PresentantionOnlyTime:
                dateStr = $"{date.ToString("HH:mm")}"; break;
        }

        return dateStr;
    }
}
