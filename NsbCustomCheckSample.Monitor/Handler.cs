using System;
using NServiceBus;
using ServiceControl.Contracts;

namespace NsbCustomCheckSample.Monitor
{
  public class Handler : IHandleMessages<CustomCheckFailed>,
                                   IHandleMessages<CustomCheckSucceeded>
  {
    #region Apis

    public void Handle(CustomCheckFailed message)
    {
      Console.WriteLine("'{0}' does not work at {1} on {2}: {3}", message.CustomCheckId, message.FailedAt,
                        message.EndpointName, message.FailureReason);
    }

    public void Handle(CustomCheckSucceeded message)
    {
      Console.WriteLine("'{0}' works as expected at {1} on {2}", message.CustomCheckId, message.SucceededAt,
                        message.EndpointName);
    } 

    #endregion
  }
}