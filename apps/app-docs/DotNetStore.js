//=============================================================================
/** Provision the runtime package store by executing dotnet store with the
 * package store manifest, runtime, and framework */
var PATH_TO_MANIFEST_FILE = "packages.csproj";
var RUNTIME_IDENTIFIER = "win10-x64";
var FRAMEWORK = "netcoreapp2.0";
var FRAMEWORK_VERSION = "2.0.0";
var store = "dotnet store --manifest <PATH_TO_MANIFEST_FILE> --runtime <RUNTIME_IDENTIFIER> --framework <FRAMEWORK> --framework-version <FRAMEWORK_VERSION>";
//=============================================================================