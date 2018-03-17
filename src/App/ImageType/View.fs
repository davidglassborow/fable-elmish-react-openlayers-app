module ImageType.View
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.ReactOpenLayers
open Fable.Import
open Types

let placeButton dispatch (name, lon, lat, zoom) =
    button [ OnClick <| fun _ ->
        ChangePlace (name, Ol.proj.fromLonLat ((lon, lat)), zoom)
            |> dispatch
    ] [ str name ]

let orientationButton dispatch (name, orientation) =
    button [
        OnClick (fun _ -> ChangeOrientation orientation |> dispatch)
    ] [ str name ]

let root model dispatch =
    div [] [
        span [] [ str (sprintf "Select Image Type") ]
        span [] (Cadastral.ImageType.imageTypes
                 |> List.map (fun imageType -> 
                        span [] [ str imageType.Name
                                  img [ Props.Src imageType.ThumbnailUrl
                                        Props.OnClick (fun _ -> dispatch (SelectLocation)) ]
                                ])) ]
