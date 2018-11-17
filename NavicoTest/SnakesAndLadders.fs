module SnakesAndLadders

module Token =
    type Token = Token of uint8
                
    let create () = Token (uint8 1)

module Player =
    type Player = Player of Token.Token with
        member this.Move places = 
            match this with Player (Token.Token x) -> Player <| Token.Token (x + places)
        member this.Square =
            match this with Player (Token.Token x) -> x
        member this.HasWon =
            this.Square = (uint8 100)

    let create () = Player <| Token.create ()
    
module Game =
    type Game = Game of Player.Player option with 
        member this.Place (player:Player.Player) = Game <| Some player
        member this.Player : Player.Player option = match this with Game x -> x
               
    let start () = Game None