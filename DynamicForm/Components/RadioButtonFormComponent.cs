using System;
using System.Collections.Generic;

namespace blazorapp.DynamicForm.Components
{
    public class RadioButtonFormComponent : IFormComponent
    {
        public string Control { get; } = "RadioButton";
        public string Name { get; set; }

        internal RadioButtonFormComponent(IDictionary<string, object> data)
        {
            Name = data["name"].ToString();
        }
    }
}