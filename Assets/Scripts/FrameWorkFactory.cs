using System;

public class FrameworkFactory : Singleton<FrameworkFactory>, IFrameworkFactory
{
    public IFramework GetFrameWork(string templateID)
    {
        switch (templateID)
        {
            case "1XvFW-Y2k":
                return new FacebookFrameWork(templateID);
            case "SJKM9Ns_ibQ":
                return new FacebookConnectFrameWork(templateID);
            case "XYQZBUojc":
                return new FacebookSocialPluginFrameWork(templateID);

        }

        return new UnknownFramework(templateID);
    }
}