using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common.Domain.Types.Converters;

/// <summary>
/// <see cref="JsonConverterFactory"/> для <see cref="Id{T}"/>
/// </summary>
public class IdJsonConverterFactory : JsonConverterFactory
{
    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert) =>
        typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Id<>);

    /// <inheritdoc />
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
        (JsonConverter)Activator.CreateInstance(typeof(IdJsonConverter<>).MakeGenericType(new Type[] { typeToConvert.GetGenericArguments()[0] }))!;

    private class IdJsonConverter<T> : JsonConverter<Id<T>>
    {
        /// <inheritdoc />
        public override Id<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            new Id<T>(reader.GetGuid());

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, Id<T> value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value.ToString());
    }
}