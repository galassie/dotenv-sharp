module DotEnvSharp.Config

    open System
    open System.Text
    open System.IO
    open StringUtils
    open DotEnvSharp.Parser

    type Options =
        { FilePath : string
          Encoding : Encoding }

    let private envFileName = ".env"

    let DefaultOptions = { FilePath = Path.Combine(AppContext.BaseDirectory, envFileName); Encoding = Encoding.UTF8 }

    /// Configure the current environment with the variables read from the env file
    /// The options arg specify the .env file path and the file encoding
    let config options =
        let dotenvPath =  if isNotNullOrWhiteSpace options.FilePath then options.FilePath else DefaultOptions.FilePath
        let dotenvEncoding = if not (isNull options.Encoding) then options.Encoding else DefaultOptions.Encoding

        try 
            let dotenv = File.ReadAllText(dotenvPath, dotenvEncoding)
            let elements = parse dotenv
            for (key, value) in elements do Environment.SetEnvironmentVariable(key, value)
            Ok elements
        with
            | ex -> printfn "Exception! %s " (ex.Message); Error ex.Message