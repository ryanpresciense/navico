module Tests

open Expecto
open SnakesAndLadders

[<Tests>]
let accept =
    testList "Token can move across the board" [
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
        test "Moving a token" {
            //Given the token is on square 1
            let token = Token.create ()
            let game = Game.start()
                           .Place(Token.create ())
            //When the token is moved 3 spaces
                           .Place(token.Move(uint8 3))
            //Then the token is on square 4
            Expect.equal (game.Token()) 
                         (Some (Token.Token (uint8 4))) 
                         "Token is not on square 4"
        
        }
        test "Moving a token again" {
            //Given the token is on square 1
            let token = Token.create ()
            let game = Game.start()
                           .Place(Token.create ())
                           .Place(
                                //When the token is moved 3 spaces
                                token.Move(uint8 3)
                                //And then it is moved 4 spaces
                                     .Move(uint8 4)
                           )
            //Then the token is on square 8
            Expect.equal (game.Token()) 
                         (Some (Token.Token (uint8 8))) 
                         "Token is not on square 8"
         }
    ]
[<EntryPoint>]
let runner argv = 
    Tests.runTestsInAssembly defaultConfig argv
