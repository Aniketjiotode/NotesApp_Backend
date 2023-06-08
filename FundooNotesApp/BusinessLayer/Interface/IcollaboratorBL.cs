using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IcollaboratorBL
    {
        public ColaboratorModel CreateCollaborator(long UserId, ColaboratorModel colaboratorModel);
        public IEnumerable<CollaboratorEntity> GetCollaborators();
        public bool RemoveCollaborator(int CollaboratorId);

    }
}
