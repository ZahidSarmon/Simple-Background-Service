using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Topshelf;

namespace BeatService
{
    internal static class HostConfig
    {
        internal static void Config()
        {
            var exitCode=HostFactory.Run(x=>{
                x.Service<BeatHelp>(s=>{
                    s.ConstructUsing(a=>new BeatHelp());
                    s.WhenStarted(a=>a.Start());
                    s.WhenStopped(a=>a.Stop());
                });
                x.RunAsLocalSystem();
                x.SetServiceName("BeatService");
                x.SetDisplayName("Beat Service");
                x.SetDescription("Beat Service with TopShelf");
            });
            int exitCodeValue=(int)Convert.ChangeType(exitCode,exitCode.GetTypeCode());
            Environment.ExitCode=exitCodeValue;
        }
    }
}