module ColorScheme.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.ReactColor
open Fable.Import.Collapse
open Fulma
open Fulma.Layouts
open Fulma.Extensions

let allColors =
    let levels = ["00"; "80"; "ff"]
    [|
        for r in levels do
            for g in levels do
                for b in levels do
                    yield (sprintf "#%s%s%s" r g b)
    |]

let root model dispatch =
    div [] 
        [
            div [ ClassName "message is-large" ]
                [ str "Select a color scheme" ]
            div [ ]
                [
                    div [ ClassName "message is-medium" ]
                        [ str "Background" ] 
                    circlePicker [ CircleSize 20
                                   CircleSpacing 10
                                   Colors allColors
                                   Width "400px" ]
                         []
                ]
            div [ ]
                [
                    div [ ClassName "message is-medium" ]
                        [ str "Foreground" ] 
                    div [ ]
                        [ Switch.switch [ ] [ str "One color" ]
                          collapse [ IsOpened true ] 
                            [
                                circlePicker [ CircleSize 20
                                               CircleSpacing 10
                                               Colors allColors
                                               Width "400px" ] []                            
                            ]
                          Switch.switch [ ] [ str "Random colors" ] 
                          collapse [ IsOpened true ] 
                            [
                                Switch.switch [ Switch.IsThin ] [ str "Completely random" ]  
                                Switch.switch [ Switch.IsThin ] [ str "Random from palette" ]                            
                                Switch.switch [ Switch.IsThin ] [ str "From building orientation" ]
                            ]
                        ]
                ]
        ]

