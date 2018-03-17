module ImageType.View
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.ReactOpenLayers
open Fable.Import
open Types

let root model dispatch =
    div [] [
        span [] [ str (sprintf "Select Image Type") ]
        span [] (Cadastral.ImageType.imageTypes
                 |> List.map (fun imageType -> 
                        span [] [ str imageType.Name
                                  img [ Props.Src imageType.ThumbnailUrl
                                        Props.OnClick (fun _ -> dispatch (SelectLocation imageType)) ]
                                ])) ]