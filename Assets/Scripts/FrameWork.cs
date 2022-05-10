using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Framework : IFramework
{
    string templateId;

    protected Framework(string templateId)
    {
        this.templateId = templateId;
    }


    public abstract void enableFrameWork(bool enable);

    public string getTemplateId()
    {
        return templateId;
    }

    public abstract void init();


    public abstract void process();
}


