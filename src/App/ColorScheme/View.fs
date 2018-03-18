module ColorScheme.View
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.ReactOpenLayers
open Fable.Import
open Types

let root model dispatch =
    div [] 
        [
            div [ ClassName "message is-large" ]
                [ str "Select a color scheme" ]
        ]

