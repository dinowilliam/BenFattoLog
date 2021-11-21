using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BenFattoLog.Utils.Converters.Json {
    class IPAddressConverter : JsonConverter<IPAddress> {
        public override bool CanConvert(Type objectType) {
            return (objectType == typeof(IPAddress));
        }

        public override IPAddress Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => IPAddress.Parse(reader.GetString());

        public override void Write(Utf8JsonWriter writer, IPAddress value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());


    }
}
