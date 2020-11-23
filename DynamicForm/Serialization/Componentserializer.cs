using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using blazorapp.DynamicForm.Components;

namespace blazorapp.DynamicForm.Serialization
{
    public class Componentserializer : JsonConverter<IFormComponent>
    {
        public override IFormComponent Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            var parts = GetComponentAsDictionary(ref reader, options);
            var control = parts["control"].ToString();

            switch (control)
            {
                case "Textbox": return new TextboxFormComponent(parts);
                case "Select": return new SelectFormComponent(parts);
                case "Radio": return new RadioFormComponent(parts);
                default: throw new InvalidOperationException($"Invalid control: {control}");
            }
        }

        private Dictionary<string, object> GetComponentAsDictionary(ref Utf8JsonReader reader,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

            var dictionary = new Dictionary<string, object>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject) return dictionary;

                // Get the key.
                if (reader.TokenType != JsonTokenType.PropertyName) throw new JsonException();

                var propertyName = reader.GetString();

                // Get the value.
                var v = JsonSerializer.Deserialize<object>(ref reader, options);

                // Add to dictionary.
                dictionary.Add(propertyName, v);
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, IFormComponent value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}