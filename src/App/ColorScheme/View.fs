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

(*
Color.FromArgb(254, 175,  44)
Color.FromArgb(255,  88, 180)
Color.FromArgb(  0, 161, 215)
Color.FromArgb(221, 239,  77)
Color.FromArgb(255, 211,  54)    
*)

let rgbString (r,g,b)=
    sprintf "#%02x%02x%02x" r g b
let stickyNotes =
    [
        (254, 175,  44)
        (255,  88, 180)
        (  0, 161, 215)
        (221, 239,  77)
        (255, 211,  54)
    ] |> List.map rgbString

let dryWipe =
    [
        (  0,   0,   0)
        (230,   0,   0)
        (  0, 200,   0)
        (  0,   0, 230)
        (100,  50,  50)

    ] |> List.map rgbString    

let colorChip (colorName : string) = 
    div [ Props.Style [ 
                        CSSProp.Background colorName
                        CSSProp.Height "30px"
                        CSSProp.Width "30px"
                        CSSProp.Display "inline-block"
                        CSSProp.TextAlign "center" ] ] [ ]
let palettes =
    div [] 
        [
            div [] ( stickyNotes |> List.map colorChip )
            div [] ( dryWipe |> List.map colorChip )
        ]

let foregroundOneColor (model : ColorScheme.Types.Model) =
    match model.foreground with
    | Foreground.Single -> true
    | Foreground.Random _ -> false

let root model dispatch =
    let fgOneColor = model |> foregroundOneColor
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
                                Switch.Checked fgOneColor
                                Switch.OnChange (fun _ -> dispatch ToggleForegroundRandom)
                            ] 
                            [ str "One color" ]
                          collapse [ IsOpened fgOneColor ] 
                            [
                                circlePicker [ CircleSize 20
                                               CircleSpacing 10
                                               Colors allColors
                                               Width "400px" ] []                            
                            ]
                          Switch.switch 
                            [ 
                                Switch.Checked (fgOneColor |> not) 
                                Switch.OnChange (fun _ -> dispatch ToggleForegroundRandom)
                            ] 
                            [ str "Random colors" ] 
                          collapse [ IsOpened (fgOneColor |> not) ] 
                            [
                                Switch.switch [ Switch.IsThin; Switch.Checked true ] [ str "Completely random" ]  
                                Switch.switch [ Switch.IsThin; Switch.Checked false ] [ str "Random from palette" ]
                                collapse [ IsOpened true ]
                                    [ palettes ]                            
                                Switch.switch [ Switch.IsThin; Switch.Checked false ] [ str "From building orientation" ]
                            ]
                        ]
                ]
        ]

