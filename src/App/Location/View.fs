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
                div [ ClassName "column is-two-third" ]
                    [
                        olMap [
                            Center model.coordinate
                            Zoom model.zoom
                            Orientation model.orientation
                        ] []
                    ]
                div [ ClassName "column is-one-third" ]
                    [
                        span [ ClassName "column box" ] 
                            [ 
                                div [ ClassName "field has-addons" ]
                                    [
                                        div [ ClassName "control" ]
                                            [
                                                input [ ClassName "input"
                                                        Placeholder "Search for places"
                                                        Type "text" ]
                                            ]
                                        div [ ClassName "control" ]
                                            [
                                                a [ ClassName "button is-info" ]
                                                    [ 
                                                        str "Search"
                                                    ]
                                            ]
                                    ]
                            ] 
                        br []
                        button [ ClassName "button is-success" ]
                            [ str "Select" ]
                    ]
            ]
    ]