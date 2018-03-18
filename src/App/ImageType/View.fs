module ImageType.View
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.ReactOpenLayers
open Fable.Import
open Types

let root model dispatch =
    div [] [
        div [ ClassName "nav-item is-brand title is-4" ] [ str "Select an image type" ]
        div [] (Cadastral.ImageType.imageTypes
                 |> List.map (fun imageType -> 
                        div [] [ img [ Props.Src imageType.ThumbnailUrl
                                       Props.OnClick (fun _ -> dispatch (SelectLocation imageType)) ]
                                 str imageType.Name ])) ] 