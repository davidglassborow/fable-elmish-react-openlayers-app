module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map ImageType (s "imagetype")
    map Location (s "location")
    map ColorScheme (s "colorscheme")
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url")
    model,Navigation.modifyUrl (toHash model.currentPage)
  | Some page ->
      { model with currentPage = page }, []

let init result =
  let (imageType, imageTypeCmd) = ImageType.State.init()
  let (location, locationCmd) = Location.State.init()
  let (colorScheme, colorSchemeCmd) = ColorScheme.State.init()
  let (model, cmd) =
    urlUpdate result
      { currentPage = ImageType
        imageType = imageType
        location = location
        colorScheme = colorScheme }
  model, Cmd.batch [ cmd
                     Cmd.map ImageTypeMsg imageTypeCmd
                     Cmd.map LocationMsg locationCmd 
                     Cmd.map ColorSchemeMsg colorSchemeCmd ]
let update msg model =
  match msg with
  | ImageTypeMsg msg ->
      let (imageType, imageTypeCmd) = ImageType.State.update msg model.imageType
      printfn "App update: Image type: %s currentPage: %A" imageType.imageType.Name Location
      { model with imageType = imageType; currentPage = Location }, Navigation.newUrl "#location"
      // Cmd.none // Cmd.map ImageTypeMsg imageTypeCmd
  | LocationMsg msg ->
      let (location, locationCmd) = Location.State.update msg model.location
      { model with location = location }, Navigation.newUrl "#colorscheme"
      //{ model with location = location }, Cmd.map LocationMsg locationCmd  
  | ColorSchemeMsg msg ->
      let (colorScheme, colorSchemeCmd) = ColorScheme.State.update msg model.colorScheme
      { model with colorScheme = colorScheme }, Cmd.none