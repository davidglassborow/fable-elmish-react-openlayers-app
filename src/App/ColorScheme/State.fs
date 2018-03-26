module ColorScheme.State
open Elmish
open Fable.Import
open Types
open Fable.Helpers
open Elmish.Browser.Navigation

let init () : Model * Cmd<Msg> =
    { foreground = Foreground.OneColor }, Cmd.none
let update msg model : Model * Cmd<Msg> =
    match msg with
    | SetForeground fg ->
        { model with foreground = fg }, Cmd.none

