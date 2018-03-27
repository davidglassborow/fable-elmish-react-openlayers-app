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

let paletteIsSelected (model : ColorScheme.Types.Model) (palette : Palette) =
    match model.foreground with
    | FromPalette (_, p) -> p = palette
    | _ -> false
let foregroundPaletteDiv model dispatch = 
    div []
        (
            foregroundPalettes
            |> List.map (fun p -> 
                div [ Props.Style (if paletteIsSelected model p then selectedPaletteStyle else paletteStyle) ]
                    [
                        Box.box' [ ]
                            [
                                div 
                                    [ 
                                        Props.Style [ CSSProp.PaddingLeft "5px"; CSSProp.PaddingRight "5px" ] 
                                        Props.OnClick (fun _ -> 
                                            // TODO preserve existing assignment method
                                            dispatch (SetForeground (Foreground.FromPalette (PaletteAssignment.Random, p))))
                                    ]
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

let foregroundFromPaletteRandom (model : ColorScheme.Types.Model) =
    match model.foreground with
    | Foreground.FromPalette(PaletteAssignment.Random, _) -> true
    | _ -> false


let foregroundFromPaletteOrientation (model : ColorScheme.Types.Model) =
    match model.foreground with
    | Foreground.FromPalette(PaletteAssignment.Orientation, _) -> true
    | _ -> false    

let foregroundFromPaletteDisanceFromCenter (model : ColorScheme.Types.Model) =
    match model.foreground with
    | Foreground.FromPalette(PaletteAssignment.DistanceFromCenter, _) -> true
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

let screenHeading s = 
            div [ ClassName "is-size-3" ]
                [ str s ]

let sectionHeading s = 
            div [ ClassName "is-size-4" ]
                [ str s ]

let infoPrompt s =
            div [ ClassName "is-size-5 is-italic" ]
                [ str s ]

let infoPromptSmall s =
            div [ ClassName "is-size-6 is-italic" ]
                [ str s ]

let root model dispatch =
    let fgOneColor = model |> foregroundOneColor
    let fgRandom = model |> foregroundRandom
    let fgPalette = model |> foregroundFromPalette
    let fgPaletteRandom = model |> foregroundFromPaletteRandom
    let fgPaletteOrientation = model |> foregroundFromPaletteOrientation
    let fgPaletteDistanceFromCenter = model |> foregroundFromPaletteDisanceFromCenter
    div [] 
        [
            screenHeading "Select a color scheme"
            div [ ]
                [
                    span [ ClassName "box "]
                        [
                            sectionHeading "Background" 
                            infoPrompt "The background will be the color you pick here"
                            br []
                            singleColorPicker
                        ]
                ]
            div [ ]
                [
                    span [ ClassName "box"; Props.Style [ CSSProp.MarginTop "10px" ] ]
                        [
                            sectionHeading "Foreground"
                            infoPrompt "The shapes will use the color scheme you pick here"
                            br [] 
                            div [ ]
                                [ Switch.switch 
                                    [ 
                                        Switch.Checked fgOneColor
                                        Switch.OnChange (fun _ -> dispatch (SetForeground Foreground.OneColor))
                                    ] 
                                    [ str "One Color" ]
                                  collapse [ IsOpened fgOneColor ] 
                                    [
                                        singleColorPicker                           
                                        br [] 
                                    ]
                                  Switch.switch 
                                    [ 
                                        Switch.Checked fgRandom 
                                        Switch.OnChange (fun _ -> dispatch (SetForeground (Foreground.Random)))
                                    ] 
                                    [ str "Completely random" ] 
                                  Switch.switch 
                                    [ 
                                        Switch.Checked fgPalette
                                        Switch.OnChange (fun _ ->
                                            let existingPalette = 
                                                match model.foreground with
                                                | FromPalette (_, p) -> p
                                                | _ -> Palette.stickyNotes // TODO how default really
                                            dispatch (SetForeground (Foreground.FromPalette (PaletteAssignment.Random, existingPalette))))
                                    ] 
                                    [ str "From palette" ] 
                                  collapse [ IsOpened fgPalette ] 
                                    [
                                        Switch.switch 
                                            [ 
                                                Switch.IsThin
                                                Switch.Checked fgPaletteRandom 
                                                Switch.OnChange (fun _ -> 
                                                    let existingPalette = 
                                                        match model.foreground with
                                                        | FromPalette (_, p) -> p
                                                        | _ -> Palette.stickyNotes // TODO how default really
                                                    dispatch (SetForeground (Foreground.FromPalette (PaletteAssignment.Random, existingPalette))))
                                            ] 
                                            [ str "At random" ]
                                        Switch.switch 
                                            [ 
                                                Switch.IsThin
                                                Switch.Checked fgPaletteOrientation 
                                                Switch.OnChange (fun _ -> 
                                                    let existingPalette = 
                                                        match model.foreground with
                                                        | FromPalette (_, p) -> p
                                                        | _ -> Palette.stickyNotes // TODO how default really
                                                    dispatch (SetForeground (Foreground.FromPalette (PaletteAssignment.Orientation, existingPalette))))
                                            ] 
                                            [ str "By shape orientation" ]
                                        Switch.switch 
                                            [ 
                                                Switch.IsThin
                                                Switch.Checked fgPaletteDistanceFromCenter 
                                                Switch.OnChange (fun _ -> 
                                                    let existingPalette = 
                                                        match model.foreground with
                                                        | FromPalette (_, p) -> p
                                                        | _ -> Palette.stickyNotes // TODO how default really
                                                    dispatch (SetForeground (Foreground.FromPalette (PaletteAssignment.DistanceFromCenter, existingPalette))))
                                            ] 
                                            [ str "By distance from center" ]
                                        collapse [ IsOpened fgPalette ]
                                            [ foregroundPaletteDiv model dispatch ]                       
                                    ]
                                ]
                        ]
                ]
        ]
