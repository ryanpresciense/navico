module Tests

open Expecto
open SnakesAndLadders

[<Tests>]
let ``Token can move across the board`` =
    test "Starting a game" {
        //Given the game is started
        let game = Game.start()
        //When the token is placed on the board
                       .Place(Token.create ())
        //Then the token is on square 1
        Expect.equal (game.Token()) 
                     (Some (Token.Token (uint8 1))) 
                     "Token is not on square 1"
        
    }


[<EntryPoint>]
let runner argv = 
    Tests.runTestsInAssembly defaultConfig argv
