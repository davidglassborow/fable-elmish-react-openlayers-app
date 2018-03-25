module ColorScheme.Palette

type Palette = {
    Name : string
    Colors : string list }

let rgbString (r, g, b)=
    sprintf "#%02x%02x%02x" r g b


let rgbRange (count, minR, maxR, minG, maxG, minB, maxB) =
    let calc x min' max' = min' + (float x / float count * float(max' - min') |> int)
    List.init count (fun i ->
        let r = calc i minR maxR
        let g = calc i minG maxG
        let b = calc i minB maxB
        rgbString(r, g, b))

let threeCubed =
    { Name = "Three Cubed"
      Colors = 
        let levels = [0x00; 0x80; 0xFF]
        [
            for r in levels do
                for g in levels do
                    for b in levels do
                        yield (r, g, b)
        ] |> List.map rgbString
    }

let stickyNotes =
    { Name = "Sticky Notes"
      Colors = 
        [
            (254, 175,  44)
            (255,  88, 180)
            (  0, 161, 215)
            (221, 239,  77)
            (255, 211,  54)
        ] |> List.map rgbString
    }

let dryWipe =
    { Name = "Dry Wipe"
      Colors = 
        [
            (  0,   0,   0)
            (230,   0,   0)
            (  0, 200,   0)
            (  0,   0, 230)
            (100,  50,  50)
        ] |> List.map rgbString   
    } 

let bricks =
    { Name = "Darlington Bricks"
      Colors = 
        [
            (223, 204, 175)
            (180, 163, 137)
            (191,  57,  11)
            (144,  46,  21)
            (81,   19,   1)        
        ] |> List.map rgbString
    }

let donegal =
    { Name = "Donegal"
      Colors = 
        [
           (195, 189,  80)
           (231, 232, 237)
           ( 94, 120,  32)
           (114, 176, 110)
           (115, 46,   42)
           (203, 223, 214)
           (189, 154,  64)
           (136, 99,   83)
           (169, 158, 147)
        ] |> List.map rgbString
    }

let purples =
    { Name = "Ninja Purples"
      Colors = 
        [
            (239, 187, 255)
            (216, 150, 255)
            (190,  41, 236)
            (128,   0, 128)
            (102,   0, 102)    
        ] |> List.map rgbString
    }

let mauveBlue =
    { Name = "Mauve Actually"
      Colors = 
        [
            ( 14,  0, 142)
            ( 38,  0, 165)
            ( 66,  0, 194)
            ( 87,  0, 215)
            (111,  0, 239)
            (117,  0, 245)
        ] |> List.map rgbString  
    }

let rainbow =
    { Name = "Over the Rainbow"
      Colors = 
        [
            "red"
            "orange"
            "yellow"
            "green"
            "blue"
            "indigo"
            "violet"
        ]
    }

let theOchOfTheNew =
    { Name = "The Och of the Noo"
      Colors = 
        [
            (209,  30,  33)
            (93,  210, 106)
            (13,   73,  73)
            (236, 251, 246)
            (211,  67,  66)
         ] |> List.map rgbString
    }
let laLaLand =
    { Name = "La La Land"
      Colors = 
        List.init 16 (fun i ->
            let r = i * 16
            let g = 0
            let b = 180 - i
            rgbString(r, g, b))}
let thePinkAisle =
    { Name = "The Pink Aisle"
      Colors = rgbRange (16, 200, 255, 0, 20, 70, 230) }
let emeraldForest =
    { Name = "Emerald Forest"
      Colors = rgbRange(5, 40, 80, 150, 255, 60, 100) }

let dayAtThePool =
    { Name = "Day at the Pool"
      Colors = rgbRange(5, 0, 0, 150, 255, 150, 255) }
let melony =
    { Name = "Melony"
      Colors = rgbRange(8, 190, 255, 80, 128, 80, 80) }

let theOrangery =
    { Name = "The Orangery"
      Colors = 
        let oranges = rgbRange(6, 190, 255, 60, 165, 0, 0)
        let greens = rgbRange(2, 40, 80, 150, 255, 60, 100)
        oranges @ greens }      

let tenShadesOfGray =
    { Name = "Ten shades of..."
      Colors = rgbRange(10, 100, 200, 100, 200, 100, 200) }

let mordor =
    { Name = "Mordor"
      Colors = rgbRange(10, 50, 255, 0, 0, 0, 0) }

let theCuminLeague =
    { Name = "The Cumin League"
      Colors = 
        let cumin = (189, 158, 111)
        let sage = (154,171,137)
        let saffron = (255,173,1)
        let oregano = (157,153,80)
        let sienna = (119,79,62)
        [ cumin; sage; saffron; oregano; sienna ]
        |> List.map rgbString }

let stainedGlass =
    { Name = "Stained Glass"
      Colors = 
        [
            (230,32,35)
            (240,68,140)
            (250,243,38)
            (99,195,94)
            (60,129,188)
        ] |> List.map rgbString }

let goingUnderground =
    { Name = "Going Underground"
      Colors = 
        [
             (137,78,36)
             (220,36,31)
             (255,206,0)
             (0,109,39)
             (215,153,175)
             (134,143,152)
             (117,16,86)
             (0,0,0)
             (0,25,168)
             (0,160,226)
             (118,208,189)
        ] |> List.map rgbString }

let vaporWave =
    { Name = "Vaporwave"
      Colors =
        [
            (255,113,206)
            (1,205,254)
            (5,255,161)
            (185,103,255)
            (255,251,150)
        ] |> List.map rgbString }

let foregroundPalettes =
    [
        stickyNotes
        dryWipe
        bricks
        donegal
        purples 
        mauveBlue
        rainbow
        threeCubed
        theOchOfTheNew
        laLaLand
        thePinkAisle
        emeraldForest   
        melony     
        dayAtThePool
        tenShadesOfGray
        theOrangery
        mordor
        theCuminLeague
        stainedGlass
        goingUnderground
        vaporWave
    ]    

let backgroundPalette = threeCubed
