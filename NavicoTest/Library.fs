module Tests

open Expecto
open SnakesAndLadders

[<Tests>]
let ``Feature 1.1`` =
    testList "Token can move across the board" [
        test "Starting a game" {
            //Given the game is started
            //When the token is placed on the board
            let player = Player.create()
            //Then the token is on square 1
            Expect.equal player.Square
                         (uint8 1)
                         "Token is not on square 1"
        
        }
        test "Moving a token" {
            //Given the token is on square 1
            let player = (Player.create())
            //When the token is moved 3 spaces
                          .Move(uint8 3)
            //Then the token is on square 4
            Expect.equal player.Square
                         (uint8 4)
                         "Token is not on square 4"
        
        }
        test "Moving a token again" {
            //Given the token is on square 1
            let player = (Player.create ())
            //When the token is moved 3 spaces
                          .Move(uint8 3)
            //And then it is moved 4 spaces
                          .Move(uint8 4)
            //Then the token is on square 8
            Expect.equal player.Square
                         (uint8 8)
                         "Token is not on square 8"
         }
    ]

[<Tests>]
let ``Feature 1.2`` =
    testList "Player can win the game" [
        test "Winning" {
            //Given the token is on square 97
            let player = Player.create ()

            let player = player.Move(uint8 96)
            //When the token is moved 3 spaces
            let player = player.Move(uint8 3)
            //Then the token is on square 100
            Expect.equal player.Square
                         (uint8 100)
                         "Token is on square 100"
            Expect.isTrue player.HasWon
                    "And the player has won the game"
        }
        test "Not winning because you need to move the exact number of remaining squares" {
            //Given the token is on square 97
            let player = Player.create ()
            let player = player.Move(uint8 96)
            //When the token is moved 4 spaces
                               .Move(uint8 4)
            //Then the token is on square 97
            Expect.equal player.Square
                         (uint8 97)
                         "Token is on square 97"
            Expect.isFalse player.HasWon
                    "And the player has not won the game"
        }
    ]    

[<Tests>]
let ``Feature 1.3`` =
    testList "Moves are determined by dice rolls" [
        test "The die has six sides" {
            //Given the game has started
            //When the player rolls a die
            //Then the result should be between 1-6 inclusive
            [1..6] |>
            List.map 
                (fun x -> Expect.isOk (Die.create (uint8 x)) "Rolling 1..6") 
            |>ignore
            Expect.isError (Die.create(uint8 0)) "Cannot roll less than 1"
            Expect.isError (Die.create(uint8 7)) "Cannot roll more than 6"
        }
        test "Player rolling" {
            //Given the player rolls a 4
            let rolla4 = (Player.create ()).Roll (fun () -> Ok(uint8 4))
            //When they move their token
            
            Expect.isOk rolla4 "Valid roll"
            Result.map
                (fun (p:Player.Player) -> 
                Expect.equal (p.Square) (uint8 5) "Then the token should move 4 spaces")
                rolla4
            |> ignore
        }
    ]


[<EntryPoint>]
let runner argv = 
    Tests.runTestsInAssembly defaultConfig argv
