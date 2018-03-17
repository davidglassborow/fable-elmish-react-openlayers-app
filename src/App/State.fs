module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    // map About (s "about")
    // map Counter (s "counter")
    map ImageType (s "imagetype")
    map Location (s "location") // TODO KE
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
  let (model, cmd) =
    urlUpdate result
      { currentPage = ImageType
        imageType = imageType
        location = location }
  model, Cmd.batch [ cmd
                     Cmd.map ImageTypeMsg imageTypeCmd
                     Cmd.map LocationMsg locationCmd ]

let update msg model =
  match msg with
  // | CounterMsg msg ->
  //     let (counter, counterCmd) = Counter.State.update msg model.counter
  //     { model with counter = counter }, Cmd.map CounterMsg counterCmd
  | ImageTypeMsg msg ->
      let (imageType, imageTypeCmd) = ImageType.State.update msg model.imageType
      { model with imageType = imageType }, Cmd.map ImageTypeMsg imageTypeCmd
  | LocationMsg msg ->
      let (location, locationCmd) = Location.State.update msg model.location
      { model with location = location }, Cmd.map LocationMsg locationCmd