using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FundooNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly IlabelBL ilabelBL;

        public LabelController(IlabelBL ilabelBL)
        {
            this.ilabelBL = ilabelBL;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateLabel")]

        public IActionResult CreateLabel(LabelModel labelmodel)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);

                var result = ilabelBL.CreateLabel(labelmodel,UserID);
                if (result != null)
                {

                    return Ok(new { success = true, message = "Label Created Successful ", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unable to  Create Label" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Getlabel")]

        public IActionResult GetCollaborator()
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = ilabelBL.GetLabels(UserID);
                var _result = result.Select(a => new { a.NoteID, a.LabelId, a.LabelName,a.UserId }).ToString();
                string data = null;
                foreach (var item in _result)
                {
                    data += _result + " ";
                }
                if (data != null)
                {
                    return Ok(new { success = true, message = "Get all labels Successful ", data = result });

                }
                else return BadRequest(new { success = false, message = "Unable to  get label" });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("UpdateLabel")]

        public IActionResult UpdateLabel(LabelModel labelmodel ,int LabelId)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = ilabelBL.Updatelabel(labelmodel,LabelId,UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Updated labels Successful ", data = result });
                }
                else return BadRequest(new { success = false, message = "Unable to  Update label" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteLabel")]
        public IActionResult DeleteLabel(int LabelId)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result=ilabelBL.Removelabel(LabelId,UserID);
                if (result)
                {
                    return Ok(new { success = true, message = "Deleted labels Successful ", data = result });
                }
                else return BadRequest(new { success = false, message = "Unable to  Delete label" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
