//=============================================================================
/*Run the tests with the dotnet test command. This command starts the test
 runner specified in the project file.*/
// https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests
//=============================================================================
var dotNetMsTest = {
    "test": "dotnet test",
    "method": "dotnet test --filter Method",
    // Runs tests whose name contains TestMethod1
    "contains": "dotnet test --filter Name~TestMethod1",
    // The ClassName value should have a namespace
    "class name": "dotnet test --filter ClassName=MSTestNamespace.UnitTestClass1",
    // Runs all tests except
    "fully qualified name": "dotnet test --filter FullyQualifiedName!=MSTestNamespace.UnitTestClass1.TestMethod1",
    // Runs tests which are annotated with [TestCategory("CategoryA")]
    "annotated": "dotnet test --filter TestCategory=CategoryA",
    // Runs tests which are annotated with [Priority(3)]
    "priority": "dotnet test --filter Priority=3",
    // Runs tests which have UnitTestClass1 in FullyQualifiedName or TestCategory is CategoryA
    "or": 'dotnet test --filter "FullyQualifiedName~UnitTestClass1|TestCategory=CategoryA"',
    // Runs tests which have UnitTestClass1 in FullyQualifiedName and TestCategory is CategoryA
    "and": 'dotnet test --filter "FullyQualifiedName~UnitTestClass1&TestCategory=CategoryA"',
    // Runs tests which have either FullyQualifiedName containing UnitTestClass1 
    // and TestCategory is CategoryA or Priority is 1.
    "and or": 'dotnet test --filter "(FullyQualifiedName~UnitTestClass1&TestCategory=CategoryA)|Priority=1"	'
}
//=============================================================================
// https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests#xunit
var dotNetxUnit = {
    // Runs only one test, XUnitNamespace.TestClass1.Test1
    "filter": "dotnet test --filter DisplayName=XUnitNamespace.TestClass1.Test1",
    // Runs all tests except XUnitNamespace.TestClass1.Test1
    "except": "dotnet test --filter FullyQualifiedName!=XUnitNamespace.TestClass1.Test1",
    // Runs tests whose display name contains TestClass1
    "contains": "dotnet test --filter DisplayName~TestClass1",
    // Runns tests whose FullyQualifiedName contains XUnit. Available in vstest 15.1+
    "contains 2": "dotnet test --filter XUnit",
    // Runs tests which have [Trait("Category", "bvt")]
    "trait": "dotnet test --filter Category=bvt",
    // Runs tests which has TestClass1 in FullyQualifiedName or Category is Nightly
    "or": 'dotnet test --filter "FullyQualifiedName~TestClass1 | Category=Nightly',
    // Runs tests which has TestClass1 in FullyQualifiedName and Category is Nightly
    "and": 'dotnet test --filter "FullyQualifiedName~TestClass1&Category=Nightly"',
    // Runs tests which have either FullyQualifiedName containing TestClass1 and Category is CategoryA or Priority is 1.
    "and or": 'dotnet test --filter "(FullyQualifiedName~TestClass1&Category=Nightly)|Priority=1"',
}
//=============================================================================
// https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-published-output
var testDll = {
    "dll": "dotnet vstest <MyPublishedTests>.dll"
}
//=============================================================================