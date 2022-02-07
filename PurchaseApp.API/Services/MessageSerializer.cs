using System.Text.Json;

namespace PurchaseApp.API.Services
{
    public class MessageSerializer<T>
    {
        private readonly T _data;

        public MessageSerializer(T data)
        {
            _data = data;
        }

        public string Serialize() => JsonSerializer.Serialize(_data);
    }
}
