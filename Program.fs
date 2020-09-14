open Shapes

[<EntryPoint>]
let main argv =
    if argv.Length > 0 then
        readFile argv.[0]

    0 // return an integer exit code
