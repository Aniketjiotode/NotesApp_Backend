using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IcollaboratorRL
    {
        public ColaboratorModel CreateCollaborator(long UserId, ColaboratorModel colaboratorModel);
        public IEnumerable<CollaboratorEntity> GetCollaborator();
        public bool RemoveCollaborator(int collaboratorId);

    }
}
