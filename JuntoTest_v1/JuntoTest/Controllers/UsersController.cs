using JuntoTest.Models;
using JuntoTest.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace JuntoTest.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private static List<user> users = new List<user>();

        [System.Web.Http.HttpGet]
        [Produces(typeof(user))]
        public bool listUsers()
        {
            var users = _userRepository.GetAll();

            if (users.Count() == 0)
                return true;

            return false;
        }
    }
}
