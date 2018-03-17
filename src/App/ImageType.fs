namespace Cadastral

module ImageType =

    type ImageType = {
        Name : string
        ThumbnailUrl : string
        Lat : float
        Lon : float }

    let imageTypes =
        [
            { Name = @"Buildings in Great Britain"
              ThumbnailUrl = @"https://cadastral.blob.core.windows.net/thumbnails/gb.png"
              Lat = 51.5073
              Lon = 0.12755 }
            { Name = @"Tax Lots in NYC"
              ThumbnailUrl = @"https://cadastral.blob.core.windows.net/thumbnails/nyc.png"
              Lat = 40.7127
              Lon = -74.0059 }
        ]