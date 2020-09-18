module ShapesDomain 

open FSharp.Json
open Newtonsoft.Json

type Square = { 
    Side: float;
}

type Rectangle = {
    Width: float; 
    Length: float;
}

type Shape =
    | Rectangle of Rectangle
    | Square of Square