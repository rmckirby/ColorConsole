#r @"packages/FAKE/tools/FakeLib.dll"

open Fake

let buildDir = "./build/"
let testDir  = "./test/"

Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir;]
)

Target "BuildCore" (fun _ ->
    !! "ColorConsole/ColorConsole.csproj"
        |> MSBuildDebug buildDir "Build"
        |> Log "BuildCore Output:"
)

Target "BuildTest" (fun _ ->
    !! "ColorConsole.Test/ColorConsole.Test.csproj"
        |> MSBuildDebug testDir "Build"
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

Target "Default" (fun _ ->
    trace "ColorConsole"
)

"Clean"
    ==> "BuildCore"
    ==> "BuildTest"
    ==> "UnitTest"
    ==> "Default"
    
RunTargetOrDefault "Default"
