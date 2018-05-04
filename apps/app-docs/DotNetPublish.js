//=============================================================================
// https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore2x
//=============================================================================
// https://docs.microsoft.com/en-us/dotnet/core/deploying/index
// https://docs.microsoft.com/en-us/dotnet/core/deploying/deploy-with-cli
/*Packs the application and its dependencies into a folder for deployment
 to a hosting system.*/
// for deploying applications with all of their dependencies in the same bundle
// this package can be used to deploy in servers
var publish = "dotnet publish";
var publish_release = "dotnet publish -f netcoreapp2.0 -c Release";
var publish_debug = "dotnet publish -f netcoreapp2.0 -c Debug";
// If you have a target manifest file on disk
var manifest = "manifest.xml";
var publish_manifest = "dotnet publish --manifest <PATH_TO_MANIFEST_FILE>";
//=============================================================================
// https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/visual-studio-publish-profiles?tabs=aspnetcore2x#basic-command-line-publishing
// Basic command-line publishing
var web = "dotnet publish c:/webs/web1";
var mkdir = "mkdir C:/MyWebs/test";
var web_release = "dotnet publish -c Release -o C:/MyWebs/test";
// https://technet.microsoft.com/en-us/library/bb490990.aspx?f=255&MSPPError=-2147217396
// Removes (that is, deletes) a directory.
var removedir = "rmdir C:\MyWebs\test /s";
//=============================================================================