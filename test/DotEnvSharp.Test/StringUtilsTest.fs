module DotEnvSharp.StringUtils.Test

open System
open StringUtils
open NUnit.Framework

[<TestCase(",", "test1,test2,test3", [|"test1"; "test2"; "test3"|])>]
[<TestCase("#", "test1,test2,test3", [|"test1,test2,test3"|])>]
[<TestCase(",", "", [|""|])>]
let ``split should split properly string input`` (separator, input, expected) =
    let result = split separator input
    Assert.AreEqual(expected, result)

[<TestCase("  test1", "test1")>]
[<TestCase("   test2       ", "test2")>]
[<TestCase("      ", "")>]
[<TestCase("", "")>]
let ``trim should trim properly string input`` (input, expected) =
    let result = trim input
    Assert.AreEqual(expected, result)

[<TestCase(null, true)>]
[<TestCase("", true)>]
[<TestCase("      ", true)>]
[<TestCase("   a", false)>]
let ``isNullOrWhiteSpace should return true if the string is null or white space`` (input, expected) =
    let result = isNullOrWhiteSpace input
    Assert.AreEqual(expected, result)
