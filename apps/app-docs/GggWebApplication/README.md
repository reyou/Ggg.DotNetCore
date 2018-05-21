//=============================================================================  
$ cd C:\Github\Ggg.Github\Ggg.DotNetCore\apps\app-docs\GggWebApplication\
$ dotnet run --launch-profile GggWebApplication
//=============================================================================  
Home
http://localhost:11781
//=============================================================================  
Console.WriteLine("GggMessage: " + GetType().FullName + ": ");
//============================================================================= 
You should only write a custom authorization filter if you are writing your own 
authorization framework. Prefer configuring your authorization policies or 
writing a custom authorization policy over writing a custom filter. 
The built-in filter implementation is just responsible for calling the authorization 
system. 

You shouldn't throw exceptions within authorization filters, since nothing will 
handle the exception (exception filters won't handle them). Consider issuing 
a challenge when an exception occurs.

Exception filters:

Are good for trapping exceptions that occur within MVC actions.
Are not as flexible as error handling middleware.
//=============================================================================  
ASP.NET Core doesn't provide async logger methods because logging should 
be so fast that it isn't worth the cost of using async. If you're in a 
situation where that's not true, consider changing the way you log. If your 
data store is slow, write the log messages to a fast store first, then move them 
to a slow store later. For example, log to a message queue that's read and 
persisted to slow storage by another process.
//=============================================================================  
