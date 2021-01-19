module DotEnvSharp.Parser.Test

open System
open DotEnvSharp.Parser
open NUnit.Framework

[<Test>]
let ``parse should parse properly string input`` () =
    let input = 
        "KEY1=VAL1" + Environment.NewLine +
        "  Key2=Val2  " + Environment.NewLine +
        "# THIS IS A COMMENT" + Environment.NewLine +
        "     " + Environment.NewLine +
        "key3  = value3" + Environment.NewLine
    
    let result = parse input
    
    let expected = [|("KEY1", "VAL1"); ("Key2", "Val2"); ("key3", "value3")|]
    Assert.AreEqual(expected, result)
