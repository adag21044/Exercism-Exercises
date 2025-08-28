public enum LogLevel
{
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal,
    Unknown
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        string header = logLine.Substring(1, 3); 

        if(header == "TRC")
        {
            return LogLevel.Trace;
        }
        else
        if(header == "DBG")
        {
            return LogLevel.Debug;  
        }
        else
        if(header == "INF")
        {
            return LogLevel.Info;     
        }
        else
        if(header == "WRN")
        {
             return LogLevel.Warning;   
        }
        else
        if(header == "ERR")
        {
            return LogLevel.Error;
        }
        else
        if(header == "FTL")
        {
            return LogLevel.Fatal;
        }
        else
        {
            return LogLevel.Unknown;
        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        int code;

        switch (logLevel)
        {
            case LogLevel.Trace:
                code = 1;
                break;
            case LogLevel.Debug:
                code = 2;
                break;
            case LogLevel.Info:
                code = 4;
                break;
            case LogLevel.Warning:
                code = 5;
                break;
            case LogLevel.Error:
                code = 6;
                break;
            case LogLevel.Fatal:
                code = 42;
                break;
            default: // Unknown
                code = 0;
                break;
        }

        return code + ":" + message;
    }
}
