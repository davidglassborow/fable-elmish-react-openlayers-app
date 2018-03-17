module ImageType.Types
open Fable.Import
open Fable.Helpers

type Model = {
    imageType : Cadastral.ImageType.ImageType
}

type Msg =
  | SelectLocation of Cadastral.ImageType.ImageType
 