/// <summary>
/// A dummy framework interface, which can be used to modify settings for each of the framework in CMP
/// </summary>
public interface IFramework
{
    void init();
    void process();
    string getTemplateId();
    void enableFrameWork(bool enable);
}