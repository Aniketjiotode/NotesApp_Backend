using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using System.Linq;
using System;
using CommonLayer.Model;

namespace FundooNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private readonly IcollaboratorBL icollaboratorBL;
        private readonly FundooContext fundooContext;


        public CollaboratorController(IcollaboratorBL icollaboratorBL, FundooContext fundooContext)
        {
            this.icollaboratorBL = icollaboratorBL;
            this.fundooContext = fundooContext;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateCollaborator")]

        public IActionResult CreateCollab(ColaboratorModel colaboratorModel)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = icollaboratorBL.CreateCollaborator(UserID, colaboratorModel);

                if (result != null)
                {

                    return Ok(new { success = true, message = "Collaborator Created Successful ", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unable to  Create Collaborator" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetCollaborator")]

        public IActionResult GetCollaborator()
        {
            try
            {
                var result = icollaboratorBL.GetCollaborators();
                var _result= result.Select(a => new {a.NoteID,a.EmailId,a.UserId,a.ColaboratorId}).ToString();
                string data = null;
                foreach (var item in _result)
                {
                    data += _result + " ";
                }
                if(data != null)
                {
                    return Ok(new { success = true, message = "Get all Collaborator Successful ", data = result });

                }
                else return BadRequest(new { success = false, message = "Unable to  get Collaborator" });

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteCollaborator")]
        public IActionResult Deleteuser(int CollaboratorId)
        {
            try
            {
                var result = icollaboratorBL.RemoveCollaborator(CollaboratorId);
                if (result != false)
                {
                    return Ok(new { success = true, message = " Deleted Collaborator" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "unable to delete Collaborator" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
