namespace Cadastral

module ImageType =

    type ImageType = {
        Name : string
        ThumbnailUrl : string }
    let imageTypes =
        [
            { Name = @"Buildings in Great Britain"
              ThumbnailUrl = @"https://cadastral.blob.core.windows.net/thumbnails/gb.png" }
            { Name = @"Tax Lots in NYC"
              ThumbnailUrl = @"https://cadastral.blob.core.windows.net/thumbnails/nyc.png" }
        ]