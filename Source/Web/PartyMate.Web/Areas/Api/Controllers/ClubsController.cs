using PartyMate.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PartyMate.Web.Areas.Api.Controllers
{
    // dummy controller
    public class ClubsController : ApiController
    {
        private IUserService users;

        public ClubsController(IUserService users)
        {
            this.users = users;
        }

        public IHttpActionResult GetUsers()
        {
            var result = this.users.GetAll().ToArray();
            return this.Ok(result);
        }

        // POST: api/Clubs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clubs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clubs/5
        public void Delete(int id)
        {
        }
    }
}
