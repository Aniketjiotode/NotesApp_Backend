using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using System;
using System.Linq;

namespace FundooNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly InotesBL inotesBL;
        private readonly FundooContext fundooContext;
        private  readonly long UserID;

        public NotesController(InotesBL inotesBL, FundooContext fundooContext)
        {
            this.inotesBL = inotesBL;
            this.fundooContext = fundooContext;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateNotes")]
        public IActionResult CreateNotes(NotesModel notesModel)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.CreateNote(notesModel,UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Notes Created Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "unable to Create Note" });
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Getnotes")]

        public IActionResult GetNotes ()
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.GetallNotesbyuser(UserID); 
                if (result != null)
                {
                    return Ok(new { success = true, message = "Got Notes Successfuly", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "unable to get Notes" });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("DeleteNote")]

        public IActionResult Deleteuser(int NoteId)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.RemoveNote(NoteId,UserID);
                if (result != false)
                {
                    return Ok(new { success = true, message = " Deleted Notes"});
                }
                else
                {
                    return BadRequest(new { success = false, message = "unable to delete Notes" });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("UpdateNote")]

        public IActionResult UpdateNote(UpdateNoteModel updateNoteModel)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.UpdateNote(updateNoteModel,UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Notes updated" ,data=result});
                }
                else
                {
                    return BadRequest(new { success = false, message = "unable to update Notes"});
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("Getnotesbyuser")]

        public IActionResult GetNotesbyuser()
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.GetallNotesbyuser(UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Got Notes Successfuly", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "unable to get Notes" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("updatetrash")]

        public IActionResult Updatetrash(long NoteID)
        {
            try
            {
           
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.Updatetrash(UserID, NoteID);
                if (result)
                {
                    return Ok(new { success = true, message = "trash update Successfuly", data = result });

                } else
                {
                    return BadRequest(new { success = false, message = "unable to get Notes" });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        
        [Authorize]
        [HttpPut]
        [Route("updatepin")]
        public IActionResult Updatepin(long NoteID)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.Updatepin(UserID, NoteID);
                if (result)
                {
                    return Ok(new { success = true, message = "trash update Successfuly", data = result });

                } else
                {
                    return BadRequest(new { success = false, message = "unable to get Notes" });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        
        [Authorize]
        [HttpPut]
        [Route("updatearchive")]
        public IActionResult Updatearchive(long NoteID)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.Updatearchive(UserID, NoteID);
                if (result)
                {
                    return Ok(new { success = true, message = "trash update Successfuly", data = result });

                } else
                {
                    return BadRequest(new { success = false, message = "unable to get Notes" });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  

        [Authorize]
        [HttpPut]
        [Route("updateColor")]
        public IActionResult UpdateColor(NoteColorModel noteColorModel)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.UpdateColor(UserID, noteColorModel);
                if (result!=null)
                {
                    return Ok(new { success = true, message = "Color update Successfuly", data = result });

                } else
                {
                    return BadRequest(new { success = false, message = "unable to Update Color" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("updateImage")]
        public IActionResult UpdateColor(long NoteId,IFormFile Image)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.UpdateImage(UserID,NoteId,Image);
                if (result)
                {
                    return Ok(new { success = true, message = "Image update Successfuly", data = result });

                } else
                {
                    return BadRequest(new { success = false, message = "unable to Update Image" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Getmacthingdata")]

        public IActionResult Getmacthingdata(string input)
        {
            try
            {

                var result = inotesBL.Getmacthingdata(input,UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Got Notes Successfuly", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "unable to get Notes" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
