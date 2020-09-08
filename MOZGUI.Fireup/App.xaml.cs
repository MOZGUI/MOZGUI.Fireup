using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace MOZGUI.Fireup
{

    public partial class App : Application
    {
        private void Fireup(string localPath)
        {
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

        private bool checkExtension(string fileNameExtension)
        {
            RegistryKey protocol = Registry.ClassesRoot.OpenSubKey("mozgui-fireup");
            var extensions =  (string)protocol.GetValue("AllowedExtensions");
            var extList = extensions.Split(';');
            foreach (var allowedExt in extList)
            {
                var trimExt = allowedExt.Trim();
                if (!String.IsNullOrWhiteSpace(allowedExt)) 
                {
                    
                    if (String.Equals(fileNameExtension, trimExt, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
#if DEBUG
                MessageBox.Show("This message displayed for debugging");
#endif

                if (e.Args != null && e.Args.Count() > 0)
                {
                    var argument = e.Args[0];
                    Uri uri = new Uri(argument);

                    if (uri.Scheme == "mozgui-fireup")
                    {
                        var localPath = uri.LocalPath;

                        Uri fileUri = new Uri(localPath);

                        FileInfo fi = new FileInfo(fileUri.LocalPath);
                        bool fileExists = fi.Exists;
                        if (fileExists)
                        {
                            //File
                            var extension = Path.GetExtension(fileUri.LocalPath);
                            if (!String.IsNullOrWhiteSpace(extension) && extension != ".")
                            {
                                var check = checkExtension(extension.Replace(".",""));
                                if (check)
                                {
                                    Fireup(fileUri.LocalPath);
                                }
                            }
                        }
                        else
                        {
                            DirectoryInfo di = new DirectoryInfo(fileUri.LocalPath);
                            bool dirExists = di.Exists;
                            if (dirExists)
                            {
                                //Direcory
                                Fireup(fileUri.LocalPath);
                            }
                        }
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

