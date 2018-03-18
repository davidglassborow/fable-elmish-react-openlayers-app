namespace Cadastral

module ImageType =

    type ImageType = {
        Name : string
        Description : string
        Credit : string 
        ThumbnailUrl : string
        Lat : float
        Lon : float
        DefaultZoom : float }

    let imageTypes =
        [
            { Name = @"Buildings in Great Britain"
              Description = "Shapes of buildings in Great Britain"
              Credit = "Contains Ordnance Survey data © Crown copyright and database right 2018"
              ThumbnailUrl = @"https://cadastral.blob.core.windows.net/thumbnails/gb.png"
              Lat = 51.5073
              Lon = -0.12755
              DefaultZoom = 14. }
            { Name = @"Tax Lots in NYC"
              Description = "Shapes of tax lots in New York City"
              Credit = "Department of City Planning (DCP) NYC"
              ThumbnailUrl = @"https://cadastral.blob.core.windows.net/thumbnails/nyc.png"
              Lat = 40.7127
              Lon = -74.0059
              DefaultZoom = 13. }
        ]