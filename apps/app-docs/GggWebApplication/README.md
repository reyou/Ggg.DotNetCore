dotnet run
http://localhost:11781/filterexamples  
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