using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace MOZGUI.Fireup
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                #if DEBUG
                       MessageBox.Show("This message displayed for debug version");
                #endif

                if (e.Args != null && e.Args.Count() > 0)
                {
                    var argument = e.Args[0];
                    Uri uri = new Uri(argument);

                    if (uri.Scheme == "mozgui-fireup")
                    {
                        var localPath = uri.LocalPath;

                        var process = new Process
                        {
                            StartInfo = new ProcessStartInfo(localPath)
                            {
                                UseShellExecute = true,
                                CreateNoWindow = false
                            }
                        };
                        process.Start();
                    }
                }
                else
                {
                    base.Shutdown();
                }
            }
            catch
            {
                //TODO
            }
            base.Shutdown();
        }
    }
}
