module Tests

open Expecto
open SnakesAndLadders

[<Tests>]
let ``Feature 1.1`` =
    testList "Token can move across the board" [
        test "Starting a game" {
            //Given the game is started
            let game = Game.start()
            //When the token is placed on the board
                           .Place(Player.create ())
            //Then the token is on square 1
            Expect.equal (Option.map (fun (x:Player.Player) -> x.Square) game.Player) 
                         (Some (uint8 1)) 
                         "Token is not on square 1"
        
        }
        test "Moving a token" {
            //Given the token is on square 1
            let player = Player.create ()
            let game = Game.start()
                           .Place(player)
            //When the token is moved 3 spaces
                           .Place(player.Move(uint8 3))
            //Then the token is on square 4
            Expect.equal (Option.map (fun (x:Player.Player) -> x.Square) game.Player) 
                         (Some (uint8 4)) 
                         "Token is not on square 4"
        
        }
        test "Moving a token again" {
            //Given the token is on square 1
            let player = Player.create ()
            let game = Game.start()
                           .Place(player)
                           .Place(
                                //When the token is moved 3 spaces
                                player.Move(uint8 3)
                                //And then it is moved 4 spaces
                                     .Move(uint8 4)
                           )
            //Then the token is on square 8
            Expect.equal (Option.map (fun (x:Player.Player) -> x.Square) game.Player) 
                         (Some (uint8 8))
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
            let game = Game.start()
                           .Place(player)
            //When the token is moved 3 spaces
            let game = game.Place(player.Move(uint8 3))
            //Then the token is on square 100
            Expect.equal (Option.map (fun (x:Player.Player) -> x.Square) game.Player) 
                         (Some (uint8 100)) 
                         "Token is not on square 100"
            Expect.equal (Option.map (fun (x:Player.Player) -> x.HasWon) game.Player)
                    (Some (true)) 
                    "Token is not on square 1"
        }
    ]    


[<EntryPoint>]
let runner argv = 
    Tests.runTestsInAssembly defaultConfig argv
