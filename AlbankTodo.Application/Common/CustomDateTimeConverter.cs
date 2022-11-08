using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
