using System.Collections.Generic;
using Unity.Usercentrics;

public interface IUsercentricBridge
{
    void onComplete();
    void onError(string errorMessage);
}

public interface IUsercentricBridgeUpdate : IUsercentricBridge
{
    void onServiceUpdate(List<UsercentricsServiceConsent> consents);
}