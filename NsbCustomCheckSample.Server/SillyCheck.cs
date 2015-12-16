using System;
using System.Linq;
using ServiceControl.Plugin.CustomChecks;

namespace NsbCustomCheckSample.Server
{
  public class SillyCheck : PeriodicCheck
  {
    #region Constructors

    public SillyCheck()
      : base(typeof(SillyCheck).Name.Split('.').Last(), "Sample checks", TimeSpan.FromSeconds(10))
    {}

    #endregion

    #region Overrides

    public override CheckResult PerformCheck()
    {
      var willPass = DateTime.Now.Millisecond % 2 == 0;
      Console.WriteLine("Running custom check, and will {0}...", willPass ? "pass" : "fail");

      return willPass ? CheckResult.Pass: CheckResult.Failed("Failed " + DateTime.UtcNow);
    }

    #endregion
  }
}