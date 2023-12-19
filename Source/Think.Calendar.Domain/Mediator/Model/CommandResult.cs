namespace Think.Calendar.Domain.Mediator.Model
{
    public class CommandResult<TData>
    {
        public bool Success { get; set; }
        public TData Data { get; set; }
    }
}
