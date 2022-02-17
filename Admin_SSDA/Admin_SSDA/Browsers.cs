using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDde.Client;
namespace Admin_SSDA
{
    class Browsers
    {
        private readonly Dictionary<string, string> browsers = new Dictionary<string, string>
                                                  {
                                                      {
                                                          "firefox", "Mozilla Firefox"
                                                      },
                                                      {
                                                          "chrome", "Google Chrome"
                                                      },
                                                      {
                                                          "opera", "Opera Mini"
                                                      },
                                                      {
                                                          "iexplore", "Internet Explorer"
                                                      },
                                                      {
                                                          "MicrosoftEdgeCP", "Microsoft Edge"
                                                      }
                                                  };

        public bool BrowserIsOpen()
        {
            return Process.GetProcesses().Any(this.IsBrowserWithWindow);
        }

        private bool IsBrowserWithWindow(Process process)
        {
            return this.browsers.TryGetValue(process.ProcessName, out var browserTitle) && process.MainWindowTitle.Contains(browserTitle);
        }

        public string GetBrowserURL(string browser)
        {
            try
            {
                DdeClient dde = new DdeClient(browser, "WWW_GetWindowInfo");
                dde.Connect();
                string url = dde.Request("URL", int.MaxValue);
                string[] text = url.Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
                dde.Disconnect();
                return text[0].Substring(1);
            }
            catch
            {
                return null;
            }
        }
    }

}
