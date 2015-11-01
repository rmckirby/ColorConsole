#r @"packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.OpenCoverHelper
open Fake.ReportGeneratorHelper

let buildDir     = "./build/"
let testDir      = "./test/"
let reportDir    = "./reports/"
let coverageDir  = testDir + "coverage/"
let coverageFile = coverageDir + "code-coverage.xml"

let coreProject            = "ColorConsole/ColorConsole.csproj"
let testProject            = "ColorConsole.Test/ColorConsole.Test.csproj"
let integrationTestProject = "ColorConsole.Test.Integration/ColorConsole.Test.Integration.csproj"

let coreProjects = [coreProject;]
let testProjects = [testProject; integrationTestProject;]

Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir;]
)

Target "CreateDirs" (fun _ ->
    CreateDir coverageDir
    CreateDir reportDir
)

Target "Build_Core_Assemblies" (fun _ ->
        MSBuildRelease buildDir "Build" coreProjects
            |> Log "Build_Core_Assemblies Output:"
)

Target "Build_Test_Assemblies" (fun _ ->
        MSBuildRelease testDir "Build" testProjects
            |> Log "Build_Test_Assemblies Output:"
)

Target "UnitTest" (fun _ ->
    !! (testDir + "/ColorConsole.Test.dll")
        |> NUnit (fun p ->
            {p with
                DisableShadowCopy = true;
                ShowLabels = false;
            }
        )
)

Target "UnitTest_WithCoverage" (fun _ ->
    "/noshadow " + testDir + "ColorConsole.Test.dll "
        |> OpenCover (fun p ->
            {p with
                ExePath = "packages/tools/OpenCover/tools/OpenCover.Console.exe"
                TestRunnerExePath = "packages/NUnit.Runners/tools/nunit-console.exe"
                Output = coverageFile
                Filter = "+[ColorConsole*]* -[*.Test*]*"
                Register = RegisterUser
            }
        )
)

Target "GenerateCoverageReport" (fun _ ->
    [coverageFile;]
        |> ReportGenerator (fun p ->
            {p with
                ExePath = "packages/tools/ReportGenerator/tools/ReportGenerator.exe"
                TargetDir = reportDir
            }
        )
)

Target "Default" DoNothing

"Clean"
    ==> "CreateDirs"
    ==> "Build_Core_Assemblies"
    ==> "Build_Test_Assemblies"
    =?> ("UnitTest", isMono)
    =?> ("UnitTest_WithCoverage", not isMono)
    =?> ("GenerateCoverageReport", not isMono)
    ==> "Default"

RunTargetOrDefault "Default"
