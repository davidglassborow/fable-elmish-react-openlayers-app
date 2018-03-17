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
        span [] [
            str "Buildings in Great Britain"
            img [ Props.Src @"https://cadastral.blob.core.windows.net/thumbnails/gb.png"
                  (Props.OnClick (fun _ -> dispatch (SelectLocation))) ] 
            str "Tax Lots in NYC"
            img [ Props.Src @"https://cadastral.blob.core.windows.net/thumbnails/nyc.png"
                  (Props.OnClick (fun _ -> dispatch (SelectLocation))) ] ] ]       

