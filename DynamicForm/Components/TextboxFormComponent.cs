using System.Collections.Generic;

namespace blazorapp.DynamicForm.Components
{
    public class TextboxFormComponent : IFormComponent
    {
        public string Control { get; } = "Textbox";
        public string Name { get; set; }
        public string Placeholder { get; set; }

        public TextboxFormComponent(IDictionary<string, object> data)
        {
            Name = data["name"].ToString();
            if (data.TryGetValue("placeholder", out var placeholder))
            {
                Placeholder = placeholder.ToString();
            }
        }
    }
}