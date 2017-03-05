using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClashSharpBot.Bot.Packages
{
    public interface IPackage : IDisposable
    {
        string PackageName { get; }
        void Execute();
    }
}
