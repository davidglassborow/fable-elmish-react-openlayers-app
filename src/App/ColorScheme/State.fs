module ColorScheme.State
open Elmish
open Fable.Import
open Types
open Fable.Helpers
open Elmish.Browser.Navigation

let init () : Model * Cmd<Msg> =
    { schemeKind = SchemeKind.Random }, Cmd.none
let update msg model : Model * Cmd<Msg> =
    match msg with
    | DoSomething ->
        model, Cmd.none

    // match msg with
    // | SelectLocation imageType ->
    //     printfn "Image type is %s" imageType.Name // TODO remove
    //     { model with imageType = imageType }, Cmd.none
