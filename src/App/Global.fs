module Global
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

type Page = ImageType | Location | ColorScheme
let toHash = function
    | ImageType -> "#imagetype"
    | Location -> "#location"
    | ColorScheme -> "#colorscheme"
