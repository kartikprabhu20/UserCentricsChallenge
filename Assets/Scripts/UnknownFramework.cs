using UnityEngine;


public class UnknownFramework : Framework
{
    public UnknownFramework(string templateId) : base(templateId)
    {
    }

    public override void enableFrameWork(bool enable)
    {
       Debug.Log("UnknownFramework enabled");
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