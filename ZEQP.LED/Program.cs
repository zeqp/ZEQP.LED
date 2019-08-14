using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
namespace ZEQP.LED
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                x.SetServiceName("WMSQRService");
                x.SetDisplayName("WMSQRService");
                x.SetDescription("WMS二维码服务");
                x.Service<LEDService>();
                x.StartAutomatically();
                x.RunAsLocalSystem();
                x.UseNLog();
                x.EnableShutdown();
            });
            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode()); //11
            Environment.ExitCode = exitCode;
        }
    }
}
