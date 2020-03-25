open System

//Question 1
let orderDetail = ((201907, "Paw Patrol"), "Coffee", ("Large", 3))
// Question 1a
let deconstruct() = 
    let (_,item, size) = orderDetail
    printfn "%s %s %i" item <|| size

deconstruct()
// Coffee Large 3

// Question 1b
let rec sumAbsDir ls =
    match ls with
    | h :: t when h > 0 -> h + sumAbsDir t
    | h :: t when h <= 0 -> sumAbsDir t
    | [] -> 0

// sumAbsDir [1;2;-1];;
//val it : int = 3

//Question 1c
let sumAbsHof ls = 
    let sum = List.reduce (+) ls
    printfn "Sum : %i" sum

// sumAbsHof [1;2;3];;
// Sum : 6

//Question 2a
let isLeapYear (x : int) =
    if (x % 400 = 0 || (x % 4 = 0  &&  x % 100 <> 0)) then true
    else false
// isLeapYear (1992);;
// val it : bool = true

//Question 2b
let removeEven intList = List.filter(fun v -> not (v % 2= 0)) intList
//removeEven [1;2;3;4;5;6];;
//val it : int list = [1; 3; 5]

// Question 2c
let rec getElementAt alst ipos =
    let rec subf alst ipos accumulator =
        match alst with
        | [] -> failwith "Index out of bounds"
        | h::t -> if ipos = accumulator then h else subf t ipos (accumulator+1)

    subf alst ipos 1
// getElementAt ["Cross Media"; "Data Engineering"; "Embedded Systems"] 2;;
// val it : string = "Data Engineering"

//Question 3a
let rec takeSomeItem n aList =
    match aList with
    | [] -> failwith "Index out of bounds"
    | h :: t -> match n with
                | 0 -> []
                | _ -> h :: takeSomeItem (n-1) t

let testTakeSome = takeSomeItem 3 [1;2;3;4;5]
// val testTakeSome : int list = [1; 2; 3]

// Question 3b
let lastElement list =
    let rec subf list last =
        match list with
        | [] -> last
        | head :: tail -> subf tail head

    match list with
    | [] -> failwith "List is empty"
    | _ -> subf list null

// lastElement ["Cross Media"; "Data Engineering"; "Embedded Systems"];;
// val it : string = "Embedded Systems"

// Question 3c
let List = [1;2;3;4;5;6]
printfn "Last Index : %i" (List.Item(List.Length-1))
// Last Index : 6 

// Question 4 

type Vector =
    | VCircle of float
    | VRectangle of float * float
    | VTriangle of float * float * float

// Question 4a
let vector1 = VCircle(10.0)
let vector2 = VRectangle(2.0,5.0)
let vector3 = VTriangle(2.0,3.0,4.0)

// Question 4b 
let area (vect:Vector) =
    match vect with
    | VCircle (a) -> 3.14 * (a**2.0)
    | VRectangle (a,b) -> a*b
    | VTriangle (a,b,c) -> (a+b+c)/2.0

let area1 = area(VCircle 3.0)
let area2 = area(VRectangle(3.0,3.0))
let area3 = area(VTriangle(3.0,4.0,5.0))

// val area1 : float = 28.26
// val area2 : float = 9.0
// val area3 : float = 6.0

// Question 4c

type VShape = 
    {VCircle: float; VRectangle: float * float; VTriangle: float * float * float } 

// Question 5 
// Question 5a 
// ----- GENERICS -----
// Generics allow you to use any data type in a function

type VBTree<'a> = 
    Leaf of 'a 
    | OneChild of VBTree<'a>
    | TwoChildren of (VBTree<'a> * VBTree<'a>)

// Question 5b 
type CanteenMessage =
    | GreetMessage 
    | OrderDrinkMessage of int
    | LoanMessage of string

let viaCanteenMessage =
    MailboxProcessor<CanteenMessage>.Start (fun inbox ->
        let rec msgLoop = async {
            let! msg = inbox.Receive()
            match msg with 
            | GreetMessage -> printfn "Hello!"
            | OrderDrinkMessage(value) -> printfn "Thanks for coming"
            | LoanMessage(value) -> 
            return!  msgLoop
        }
        msgLoop)

viaCanteenMessage.Post (CanteenMessage.GreetMessage)
viaCanteenMessage.Post (CanteenMessage.OrderDrinkMessage(1))
viaCanteenMessage.Post (CanteenMessage.LoanMessage(":D"))














