module ColorScheme.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.ReactColor
open Fable.Import.Collapse

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
            hr []
            str "Fill"
            br []
            collapse [ IsOpened false ]
                [
                    str "Hello"
                    str "World"
                ] 
            str "Outline"
            br []
        ]

