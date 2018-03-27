module ColorScheme.Types
open ColorScheme.Palette
open Fable.Import
open Fable.Helpers

type PaletteAssignment =
| Random
| Orientation
| DistanceFromCenter

type Foreground =
| OneColor
| Random
| FromPalette of PaletteAssignment * Palette

type Model = {
    foreground : Foreground
}

type Msg =
  | SetForeground of Foreground
 