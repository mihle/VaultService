using System;
using System.Configuration;
using System.IO;

/// <summary>
/// Summary description for Logger
/// </summary>
public class Logger
{
    public static int ERROR = 0;
    public static int WARNING = 1;
    public static int DEBUG = 2;

    private static string[] TYPE = { "ERROR", "Warning", "Debug" };

    // all public methods will be static
    private Logger()
    {
    }

    public static void Log(string msg)
    {
        string m = DateTime.Today.Month.ToString();
        string y = DateTime.Today.Year.ToString();
        string f = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["LogPath"]];

        f = f + string.Format("{0}_{1}_log.txt", y, m);

        using (StreamWriter w = File.AppendText(f))
        {
            DoLog(msg, w);
            w.Close();
        }
    }

    public static void Log(int level, string tool, string msg)
    {
        if ((level > 0) && (level > int.Parse(ConfigurationManager.AppSettings["DebugLevel"])))
        {
            return;
        }

        msg = "[" + TYPE[level] + "] " + "[" + tool + "] " + msg;
        string m = DateTime.Today.Month.ToString();
        string y = DateTime.Today.Year.ToString();
        string f = ConfigurationManager.AppSettings["LogPath"];

        f = f + string.Format("{0}_{1}_log.txt", y, m);
        using (StreamWriter w = File.AppendText(f))
        {
            DoLog(msg, w);
            w.Close();
        }
    }

    private static void DoLog(String logMessage, TextWriter w)
    {
        w.Write("{0}", DateTime.Now.ToString("MM/dd/yy HH:mm"));
        w.Write(" {0}", logMessage);
        w.Write("\r\n");
        w.Flush();
    }



}
