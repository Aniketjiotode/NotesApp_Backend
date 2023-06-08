using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL:IuserBL
    {
        private readonly IuserRL iuserRL;

        public UserBL(IuserRL iuserRL)
        {
            this.iuserRL = iuserRL;
        }   

        public UserModel Registration(UserModel userModel) {
            try
            {
                return iuserRL.Registration(userModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }    
        }

        public string Login (LoginModel loginModel)
        {
            try
            {
                return iuserRL.Login(loginModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResetModel ResetPassword(ResetModel resetModel, string Email)
        {
            try
            {
                return iuserRL.ResetPassword(resetModel,Email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public UserEntity GetUser(int id)
        {
            try
            {
                return iuserRL.getuser(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string Getalluser()
        {
            try
            {
                return iuserRL.getalluser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ForgetPaasword(string EmailId,MsmqModel msmqModel)
        {
            try
            {
                return iuserRL.ForgetPassword(EmailId, msmqModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}
