using System;
using System.Globalization;

namespace StoreOperation.WebApi.Helpers.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToTurkceMetin(this DateTime dateTime)
        {
            return dateTime.ToString("dd MMMM yyyy dddd", CultureInfo.CreateSpecificCulture("tr-TR"));
        }
    }
}