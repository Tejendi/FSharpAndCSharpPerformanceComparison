open System
open System.IO
open BenchmarkDotNet.Running
open BenchmarkDotNet.Attributes

[<MemoryDiagnoser>]
type PerformanceTests_ReadFile() =
    //let histogram path =
    [<Benchmark>]
    member this.ReadFiles() =
        let path = @"..\..\RandomText.txt"
        let charCount = [| for n in 'A'..'Z' -> 0 |]
        let Acode = int 'A'
        let file = File.OpenText path
        while (not file.EndOfStream) do
            let ch = char( file.Read() )
            if (Char.IsLetter ch) then
                let n = int (Char.ToUpper ch) - Acode
                charCount.[n] <- charCount.[n] + 1
            else ()
        file.Close()

        (*Below code can be commented in to show the results of the file read in the console*)
        //let printOne n c = printf "%c: %4d\n" (char(n + Acode)) c
        //Array.iteri printOne charCount

[<EntryPoint>]
let main argv = 
    BenchmarkRunner.Run<PerformanceTests_ReadFile>() |> printfn "%A"
    Console.ReadKey() |> ignore

    0 // return an integer exit code