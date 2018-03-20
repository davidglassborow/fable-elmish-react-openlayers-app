module Fable.Import.ReactColor

open Fable.Core
open Fable.Helpers.React
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