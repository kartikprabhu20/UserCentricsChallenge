using UnityEngine;

public class FacebookFrameWork : Framework
{
    public FacebookFrameWork(string templateId) : base(templateId)
    {

    }
   
    public override void enableFrameWork(bool enable)
    {
        //Facebook.enable = enable;
    }

    public override void init()
    {
        Debug.Log("init FacebookFrameWork");
    }

    public override void process()
    {
        Debug.Log("process FacebookFrameWork");
    }
}