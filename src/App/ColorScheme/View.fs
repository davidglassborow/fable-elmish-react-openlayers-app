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
    | Foreground.Single -> true
    | Foreground.Random _ -> false

let singleColorPicker = 
    div [ Props.Style 
            [ CSSProp.BackgroundColor "#d0d0d0"
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
                                Switch.OnChange (fun _ -> dispatch ToggleForegroundRandom)
                            ] 
                            [ str "One color" ]
                          collapse [ IsOpened fgOneColor ] 
                            [
                                singleColorPicker                           
                            ]
                          Switch.switch 
                            [ 
                                Switch.Checked (fgOneColor |> not) 
                                Switch.OnChange (fun _ -> dispatch ToggleForegroundRandom)
                            ] 
                            [ str "Completely random" ] 
                          Switch.switch 
                            [ 
                                Switch.Checked (fgOneColor |> not) 
                                Switch.OnChange (fun _ -> dispatch ToggleForegroundRandom)
                            ] 
                            [ str "From palette" ] 
                          collapse [ IsOpened (fgOneColor |> not) ] 
                            [
                                Switch.switch [ Switch.IsThin; Switch.Checked true ] [ str "Random" ]
                                Switch.switch [ Switch.IsThin; Switch.Checked false ] [ str "Based on orientation" ]
                                Switch.switch [ Switch.IsThin; Switch.Checked false ] [ str "Based on distance from center" ]
                                collapse [ IsOpened true ]
                                    [ foregroundPaletteDiv ]                       
                            ]
                        ]
                ]
        ]
