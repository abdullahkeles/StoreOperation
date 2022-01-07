using System;

namespace StoreOperation.WebApi.Helpers.Extensions
{
    public static class EnumExtensions
    {
        public static int? ToInt(this Enum status)
        {
            return Convert.ToInt32(status);
        }
    }
}
