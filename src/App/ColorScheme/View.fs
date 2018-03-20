module ColorScheme.View

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.React
open Fable.Core.JsInterop

type CirclePickerProp =
    | CircleSize of int
    | CircleSpacing of int
    | Colors of string[]
    | Width of string
    interface Props.IHTMLProp
let CirclePicker : ComponentClass<obj> = import "CirclePicker" "react-color"
let inline circlePicker (props : CirclePickerProp list) elems =
    from CirclePicker (keyValueList CaseRules.LowerFirst props) elems
let allColors =
    [|
        for r in 0..64..255 do
            for g in 0..64..255 do
                for b in 0..64..255 do
                    yield (sprintf "#%02x%02x%02x" r g b)

    |]

let root model dispatch =
    div [] 
        [
            div [ ClassName "message is-large" ]
                [ str "Select a color scheme" ]
            div []
                [
                    div [ ClassName "message is-medium" ]
                        [ str "Background" ] 
                    circlePicker [ CircleSize 20
                                   CircleSpacing 10
                                   Colors allColors
                                   Width "240px" ]
                         []
                ]
            hr []
            str "Fill"
            br []
            hr []
            str "Outline"
            br []
        ]

