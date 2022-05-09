using System.Diagnostics;

public class UnknownFramework : FrameWork
{
    public UnknownFramework(string templateId) : base(templateId)
    {
    }

    public override void enableFrameWork(bool enable)
    {
        throw new System.NotImplementedException();
    }

    public override void init()
    {
        throw new System.NotImplementedException();
    }

    public override void process()
    {
        throw new System.NotImplementedException();
    }
}