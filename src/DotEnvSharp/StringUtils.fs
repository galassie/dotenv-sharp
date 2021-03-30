module StringUtils

    open System

    let split (separator : string) (str : string) =
        str.Split(separator)

    let trim (str : string) =
        str.Trim()

    let isNullOrWhiteSpace (str : string) =
        String.IsNullOrWhiteSpace(str)
