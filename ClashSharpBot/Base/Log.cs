using System;
using System.Text;
using System.IO;

public class Log
{
    public static string File { get; set; }

    public static LogLevel Level { get; set; }

    public static string DatetimeFormat;

    public static bool ShowDebugs = false;

    static object sync = new object();

    public static void Init()
    {
        // No Write Log to File
        File = string.Empty;

        // Basic Log Levels
        Level = LogLevel.Info | LogLevel.Error;

        // Set Default DateTime Format 
        ResetDatetimeFormat();
    }

    public static void Init(string file)
    {
        File = file;

        // Basic Log Levels
        Level = LogLevel.Info | LogLevel.Error;

        // Set Default DateTime Format 
        ResetDatetimeFormat();
    }

    public static void Init(LogLevel level)
    {
        // No Write Log to File
        File = string.Empty;

        Level = level;

        // Set Default DateTime Format 
        ResetDatetimeFormat();
    }

    public static void Init(string file, LogLevel level)
    {
        File = file;
        Level = level;

        // Set Default DateTime Format 
        ResetDatetimeFormat();
    }

    private static bool MayWriteType(LogLevel type)
    {
        return ((Level & type) == type);
    }

    public static void ResetDatetimeFormat()
    {
        DatetimeFormat = "";
    }

    public static void Write(object Text, LogLevel loglevel)
    {
        // we accecpt text as object like consosle
        // because user no need to write .ToString

        // we convert object to string
        string text = Text.ToString();

        // date time
        string datetime = DateTime.Now.ToString(DatetimeFormat);

        // log level string
        string loglevelStr = loglevel.ToString();

        // lock a object to have clean text on mutlithreaded app's
        lock (sync)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Write Date Time 
            Console.Write("[{0}] ", datetime);

            switch (loglevel)
            {
                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            // Write Log Level
            Console.Write("{0} :: ", loglevelStr);

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(text);
        }

        if (File == string.Empty)
            return;

        // Write Log to File
        using (FileStream logfile = System.IO.File.OpenWrite(File)) // Open File With Write Access
        using (StreamWriter writer = new StreamWriter(logfile)) // Create Stream Writer
        {
            writer.WriteLine("[{0}] {1} : {2}", datetime, loglevelStr, text);
        }
    }

    public static void Info(object text)
    {
        if (!MayWriteType(LogLevel.Info))
        {
            return;
        }

        Write(text, LogLevel.Info);
    }

    public static void Warn(object text)
    {
        if (!MayWriteType(LogLevel.Warn))
        {
            return;
        }

        Write(text, LogLevel.Warn);
    }

    public static void Error(object text)
    {
        if (!MayWriteType(LogLevel.Error))
        {
            return;
        }

        Write(text, LogLevel.Error);
    }

    public static void Debug(object text)
    {
        if(!MayWriteType(LogLevel.Debug))
        {
            return;
        }

        Write(text, LogLevel.Debug);
    }
}

public enum LogLevel
{
    Info,
    Debug,
    Error,
    Warn,
    None
}
