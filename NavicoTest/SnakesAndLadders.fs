module SnakesAndLadders

module Token =
    type Token = Token of uint8

    let create () = Token (uint8 1)

module Game =
    type Game = Game of Token.Token option with 
        member this.Place (token:Token.Token) = Game <| Some token
        member this.Token () : Token.Token option = match this with Game x -> x
               
    let start () = Game None