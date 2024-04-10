namespace NSGE.Domain.Entity.Interface
{
    public interface ITreeView
    {
        string id { get; set; }
        string parent { get; set; }
        string oldParent { get; set; }
        string text { get; set; }
        int ordem { get; set; }
        int oldOrdem { get; set; }
        string icon { get; set; }
    }
}