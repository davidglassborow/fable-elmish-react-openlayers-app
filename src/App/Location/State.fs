module Location.State
open Elmish
open Fable.Import
open Types
open Fable.Helpers

let init () : Model * Cmd<Msg> =
    printfn "Initialising Location State"
    let imageType = Cadastral.ImageType.imageTypes.[0]
    {   name = imageType.Name
        imageType = imageType 
        coordinate = (imageType.Lon, imageType.Lat) |> Ol.proj.fromLonLat
        zoom = imageType.DefaultZoom
        orientation = ReactOpenLayers.Landscape
    }, Cmd.none

let update msg model : Model * Cmd<Msg> =
    printfn "Updating Location State"
    match msg with
    // | SelectLocation imageType ->
    //     { model with
    //         imageType = imageType }, Cmd.none
    | ChangePlace (name, coordinate, zoom) ->
        { model with
            name = name
            coordinate = coordinate
            zoom = zoom
        }, Cmd.none
    | ChangeOrientation orientation ->
        { model with orientation = orientation }, Cmd.none
 