# Ggg.DotNetCore
.NET Core Coding practices. 

### MD Syntax
https://github.com/fletcher/MultiMarkdown/blob/master/Documentation/Markdown%20Syntax.md

### .NET Core and .NET Standard
https://msdn.microsoft.com/en-us/magazine/mt842506.aspx

![](/notes/Descriptions%20of%20.NET%20Implementations.png?raw=true "Title")

> You’re probably wondering which APIs .NET Standard covers. If you’re familiar with .NET Framework, then you should be familiar with the BCL, which I mentioned earlier. The BCL is the set of fundamental APIs that are independent of UI frameworks and application models. It includes the **primitive types, file I/O, networking, reflection, serialization, XML and more**.

> All .NET stacks implement some version of .NET Standard. The rule of thumb is that when a new version of a .NET implementation is produced, it will usually implement the latest available version of the .NET Standard.

> .NET Standard is a **specification of APIs that all .NET implementations must provide**. It brings consistency to the .NET family and enables you to build libraries you can use from any .NET implementation. **It replaces PCLs for building shared components.**

![](/notes/.NET%20Core%20SDK%20or%20the%20.NET%20Core%20runtime.PNG "Title")

### Logging in ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1&tabs=aspnetcore2x
> ASP.NET Core doesn't provide async logger methods because logging should 
be so fast that it isn't worth the cost of using async. If you're in a 
situation where that's not true, consider changing the way you log. If your 
data store is slow, write the log messages to a fast store first, then move them 
to a slow store later. For example, log to a message queue that's read and 
persisted to slow storage by another process.
