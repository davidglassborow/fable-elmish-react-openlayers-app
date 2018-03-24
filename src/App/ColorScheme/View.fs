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

let paletteEntry() =
    let colorChip = div [ Props.Style [ CSSProp.Background "yellow"; CSSProp.Width "100px" ] ] [ str "_" ]

    span []
        [
            Tile.ancestor [] 
                [
                    Tile.parent [ ]
                        [
                            Tile.child [ Tile.Size Tile.Is1; Tile.CustomClass "Yellow" ] [ colorChip ]
                            Tile.child [ Tile.Size Tile.Is1 ] [ colorChip ]
                            Tile.child [ Tile.Size Tile.Is1 ] [ colorChip ]
                        ]
                ]
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
                                    [ paletteEntry() ]                            
                                Switch.switch [ Switch.IsThin; Switch.Checked false ] [ str "From building orientation" ]
                            ]
                        ]
                ]
        ]

