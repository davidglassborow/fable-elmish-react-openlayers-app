module ColorScheme.Types
open Fable.Import
open Fable.Helpers

type SchemeKind = | Random 

type Model = {
    schemeKind : SchemeKind
}

type Msg =
  | DoSomething 
 