using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CollaboratorBL:IcollaboratorBL
    {
        private readonly IcollaboratorRL icollaboratorRL;

        public CollaboratorBL( IcollaboratorRL icollaboratorRL)
        {
            this.icollaboratorRL = icollaboratorRL;
        }

        public ColaboratorModel CreateCollaborator(long UserId , ColaboratorModel colaboratorModel )
        {
            try
            {
                return icollaboratorRL.CreateCollaborator(UserId, colaboratorModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<CollaboratorEntity> GetCollaborators()
        {
            try
            {
                return icollaboratorRL.GetCollaborator();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool RemoveCollaborator(int CollaboratorId)
        {
            try
            {
                return icollaboratorRL.RemoveCollaborator(CollaboratorId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
