module Global
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

type Page = ImageType | Location
let toHash = function
    | ImageType -> "#imagetype"
    | Location -> "#location"
