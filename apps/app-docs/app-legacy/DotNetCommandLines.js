//=============================================================================
// .NET Core command-line interface (CLI) tools
// https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x
// https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet?tabs=netcore2x
// https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-with-xplat-cli
//=============================================================================
// https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x
var dotnet = {
    "restore": "dotnet restore",
    // Execute dotnet build to compile the changes.
    "build": "dotnet build",
    "run": "dotnet run",
    "Cleans the output of a project": "dotnet clean",
    "clears or lists local NuGet resources": "dotnet nuget locals <CACHE_LOCATION> [(-c|--clear)|(-l|--list)] [--force-english-output] [-h|--help]",
    "Displays the paths of all the local cache directories": "dotnet nuget locals –-list all",
    "Displays the path for the local http-cache directory": "dotnet nuget locals --list http-cache",
    "Clears all files from all local cache directories": "dotnet nuget locals --clear all",
    "list references": "dotnet list reference"
}
//=============================================================================
// tools -> nuget package manager -> package manager console
var dotnetAdd = {
    // https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package
    "package": "dotnet add package Newtonsoft.Json",
    "reference": "dotnet add reference ../PrimeService/PrimeService.csproj",
    "sln add": " dotnet sln add .\PrimeService.Tests\PrimeService.Tests.csproj"
}
//=============================================================================
// https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-with-xplat-cli
var dotnet_dll = function () {
    /*Alternatively, you can also execute dotnet build to compile the code
     without running the build console applications. This results in a
    compiled application as a DLL file that can be run with dotnet
    bin\Debug\netcoreapp1.0\Hello.dll on Windows (use / for non-Windows systems).
    You may also specify arguments to the application as you'll see later on the topic.*/
    var dotnetBin = "dotnet bin\Debug\netcoreapp1.0\Hello.dll";
    return dotnetBin;
}
//=============================================================================

