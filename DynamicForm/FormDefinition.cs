using System.Text.Json.Serialization;

namespace blazorapp.DynamicForm
{
    public class FormDefinition
    {
        [JsonPropertyName("controls")]
        public IFormComponent[] Components { get; set; }
    }
}