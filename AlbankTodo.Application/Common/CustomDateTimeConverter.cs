using Newtonsoft.Json.Converters;

namespace AlbankTodo.Application.Common
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            DateTimeFormat = "dd.MM.yyyy";
        }

        public CustomDateTimeConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
