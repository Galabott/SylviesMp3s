using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarthaService
{
    public static class MarthaResponseConverter<T>
    {
        public static List<T> Convert(MarthaResponse response)
        {
            var result = new List<T>();

            foreach (object o in response.Data)
            {
                var stringContent = o.ToString();
                stringContent.ToString();

                var tempObject = JsonSerializer.Deserialize<T>(stringContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                result.Add(tempObject);
            }

            return result;
        }

        public static async Task<List<T>> ConvertAsync(MarthaResponse response)
        {
            var result = new List<T>();

            foreach (object o in response.Data)
            {
                var stringContent = o.ToString();

                // convert string to stream
                byte[] byteArray = Encoding.UTF8.GetBytes(stringContent);
                //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
                MemoryStream stream = new MemoryStream(byteArray);

                var tempObject = await JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                result.Add(tempObject);
            }

            return result;

        }
    }
}
