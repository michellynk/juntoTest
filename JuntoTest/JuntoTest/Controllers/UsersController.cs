using JuntoTest.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace JuntoTest.Controllers
{
    public class UsersController : ApiController
    {
        private static List<user> users = new List<user>();

        [HttpGet]
        public List<user> listUsers()
        {
            return users;
        }

        [HttpPost]
        public void saveUser([FromBody]string name, [FromBody]string password, int id =0)
        {
           users.Add
        }
    }
}
