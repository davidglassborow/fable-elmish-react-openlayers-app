module Location.View
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.ReactOpenLayers
open Fable.Import
open Types

let root model dispatch =
    printfn "Location view %A" model.imageType.Name
    div [] [
        div [ ClassName "nav-item is-brand title is-4" ] [ str "Select an area" ]
        olMap [
            Center model.coordinate
            Zoom model.zoom
            Orientation model.orientation
        ] []
    ]
