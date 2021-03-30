module DotEnvSharp.Parser

    open System
    open System.Text.RegularExpressions
    open StringUtils

    let commentPrefix = '#'
    let lineRegex = @"^([\w.-]+)\s*=\s*(.*)$"

    /// Parse a multi-line string (the content of a .env file) and returns an array of tuple composed by the KEY and the VAL
    /// The syntax rules are:
    /// 1) Every line should be in KEY=VAL format
    /// 2) Lines beginning with the char '#' are considered comments and so skipped
    /// 3) Empty lines are skipped
    let parse source =
        let isNotComment (str : string) =
            str.[0] <> commentPrefix

        let matchLineFormat (str : string) =
            Regex.IsMatch(str, lineRegex)

        let splitKeyValue (str : string) =
            Regex.Match(str, lineRegex)
            |> (fun regexMatch -> (regexMatch.Groups.[1].Value, regexMatch.Groups.[2].Value))

        split Environment.NewLine source
        |> Array.map trim
        |> Array.filter (isNullOrWhiteSpace >> not)
        |> Array.filter isNotComment
        |> Array.filter matchLineFormat
        |> Array.map splitKeyValue