namespace SleekFlowTodo.Services.Dtos
{
    public class CreateOrUpdateTodo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public enStatus Status { get; set; }
    }
}
