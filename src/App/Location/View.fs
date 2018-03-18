module Location.View
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.ReactOpenLayers
open Fable.Import
open Types

let root model dispatch =
    printfn "Location view %A" model.imageType.Name
    div [] [
        div [ ClassName "message is-large" ] [ str "Select an area" ]
        div [ ClassName "columns" ]
            [
                div [ ClassName "column is-four-fifths"]
                    [
                        div [ ClassName "box padding:1.0rem" ]
                            [
                                olMap [
                                    Center model.coordinate
                                    Zoom model.zoom
                                    Orientation model.orientation
                                ] []
                            ]
                    ]
            ]
        button [ ClassName "button is-success" ]
            [ str "Select" ]
    ]