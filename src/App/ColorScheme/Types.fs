module ColorScheme.Types
open Fable.Import
open Fable.Helpers

type PaletteAssignment =
| Random
| Orientation
| DistanceFromCenter

type Foreground =
| OneColor
| Random
| FromPalette of PaletteAssignment

type Model = {
    foreground : Foreground
}

type Msg =
  | SetForeground of Foreground
 