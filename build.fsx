#r @"packages/FAKE/tools/FakeLib.dll"

open Fake

let buildDir  = "./build/"

Target "Clean" (fun _ ->
    CleanDirs [buildDir;]
)

Target "BuildCore" (fun _ ->
    !! "ColorConsole/ColorConsole.csproj"
        |> MSBuildDebug buildDir "Build"
        |> Log "BuildCore Output:"
)


Target "Default" (fun _ ->
    trace "ColorConsole"
)

"Clean"
    ==> "BuildCore"
    ==> "Default"
    
RunTargetOrDefault "Default"
