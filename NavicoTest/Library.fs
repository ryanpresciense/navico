module Tests

open Expecto
open SnakesAndLadders

[<Tests>]
let workingEnvironment =
    test "works" {
    Expect.equal 1 1 "it tests"
    }


[<EntryPoint>]
let runner argv = 
    Tests.runTestsInAssembly defaultConfig argv
