using System;
using System.Collections.Generic;
using System.Text.Json;

namespace blazorapp.DynamicForm.Components
{
    public class SelectFormComponent : IFormComponent
    {
        public string Control { get; } = "Select";
        public string Name { get; set; }
        
        public string Placeholder { get; set; }
        
        public string[] Options { get; set; }

        public SelectFormComponent(IDictionary<string, object> data)
        {
            Name = data["name"].ToString();
            if (data.TryGetValue("placeholder", out var placeholder))
            {
                Placeholder = placeholder.ToString();
            }

            Options = JsonSerializer.Deserialize<string[]>(data["options"].ToString());
        }
    }
}