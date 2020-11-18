namespace blazorapp.DynamicForm
{
    public interface IFormComponent
    {
        public string Control { get; }
        public string Name { get; set; }
    }
}