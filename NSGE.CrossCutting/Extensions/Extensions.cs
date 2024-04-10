using System.Text.Json;

namespace NSGE.CrossCutting.Extensions
{
    public static class Extensions
    {
        public static string ToJson(this double value)
        {
            return JsonSerializer.Serialize(value);
        }

        public static double ToDouble(this string value)
        {
            double dValue = 0;

            double.TryParse(value, out dValue);

            return dValue;
        }

        public static string ToMoney(this double value, bool withSymbol = false)
        {
            var format = withSymbol ? "C2" : "N2";

            return value.ToString(format);
        }

        public static DateTime? ToDate(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            DateTime date;
            if (DateTime.TryParse(value, out date))
                return date;

            return null;
        }

        public static int? ToInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            int numero;
            if (int.TryParse(value, out numero))
                return numero;

            return null;
        }

        public static string GerarId()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string ToFormatDate(this DateTime? date, string format = "dd/MM/yyyy")
        {
            if (!date.HasValue)
                return null;

            return date.Value.ToString(format);
        }
    }
}