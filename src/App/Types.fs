module App.Types

open Global

type Msg =
  | ImageTypeMsg of ImageType.Types.Msg
  | LocationMsg of Location.Types.Msg
  | ColorSchemeMsg of ColorScheme.Types.Msg 

type Model = {
    currentPage: Page
    imageType: ImageType.Types.Model
    location: Location.Types.Model
    colorScheme: ColorScheme.Types.Model
  }
