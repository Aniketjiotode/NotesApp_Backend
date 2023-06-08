using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IlabelRL
    {
        public LabelModel CreateLabel(LabelModel labelModel, long UserId);
        public IEnumerable<LabelEntity> GetLabels(long UserId);
        public LabelModel Updatelabel(LabelModel labelModel, int LabelId,long UserId);
        public bool RemoveLabel(int LabelId, long UserId);

    }
}
