module Shapes

open System.IO
open FSharp.Json
open ShapesDomain

let private getArea shape =
    match shape with
    | Square s -> s.Side * s.Side
    | Rectangle r -> r.Width * r.Length

let internal shapeToString shape =
    match shape with
    | Rectangle _ -> "rectangle"
    | Square _ -> "square"    

let private printShape shape =
    let shapeName = shapeToString shape
    let area = getArea shape

    printfn "Sample area of %s is %0.1f" shapeName area 

let readText (filename: string) = 
    filename
    |> File.ReadAllText 
    |> Json.deserialize<Shape list>
    |> List.map printShape
    |> ignore
