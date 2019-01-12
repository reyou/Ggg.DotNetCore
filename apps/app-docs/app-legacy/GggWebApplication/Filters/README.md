 https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#feedback

Implement either the synchronous or the async version of a filter interface, 
not both. The framework checks first to see if the filter implements 
the async interface, and if so, it calls that. If not, it calls the 
synchronous interface's method(s). If you were to implement both interfaces on 
one class, only the async method would be called. When using abstract classes 
like ActionFilterAttribute you would override only the synchronous methods or 
the async method for each filter type.

