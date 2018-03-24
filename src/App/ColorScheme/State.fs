module ColorScheme.State
open Elmish
open Fable.Import
open Types
open Fable.Helpers
open Elmish.Browser.Navigation

let init () : Model * Cmd<Msg> =
    { foreground = Foreground.Single }, Cmd.none
let update msg model : Model * Cmd<Msg> =
    match msg with
    | ToggleForegroundRandom ->
        let model' =
            match model.foreground with
            | Foreground.Single -> { model with foreground = (Foreground.Random RandomKind.Completely) }
            | Foreground.Random _ ->  { model with foreground = (Foreground.Single)}
       
        model', Cmd.none

