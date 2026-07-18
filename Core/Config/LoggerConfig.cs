using System;
using System.IO;
using Serilog;
using Serilog.Events;


namespace smpc_dispatching.Config {
   public static class LoggerConfig {
        public static void Configure() {
            // Always write logs to a stable, per-user, always-writable location
            // (%LOCALAPPDATA%\smpc_dispatching\Logs), instead of deriving a
            // "project root" via AppContext.BaseDirectory\..\.. .
            //
            // That relative-path trick only worked when running from
            // bin\Debug\ inside the source checkout. Under a ClickOnce
            // publish, AppContext.BaseDirectory is a virtualized install
            // directory (AppData\Local\Apps\2.0\...), so "..\.." landed
            // somewhere else entirely and Directory.CreateDirectory could
            // throw (UnauthorizedAccessException/DirectoryNotFoundException).
            // Since this runs as the very first line of Main(), before any
            // UI is shown, that exception was unhandled and killed the
            // process silently - the app would never appear.
            string logDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "smpc_dispatching",
                "Logs");

            // Ensure Logs folder exists
            Directory.CreateDirectory(logDirectory);

            // Configure logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File(
                    Path.Combine(logDirectory, "app.log"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    fileSizeLimitBytes: 5_000_000,
                    rollOnFileSizeLimit: true,
                    restrictedToMinimumLevel: LogEventLevel.Debug
                )
                .CreateLogger();
        }
    }

}
