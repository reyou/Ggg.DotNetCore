//=============================================================================
// Quick Launch -> Package Manager Console
//=============================================================================
var dotNetNew = {
    "create a project using a custom template": "dotnet new <TEMPLATE>",
    "solution": "dotnet new sln",
    // https://docs.microsoft.com/en-us/dotnet/core/tutorials/testing-with-cli
    "xunit": "dotnet new xunit",
    // https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit
    "install the NUnit templates": "dotnet new -i NUnit3.DotNetNew.Template",
    "nunit": "dotnet new nunit",
    "mvc": "dotnet new mvc",
    "console": "dotnet new console",
    "run": "dotnet new classlib",
    "list the built-in templates": "dotnet new -l",
    "uninstalling a template": "dotnet new -u <NUGET_PACKAGE_ID>",
    "uninstall a template from a file system directory": "dotnet new -u <FILE_SYSTEM_DIRECTORY>"
}
//=============================================================================