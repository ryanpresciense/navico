module SnakesAndLadders

module Die =
    let Seed = System.Random()
    type Roll = Roll of uint8

    let create x =
        match x with
        | x when x >= (uint8 1) && x <= (uint8 6) -> Ok x
        | _ -> Error "Die has 6 sides"

    let roll () = 
        create <| (uint8 (Seed.Next() % 6)) + (uint8 1)

module Token =
    type Token = Token of uint8
                
    let create () = Token (uint8 1)

module Player =
    type Player = Player of Token.Token with
        member this.Move places = 
            let constrainToBoard x places = 
                match x + places with
                    | x' when x' <= (uint8 100) -> x'
                    | _ -> x
            match this with Player (Token.Token x) -> Player <| Token.Token (constrainToBoard x places)
        member this.Roll roller = 
            Result.map this.Move <| roller ()
        member this.Square =
            match this with Player (Token.Token x) -> x
        member this.HasWon =
            this.Square = (uint8 100)

    let create () = Player <| Token.create ()
    
module Game =
    type Game = Game of Player.Player option with 
        member _this.Place (player:Player.Player) = Game <| Some player
        member this.Player : Player.Player option = match this with Game x -> x
               
    let start () = Game None