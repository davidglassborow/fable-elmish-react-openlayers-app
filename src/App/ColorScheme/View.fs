module ColorScheme.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.ReactColor
open Fable.Import.Collapse
open Fulma
open Fulma.Layouts
open Fulma.Extensions
open ColorScheme.Types

let allColors =
    let levels = ["00"; "80"; "ff"]
    [|
        for r in levels do
            for g in levels do
                for b in levels do
                    yield (sprintf "#%s%s%s" r g b)
    |]

let foregroundOneColor (model : ColorScheme.Types.Model) =
    match model.foreground with
    | Foreground.Single -> true
    | Foreground.Random _ -> false

let root model dispatch =
    div [] 
        [
            div [ ClassName "message is-large" ]
                [ str "Select a color scheme" ]
            div [ ]
                [
                    div [ ClassName "message is-medium" ]
                        [ str "Background" ] 
                    circlePicker [ CircleSize 20
                                   CircleSpacing 10
                                   Colors allColors
                                   Width "400px" ]
                         []
                ]
            div [ ]
                [
                    div [ ClassName "message is-medium" ]
                        [ str "Foreground" ] 
                    div [ ]
                        [ Switch.switch 
                            [ 
                                Switch.Checked (model |> foregroundOneColor)
                                Switch.OnChange (fun _ -> dispatch (SetForegroundRandom true)) // TODO set from switch state
                            ] 
                            [ str "One color" ]
                          collapse [ IsOpened (model |> foregroundOneColor) ] 
                            [
                                circlePicker [ CircleSize 20
                                               CircleSpacing 10
                                               Colors allColors
                                               Width "400px" ] []                            
                            ]
                          Switch.switch [ Switch.Checked (model |> foregroundOneColor |> not) ] [ str "Random colors" ] 
                          collapse [ IsOpened (model |> foregroundOneColor |> not) ] 
                            [
                                Switch.switch [ Switch.IsThin; Switch.Checked true ] [ str "Completely random" ]  
                                Switch.switch [ Switch.IsThin; Switch.Checked false ] [ str "Random from palette" ]                            
                                Switch.switch [ Switch.IsThin; Switch.Checked false ] [ str "From building orientation" ]
                            ]
                        ]
                ]
        ]

