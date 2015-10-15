#r @"packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.OpenCoverHelper
open Fake.ReportGeneratorHelper

let buildDir     = "./build/"
let testDir      = "./test/"
let reportDir    = "./reports/"
let coverageDir  = testDir + "coverage/"
let coverageFile = coverageDir + "code-coverage.xml"

Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir;]
)

Target "CreateDirs" (fun _ ->
    CreateDir coverageDir
    CreateDir reportDir
)

Target "BuildCore" (fun _ ->
    !! "ColorConsole/ColorConsole.csproj"
        |> MSBuildRelease buildDir "Build"
        |> Log "BuildCore Output:"
)

Target "BuildTest" (fun _ ->
    !! "ColorConsole.Test/ColorConsole.Test.csproj"
        |> MSBuildRelease testDir "Build"
        |> Log "BuildTest Output:"
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
    ==> "BuildCore"
    ==> "BuildTest"
    =?> ("UnitTest", isMono)
    =?> ("UnitTest_WithCoverage", not isMono)
    =?> ("GenerateCoverageReport", not isMono)
    ==> "Default"

RunTargetOrDefault "Default"
