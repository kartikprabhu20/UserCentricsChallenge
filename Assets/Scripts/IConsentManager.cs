using System.Collections.Generic;
using Unity.Usercentrics;

/// <summary>
/// Interface to bridge between userclass and UsercentricManager
/// </summary>
public interface IUsercentricBridge
{
    void onComplete();
    void onError(string errorMessage);
}

public interface IUsercentricBridgeUpdate : IUsercentricBridge
{
    void onServiceUpdate(List<UsercentricsServiceConsent> consents);
}