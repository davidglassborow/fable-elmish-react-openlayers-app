module ColorScheme.Palette

type Palette = {
    Name : string
    Colors : string list }

let r = System.Random()

let rgbString (r, g, b)=
    sprintf "#%02x%02x%02x" r g b

let twentySeven =
    { Name = "Twenty Seven"
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
            (209, 30, 33)
            (93, 210, 106)
            (13, 73, 73)
            (236, 251, 246)
            (211, 67, 66)
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
      Colors = 
        List.init 16 (fun _ ->
            let rand = System.Random(1)
            let r = rand.Next(200, 255)
            let g = rand.Next(0, 10)
            let b = rand.Next(80, 220)
            rgbString(r, g, b))}
   
let foregroundPalettes =
    [
        stickyNotes
        dryWipe
        bricks
        donegal
        purples 
        mauveBlue
        rainbow
        twentySeven
        theOchOfTheNew
        laLaLand
        thePinkAisle
    ]    

    // div [] 
    //     [
    //         div [] ( stickyNotes |> List.map colorChip )
    //         div [] ( dryWipe |> List.map colorChip )
    //         div [] ( regular27 |> List.map colorChip )
    //         div [] ( bricks |> List.map colorChip )
    //     ]            