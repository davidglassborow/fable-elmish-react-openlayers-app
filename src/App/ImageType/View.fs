module ImageType.View
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.ReactOpenLayers
open Fable.Import
open Types

let root model dispatch =
    div [] [
        div [ ClassName "message is-large" ] [ str "Select an image type" ]
        div [] (Cadastral.ImageType.imageTypes
                 |> List.map (fun imageType -> 
                        article [ ClassName "media"] 
                            [
                                figure [ ClassName "media-left"]
                                    [
                                        p [ ClassName "image is-128x128"] 
                                            [
                                               img [ Props.Src imageType.ThumbnailUrl
                                                     Props.OnClick (fun _ -> dispatch (SelectLocation imageType)) ]
                                            ]
                                    ]
                                div [ ClassName "media-content" ]
                                    [
                                        div [ ClassName "content" ]
                                            [
                                                p []
                                                    [
                                                        strong [ ClassName "label is-large" ] [ str imageType.Name ]
                                                        br []
                                                        small [] [ str imageType.Description ]
                                                        br []
                                                        em [] [ str imageType.Credit ]
                                                    ]
                                            ]
                                    ]
                            ])) ] 

                        // div [] [ img [ Props.Src imageType.ThumbnailUrl
                        //                Props.OnClick (fun _ -> dispatch (SelectLocation imageType)) ]
                        //          str imageType.Name ])) ] 