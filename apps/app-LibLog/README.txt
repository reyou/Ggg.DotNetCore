https://github.com/damianh/LibLog/wiki/Using
//=============================================================================
Examples
https://github.com/damianh/LibLog/tree/master/src
//=============================================================================
https://www.nuget.org/packages/LibLog
Install-Package LibLog -Version 5.0.0
//=============================================================================
A source code package designed primarily for library and framework authors who 
want dependency free logging support in their component. Also useful in end 
applications. As of 5.0.0 it works with NetStandard2.0 and SDK projects. 
For .NET 4.x support and legacy project formats, use 4.x versions.

If you are a library or framework author and you wish to provide logging 
support in your component there are a  number of options: 
1) Depend on a specific logging framework 
2) Depend on Common.Logging 
3) Implement your own ILog interface and make your consumers wire it up.

Option 1 is not desirable because it forces your users to use a particular framework. 
Option 2 is not desirable because it will add yet more nuget package dependencies and 
project references with associated versioning concerns in addition to wiring up. 
Option 3 is desirable because it is dependency free but requires that your users 
to remember to write an adapter and wire things up.

This package is a variation of option 3 but will automatically wire things up too.
- It will add an ILog, ILogProvider etc to YourRootNamespace.Logging
- ILog is one method to implement
- Using optimized reflection, it transparently supports NLog, Log4Net, 
Serilog and Loupe without any wiring up required by an end user, if the end 
user simply has a reference to any of these logging frameworks.
//=============================================================================
https://serilog.net/
//=============================================================================
$ Install-Package Serilog
$ Install-Package Serilog.Sinks.Console
$ Install-Package Serilog.Sinks.File
//=============================================================================