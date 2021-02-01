module DotEnvSharp.Config.Test

open System
open System.Text
open DotEnvSharp.Config
open NUnit.Framework

[<Test>]
let ``config with default options should configure properly the environment variables`` () =
    let result = config DefaultOptions

    let expected = [|("KEY1", "VAL1"); ("Key2", "Val2"); ("key3", "value3")|]    
    match result with
        | Ok envVariables -> Assert.AreEqual(expected, envVariables)
        | Error _ -> Assert.Fail("Result should be Ok!")

    Assert.AreEqual("VAL1", Environment.GetEnvironmentVariable("KEY1"))
    Assert.AreEqual("Val2", Environment.GetEnvironmentVariable("Key2"))
    Assert.AreEqual("value3", Environment.GetEnvironmentVariable("key3"))

[<Test>]
let ``config with different file path option should search for overloaded env file and configure properly the environment variables`` () =
    let result = config { DefaultOptions with FilePath = ".altenv" }

    let expected = [|("KEY1", "VAL1"); ("Key2", "Val2"); ("key3", "value3")|]    
    match result with
        | Ok envVariables -> Assert.AreEqual(expected, envVariables)
        | Error _ -> Assert.Fail("Result should be Ok!")

    Assert.AreEqual("VAL1", Environment.GetEnvironmentVariable("KEY1"))
    Assert.AreEqual("Val2", Environment.GetEnvironmentVariable("Key2"))
    Assert.AreEqual("value3", Environment.GetEnvironmentVariable("key3"))


[<Test>]
let ``config with different file encoding option should configure properly the environment variables`` () =
    let result = config { DefaultOptions with FilePath = ".latinenv"; Encoding = Encoding.Latin1 }

    let expected = [|("KEY1", "VAL1"); ("Key2", "Val2"); ("key3", "value3")|]    
    match result with
        | Ok envVariables -> Assert.AreEqual(expected, envVariables)
        | Error _ -> Assert.Fail("Result should be Ok!")

    Assert.AreEqual("VAL1", Environment.GetEnvironmentVariable("KEY1"))
    Assert.AreEqual("Val2", Environment.GetEnvironmentVariable("Key2"))
    Assert.AreEqual("value3", Environment.GetEnvironmentVariable("key3"))