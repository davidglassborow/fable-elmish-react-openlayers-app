module Fable.Import.Collapse

open Fable.Core
open Fable.Helpers.React
open Fable.Import.React
open Fable.Core.JsInterop

type CollapseProp =
    | IsOpened of bool
    interface Props.IHTMLProp

let Collapse : ComponentClass<obj> = import "Collapse" "react-collapse"
let inline collapse (props : CollapseProp list) elems =
    from Collapse (keyValueList CaseRules.LowerFirst props) elems