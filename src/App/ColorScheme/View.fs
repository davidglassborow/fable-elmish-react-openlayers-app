module ColorScheme.View
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.React
open Fable.Core.JsInterop

type CirclePickerProp =
    | CircleSize of int
    interface Props.IHTMLProp

let CirclePicker : ComponentClass<obj> = import "CirclePicker" "react-color"
let inline circlePicker (props : CirclePickerProp list) elems =
    from CirclePicker (keyValueList CaseRules.LowerFirst props) elems


let root model dispatch =
    div [] 
        [
            div [ ClassName "message is-large" ]
                [ str "Select a color scheme" ]
            div []
                [
                    str "Background" 
                    circlePicker [ CircleSize(50)] [] // CirclePicker. ("circleSize", "50px") ] [] 
                ]
            hr []
            str "Fill"
            br []
            hr []
            str "Outline"
            br []
        ]

