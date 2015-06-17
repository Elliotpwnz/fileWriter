(*
    fileWriter.fs 
    by Jeffrey Simpson

    --Note--
    Run these blocks separately in F# interactive to see the individual results
*)

//Import System.IO for file input/output
open System.IO

//Here is the readFile function
let readFile (myPath:string) = Seq.length (Seq.concat (seq{
    use sr = new StreamReader (myPath)
    while not sr.EndOfStream do
        yield sr.ReadLine().Split(' ')
    }))
    
//Here is the writeFile function
let writeFile (stringLength:int)(myPath:string) = 
    use outFile = new StreamWriter(myPath)
    outFile.WriteLine(stringLength)


//Call the readFile function with whatever path desired.
let stringLength = readFile (__SOURCE_DIRECTORY__ + "\input.txt")

//Call the writeFile function with the length returned from the readFile function
writeFile (stringLength)(__SOURCE_DIRECTORY__ + "\output.txt")

//We can even combine the two statements
writeFile (readFile (__SOURCE_DIRECTORY__ + "\input.txt"))(__SOURCE_DIRECTORY__ + "\output.txt")