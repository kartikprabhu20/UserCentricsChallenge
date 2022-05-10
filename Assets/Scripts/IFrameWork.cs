public interface IFramework
{
    void init();
    void process();
    string getTemplateId();
    void enableFrameWork(bool enable);
}