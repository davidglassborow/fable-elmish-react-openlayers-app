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
    | SetForegroundRandom isRandom ->
        let model' =
            if isRandom then
                { model with foreground = (Foreground.Random RandomKind.Completely) }
            else
                { model with foreground = (Foreground.Single)}
       
        model', Cmd.none

