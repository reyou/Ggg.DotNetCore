namespace GggWebApplication.Controllers.LoggingExamples
{
    public interface ITodoRepository
    {
        TodoItem Find(string id);
    }
}