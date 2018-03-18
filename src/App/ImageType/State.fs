module ImageType.State
open Elmish
open Fable.Import
open Types
open Fable.Helpers
open Elmish.Browser.Navigation

let init () : Model * Cmd<Msg> =
    { imageType = Cadastral.ImageType.imageTypes.[0] }, Cmd.none
let update msg model : Model * Cmd<Msg> =
    match msg with
    | SelectLocation imageType ->
        printfn "Image type is %s" imageType.Name // TODO remove
        { model with imageType = imageType }, Cmd.none
        //{ imageType = imageType }, Navigation.newUrl "#location"  

