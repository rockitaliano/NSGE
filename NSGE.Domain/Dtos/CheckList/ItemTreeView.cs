using NSGE.Domain.Entity.Interface;

namespace NSGE.Domain.Dtos.CheckList
{
    public class ItemTreeView : ITreeView
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string oldParent { get; set; }
        public string text { get; set; }
        public int ordem { get; set; }
        public int oldOrdem { get; set; }
        public string icon { get; set; }

        public ItemTreeView()
        {
            this.icon = "fa fa-folder-open";
        }

        public ItemTreeView(string id, string parentId, string text)
            : this()
        {
            this.id = id;
            this.parent = string.IsNullOrEmpty(parentId) ? "#" : parentId;
            this.text = text;
        }
    }
}