using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notepad.Models;

namespace Notepad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotepadController : ControllerBase
    {
            private NotepadDataContext context;
            public NotepadController(NotepadDataContext context)
            {
                this.context = context;
            }
            // GET api/values
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(context.Users.ToList());
            }

            [HttpGet("{id}", Name = "GetUserById")]
            public IActionResult Get(int id)
            {
                return Ok(context.Users.Find(id));
            }

            [HttpPost]
            public IActionResult Post([FromBody] User user)
            {
                context.Users.Add(user);
                context.SaveChanges();
                string url = Url.Link("GetUserById", new { id = user.Id });
                return Created(url, user);
            }


            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] User user)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();

            }
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {

                context.Users.Remove(context.Users.Find(id));
                context.SaveChanges();
                return Ok();

            }

        }
    }
