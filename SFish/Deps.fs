module Deps

module String =
    open FSharp.Core

    let toLower (str: string) =
        str.ToLower()

module Array =
    open System

    let isEmpty (arr: Array) =
        arr.Length = 0