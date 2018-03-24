module ColorScheme.Types
open Fable.Import
open Fable.Helpers

type RandomKind =
| Completely
| FromPallette
| FromOrientation

type Foreground =
| Single
| Random of RandomKind

type Model = {
    foreground : Foreground
}

type Msg =
  | SetForegroundRandom of bool 
 