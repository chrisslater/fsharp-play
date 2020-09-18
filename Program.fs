open System
open System.Text
open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open FSharp.Control.Tasks.V2.ContextInsensitive
open Giraffe
open ShapesDomain
open Newtonsoft.Json.Linq


let parseShapes (listOfDto: JArray): Shape =
    let value = listOfDto.Children<JProperty>().Value()
    match value["key"] with
    | ()




let postRootHandler: HttpHandler =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        task {
            let serializer = ctx.GetJsonSerializer()
            let! bodyText = ctx.ReadBodyFromRequestAsync()

            JArray.Parse(bodyText)
            |> parseShapes   
            

            let body = serializer.Deserialize<Payload> bodyText;
            

            ctx.SetStatusCode 201

            return! text "OK" next ctx
        }


let webApp =
    choose [
        GET >=> choose [
            route "/ping"   >=> text "pong"
        ]

        POST >=> choose [
            route "/" >=> postRootHandler
        ]
    ]

let configureApp (app : IApplicationBuilder) =
    // Add Giraffe to the ASP.NET Core pipeline
    app.UseGiraffe webApp

let configureServices (services : IServiceCollection) =
    // Add Giraffe dependencies
    services.AddGiraffe() |> ignore

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .Configure(configureApp)
                    .ConfigureServices(configureServices)
                    |> ignore)
        .Build()
        .Run()
    0