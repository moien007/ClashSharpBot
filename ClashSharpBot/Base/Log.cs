/*
 * Portable Logging Class
 * 
 * Author : Moien007
 * Last Update : 2/16/2017
 */

using System;
using System.Text;
using System.IO;

public static class Log
{
    public static string LogFile { get; set; }

    public const LogLevel AllLogLevels = LogLevel.Warn | LogLevel.Info | LogLevel.Error | LogLevel.Debug;

    public static LogLevel Level { get; set; } = AllLogLevels;

    public static string DatetimeFormat;

    private static object syncObject = new object();

    private static StringBuilder logBuilder = new StringBuilder();

    static Log()
    {
        LogFile = string.Empty;
        Level = LogLevel.None;

        // Set Default DateTime Format 
        ResetDatetimeFormat();
    }

    public static void Init()
    {
        // No Write Log to File
        LogFile = string.Empty;

        // Basic Log Levels
        Level = LogLevel.Info | LogLevel.Error;
    }

    public static void Init(string file)
    {
        LogFile = file;

        // Basic Log Levels
        Level = LogLevel.Info | LogLevel.Error;
    }

    public static void Init(LogLevel level)
    {
        // No Write Log to File
        LogFile = string.Empty;

        Level = level;
    }

    public static void Init(string file, LogLevel level)
    {
        LogFile = file;
        Level = level;

        // Set Default DateTime Format 
        ResetDatetimeFormat();
    }

    static bool MayWriteType(LogLevel type)
    {
        if (type == LogLevel.None) return false;
        return ((Level & type) == type);
    }

    public static void ResetDatetimeFormat()
    {
        DatetimeFormat = "HH:mm:ss";
    }

    public static void Write(object Text, LogLevel loglevel, string prefix = "")
    {
        string text = Text.ToString();

        // date time
        string datetime = DateTime.Now.ToString(DatetimeFormat);

        // log level string
        string loglevelStr = loglevel.ToString();

        // lock a object to have clean text on mutlithreaded app's
        lock (syncObject)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Write Date Time 
            Console.Write("[{0}]", datetime);

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            if (!string.IsNullOrEmpty(prefix))
            {
                // write prefix if it's not empty or null
                Console.Write("[{0}]", prefix);
            }

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
            Console.Write(" {0}: ", loglevelStr);

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(text);

            if (string.IsNullOrEmpty(LogFile))
                return;

            logBuilder.AppendFormat("[{0}]{4} {1} : {2}{3}", datetime, loglevelStr, text, Environment.NewLine,
                string.IsNullOrEmpty(prefix) ? string.Empty : string.Format("[{0}]", prefix)); // write prefix if it's not null or empty
        }
    }

    public static void WriteLogFile()
    {
        string logs = logBuilder.ToString();
        logBuilder.Clear();

        File.AppendAllText(LogFile, logs);
    }

    public static void Info(string format, params object[] args)
    {
        if (!MayWriteType(LogLevel.Info))
        {
            return;
        }

        Write(string.Format(format, args), LogLevel.Info);
    }

    public static void Warn(string format, params object[] args)
    {
        if (!MayWriteType(LogLevel.Warn))
        {
            return;
        }

        Write(string.Format(format, args), LogLevel.Warn);
    }

    public static void Error(string format, params object[] args)
    {
        if (!MayWriteType(LogLevel.Error))
        {
            return;
        }

        Write(string.Format(format, args), LogLevel.Error);
    }

    public static void Debug(string format, params object[] args)
    {
        if (!MayWriteType(LogLevel.Debug))
        {
            return;
        }

        Write(string.Format(format, args), LogLevel.Debug);
    }
    
    public static ILogger GetLogger(string name)
    {
        // Create a logger with this logger levels
        return new Logger(name, Level);
    }

    public static ILogger GetLogger(string name, LogLevel levels)
    {
        return new Logger(name, levels);
    }

    private class Logger : ILogger
    {
        public LogLevel Levels { get; set; }
        public string Prefix { get; set; }

        public Logger(string prefix, LogLevel level)
        {
            Prefix = prefix;
            Levels = level;
        }

        private bool MayWriteType(LogLevel type)
        {
            if (type == LogLevel.None) return false;
            return ((Levels & type) == type);
        }

        public void Info(string format, params object[] args)
        {
            if (!MayWriteType(LogLevel.Info))
            {
                return;
            }

            Write(string.Format(format, args), LogLevel.Info);
        }

        public void Warn(string format, params object[] args)
        {
            if (!MayWriteType(LogLevel.Warn))
            {
                return;
            }

            Write(string.Format(format, args), LogLevel.Warn);
        }

        public void Error(string format, params object[] args)
        {
            if (!MayWriteType(LogLevel.Error))
            {
                return;
            }
            
            Write(string.Format(format, args), LogLevel.Error);
        }

        public void Debug(string format, params object[] args)
        {
            if (!MayWriteType(LogLevel.Debug))
            {
                return;
            }

            Write(string.Format(format, args), LogLevel.Debug);
        }

        public void Write(object obj, LogLevel level)
        {
            Log.Write(obj, level, Prefix);
        }
    }
}

public interface ILogger
{
    string Prefix { get; set; }
    LogLevel Levels { get; set; }
    void Write(object obj, LogLevel level);
    void Info(string format, params object[] args);
    void Debug(string format, params object[] args);
    void Warn(string format, params object[] args);
    void Error(string format, params object[] args);
}

public enum LogLevel
{
    Info,
    Debug,
    Error,
    Warn,
    None,
}