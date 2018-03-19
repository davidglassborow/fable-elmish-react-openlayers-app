module ColorScheme.View
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.ReactOpenLayers
open Fable.Import
open Fable.Import.React
open Fable.Core.JsInterop

open Types

//let circlePicker : IHTMLProp list -> React.ReactElement list -> React.ReactElement = import "CirclePicker" "react-color"  
// let inline circlePicker (props: IHTMLProp list) (children: ReactElement list) = 
//     Fable.Helpers.React.ofImport "CirclePicker" "react-color" props children
let CirclePicker : ComponentClass<obj> = import "CirclePicker" "react-color"
let inline circlePicker (props : IHTMLProp list) elems =
    Fable.Helpers.React.from CirclePicker (keyValueList CaseRules.LowerFirst props) elems

let root model dispatch =
    div [] 
        [
            div [ ClassName "message is-large" ]
                [ str "Select a color scheme" ]
            div []
                [
                    str "Background" 
                    circlePicker [] [] 
                ]
            hr []
            str "Fill"
            br []
            hr []
            str "Outline"
            br []
        ]

