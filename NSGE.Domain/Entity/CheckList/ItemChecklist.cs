using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Dtos.CheckList;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.CheckList
{
    public class ItemChecklist : EntityBase
    {
        #region Propriedades

        [MaxLength(32)]
        public string ParentId { get; set; }

        [MaxLength(65)]
        public string Descricao { get; set; }

        public int Ordem { get; set; }

        #endregion Propriedades

        #region NotMappeds

        [NotMapped]
        public string OldParent { get; set; }

        [NotMapped]
        public int OldOrdem { get; set; }

        [NotMapped]
        public int Nivel { get; set; }

        [NotMapped]
        public bool isParent
        {
            get
            {
                return string.IsNullOrEmpty(ParentId) || ParentId.Equals("#");
            }
        }

        [NotMapped]
        public bool isParentChanged { get; set; }

        [NotMapped]
        public int Quantidade { get; set; }

        #endregion NotMappeds

        #region Construtores

        public ItemChecklist()
        {
            this.ParentId = "#";
        }

        public ItemChecklist(ItemTreeView item)
        {
            if (!string.IsNullOrEmpty(item.id))
                this.Id = item.id;

            this.Descricao = item.text;
            this.Ordem = item.ordem;
            this.OldOrdem = item.oldOrdem;
            this.ParentId = string.IsNullOrEmpty(item.parent) ? "#" : item.parent;
            this.OldParent = string.IsNullOrEmpty(item.oldParent) ? "#" : item.oldParent;

            this.isParentChanged = !item.parent.Equals(item.oldParent);
        }

        #endregion Construtores
    }
}