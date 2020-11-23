using System;
using System.Collections.Generic;
using System.Text.Json;

namespace blazorapp.DynamicForm.Components
{
    public class RadioFormComponent : IFormComponent
    {
        public string Control { get; } = "Radio";
        public string Name { get; set; }
        public string[] Options { get; set; }

        public RadioFormComponent(IDictionary<string, object> data)
        {
            Name = data["name"].ToString();

            Options = JsonSerializer.Deserialize<string[]>(data["options"].ToString());
        }
    }
}