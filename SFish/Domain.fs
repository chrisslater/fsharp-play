module Domain 

open FSharp.Json

type Square = {
    [<JsonField("side")>] 
    Side: float;
}

type Rectangle = {
    [<JsonField("width")>] 
    Width: float; 
    [<JsonField("length")>]
    Length: float;
}

[<JsonUnion(Mode = UnionMode.CaseKeyAsFieldValue, CaseKeyField="key", CaseValueField="value")>]
type Shape =
    | Rectangle of Rectangle
    | Square of Square