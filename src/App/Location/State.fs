module Location.State
open Elmish
open Fable.Import
open Types
open Fable.Helpers

let init () : Model * Cmd<Msg> =
    let imageTypeIndex = 1 // TODO pass through URL?
    let imageType = Cadastral.ImageType.imageTypes.[imageTypeIndex]
    {   name = imageType.Name
        imageTypeIndex = imageTypeIndex 
        coordinate = (imageType.Lon, imageType.Lat) |> Ol.proj.fromLonLat
        zoom = imageType.DefaultZoom
        orientation = ReactOpenLayers.Landscape
    }, Cmd.none

let update msg model : Model * Cmd<Msg> =
    match msg with
    | ChangePlace (name, coordinate, zoom) ->
        { model with
            name = name
            coordinate = coordinate
            zoom = zoom
        }, Cmd.none
    | ChangeOrientation orientation ->
        { model with orientation = orientation }, Cmd.none
 