module ColorScheme.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.ReactColor
open Fable.Import.Collapse
open Fulma
open Fulma.Layouts
open Fulma.Elements
open Fulma.Extensions
open ColorScheme.Types
open ColorScheme.Palette

let colorChip (colorName : string) = 
    div [ Props.Style [ 
                        CSSProp.Background colorName
                        CSSProp.Height "30px"
                        CSSProp.Width "30px"
                        CSSProp.Display "inline-block"
                        CSSProp.TextAlign "center" ] ] [ ]

let paletteStyle = 
    [ 
        CSSProp.Display "inline-block"
        CSSProp.Margin "2px"
        CSSProp.Padding "2px"

    ]
let selectedPaletteStyle = 
    paletteStyle @
    [ 
        CSSProp.Border "3px"
        CSSProp.BorderRadius "9px"
        CSSProp.BorderStyle "solid"
        CSSProp.BorderColor "purple"  
    ]

let foregroundPaletteDiv = 
    div []
        (
            foregroundPalettes
            |> List.map (fun p -> 
                div [ Props.Style (if p.Name = "Sticky Notes" then selectedPaletteStyle else paletteStyle) ]
                    [
                        Box.box' [ ]
                            [
                                div [ Props.Style [ CSSProp.PaddingLeft "5px"; CSSProp.PaddingRight "5px" ] ]
                                    [
                                        div [] [ str p.Name ]
                                        div [] ( p.Colors |> List.map colorChip )
                                    ]
                            ]
                    ])
        )

let foregroundOneColor (model : ColorScheme.Types.Model) =
    match model.foreground with
    | Foreground.OneColor -> true
    | _ -> false

let foregroundRandom (model : ColorScheme.Types.Model) =
    match model.foreground with
    | Foreground.Random -> true
    | _ -> false

let foregroundFromPalette (model : ColorScheme.Types.Model) =
    match model.foreground with
    | Foreground.FromPalette _ -> true
    | _ -> false

let singleColorPicker = 
    div [ Props.Style 
            [ CSSProp.BackgroundColor "#f5f5f5"
              CSSProp.Padding "8px"
              CSSProp.Width "276px"
              CSSProp.BorderRadius "15px" ] ]
        [
            circlePicker [ CircleSize 20
                           CircleSpacing 10
                           Colors (backgroundPalette.Colors |> Array.ofList)
                           Width "280px" ]
                 []
        ]

let root model dispatch =
    let fgOneColor = model |> foregroundOneColor
    let fgRandom = model |> foregroundRandom
    let fgPalette = model |> foregroundFromPalette
    div [] 
        [
            div [ ClassName "message is-large" ]
                [ str "Select a color scheme" ]
            div [ ]
                [
                    div [ ClassName "message is-medium" ]
                        [ str "Background" ] 
                    singleColorPicker
                ]
            div [ ]
                [
                    div [ ClassName "message is-medium" ]
                        [ str "Foreground" ] 
                    div [ ]
                        [ Switch.switch 
                            [ 
                                Switch.Checked fgOneColor
                                Switch.OnChange (fun _ -> dispatch (SetForeground Foreground.OneColor))
                            ] 
                            [ str "One color" ]
                          collapse [ IsOpened fgOneColor ] 
                            [
                                str "All the shapes will be the color you pick here"
                                singleColorPicker                           
                            ]
                          Switch.switch 
                            [ 
                                Switch.Checked fgRandom 
                                Switch.OnChange (fun _ -> dispatch (SetForeground (Foreground.Random)))
                            ] 
                            [ str "Completely random" ] 
                          collapse [ IsOpened fgRandom ] 
                            [
                                str "The shapes will have completely random colors"
                            ] 
                          Switch.switch 
                            [ 
                                Switch.Checked fgPalette
                                Switch.OnChange (fun _ -> dispatch (SetForeground (Foreground.FromPalette PaletteAssignment.Random)))
                            ] 
                            [ str "From palette" ] 
                          collapse [ IsOpened fgPalette ] 
                            [
                                str "The shapes will have colors based on the assigment method and palette you pick below"
                                Switch.switch 
                                    [ 
                                        Switch.IsThin
                                        Switch.Checked true 
                                        Switch.OnChange (fun _ -> dispatch (SetForeground (Foreground.FromPalette PaletteAssignment.Random)))
                                    ] 
                                    [ str "Use colors picked at random from the palette" ]
                                Switch.switch 
                                    [ 
                                        Switch.IsThin
                                        Switch.Checked false 
                                        Switch.OnChange (fun _ -> dispatch (SetForeground (Foreground.FromPalette PaletteAssignment.Orientation)))
                                    ] 
                                    [ str "Use colors from the palette based on shape orientation" ]
                                Switch.switch 
                                    [ 
                                        Switch.IsThin
                                        Switch.Checked false 
                                        Switch.OnChange (fun _ -> dispatch (SetForeground (Foreground.FromPalette PaletteAssignment.DistanceFromCenter)))
                                    ] 
                                    [ str "Use colors from the palette based on distance from center" ]
                                collapse [ IsOpened fgPalette ]
                                    [ foregroundPaletteDiv ]                       
                            ]
                        ]
                ]
        ]
