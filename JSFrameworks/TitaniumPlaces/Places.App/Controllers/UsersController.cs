namespace Places.App.Controllers
{
    using System;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using Places.Data;
    using Places.App.Attributes;
    using Places.App.Models;
    using Places.Models;
    using System.Collections.Generic;

    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 5;
        private const int MaxUsernameLength = 30;
        private const int MinDisplayNameLength = 5;
        private const int MaxDisplayNameLength = 30;
        private const int Sha1AuthCodeLength = 40;
        private const int SessionKeyLength = 50;
        private const string ValidUsernameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890_.";
        private const string ValidDisplayNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_- .";
        private const string SessionKeyCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static readonly Random random = new Random();

        // POST api/users/register
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(UserRegisteredModel userModel)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();
                    using (context)
                    {
                        this.ValidateUsername(userModel.Username);
                        this.ValidateNickname(userModel.Nickname);
                        this.ValidateAuthCode(userModel.AuthCode);

                        string usernameToLower = userModel.Username.ToLower();
                        string nicknameToLower = userModel.Nickname.ToLower();

                        User user = context.Users
                                           .FirstOrDefault(u => u.Username.ToLower() == usernameToLower ||
                                                                u.Nickname == nicknameToLower);
                        if (user != null)
                        {
                            throw new InvalidOperationException("The user already exists.");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            Nickname = userModel.Nickname,
                            AuthCode = userModel.AuthCode,
                            Role = Role.User
                        };
                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();

                        UserLoggedInModel loggedInUser = new UserLoggedInModel()
                        {
                            Nickname = user.Nickname,
                            SessionKey = user.SessionKey
                        };

                        return this.Request.CreateResponse(HttpStatusCode.Created, loggedInUser);
                    }
                });

            return responseMessage;
        }

        // POST api/users/login
        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser(UserRegisteredModel userModel)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();
                    using (context)
                    {
                        this.ValidateUsername(userModel.Username);
                        this.ValidateAuthCode(userModel.AuthCode);

                        string usernameToLower = userModel.Username.ToLower();

                        User existingUser = context.Users
                                                   .FirstOrDefault(u => u.Username.ToLower() == usernameToLower);
                        if (existingUser == null)
                        {
                            throw new ArgumentNullException("The user does not exist.");
                        }

                        if (existingUser.SessionKey == null)
                        {
                            existingUser.SessionKey = this.GenerateSessionKey(existingUser.Id);
                            context.SaveChanges();
                        }

                        UserLoggedInModel loggedUser = new UserLoggedInModel()
                        {
                            Nickname = existingUser.Nickname,
                            SessionKey = existingUser.SessionKey
                        };

                        return this.Request.CreateResponse(HttpStatusCode.Created, loggedUser);
                    }
                });

            return responseMessage;
        }

        // PUT api/users/logout
        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();
                    using (context)
                    {
                        User existingUser = context.Users
                                                   .FirstOrDefault(u => u.SessionKey == sessionKey);
                        if (existingUser == null)
                        {
                            throw new ArgumentNullException("The user does not exist or is already logged out.");
                        }

                        existingUser.SessionKey = null;
                        context.SaveChanges();

                        return this.Request.CreateResponse(HttpStatusCode.NoContent);
                    }
                });

            return responseMessage;
        }

        // PUT api/users/id
        [HttpPut]
        [ActionName("edit")]
        public HttpResponseMessage PutUser([FromBody] UserEditModel userEditModel, [FromUri]int id, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();

                    using (context)
                    {
                        User existingUser = GetUserBySessionKey(context, sessionKey);

                        if (existingUser == null)
                        {
                            throw new ArgumentNullException("The user does not exist or is already logged out.");
                        }

                        // check if user is admin
                        if (existingUser.Role != Role.Admin)
                        {
                            throw new InvalidOperationException("User is not admin and cannot see admin information.");
                        }

                        User editedUser = context.Users.Find(userEditModel.Id);

                        if (editedUser == null)
                        {
                            throw new ArgumentNullException(String.Format("Invalid user id: {0}. User not found.", userEditModel.Id));
                        }

                        if (ModelState.IsValid && id == userEditModel.Id)
                        {
                            editedUser.Nickname = userEditModel.Nickname;
                            editedUser.Role = (Role)userEditModel.Role;

                            context.Entry(editedUser).State = EntityState.Modified;

                            try
                            {
                                context.SaveChanges();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                return Request.CreateResponse(HttpStatusCode.NotFound);
                            }

                            return Request.CreateResponse(HttpStatusCode.NoContent);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest);
                        }              
                    }                     
                });

            return responseMessage;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<UserEditModel> GetAllUsers([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    PlacesContext context = new PlacesContext();

                    // check if user is valid
                    User existingUser = GetUserBySessionKey(context, sessionKey);
                    if (existingUser == null)
                    {
                        throw new ArgumentNullException("The user does not exist or is already logged out.");
                    }

                    // check if user is admin
                    if (existingUser.Role != Role.Admin)
                    {
                        throw new InvalidOperationException("User is not admin and cannot see admin information.");
                    }

                    var userEntities = context.Users;

                    var userModels =
                                    from userEntity in userEntities
                                    select new UserEditModel()
                                    {
                                        Id = userEntity.Id,
                                        Nickname = userEntity.Nickname,
                                        Role = (int)userEntity.Role
                                    };

                    return userModels.ToList();

                });

            return responseMessage;
        }

        internal static User GetUserBySessionKey(PlacesContext context, string sessionKey)
        {
            var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
            if (user == null)
            {
                throw new ArgumentNullException("user", "The user does not exist or is already logged out.");
            }

            return user;
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("The username must not be null.");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException("username", string.Format("The username must be at least {0} symbols.", MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException("username", string.Format("The username must be at most {0} symbols.", MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentException("The username must contain only Latin characters, digits, underscores and dots.");
            }
        }

        private void ValidateNickname(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("The display name must not be null.");
            }
            else if (nickname.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException("displayName", string.Format("The display name must be at least {0} symbols.", MinDisplayNameLength));
            }
            else if (nickname.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException("displayName", string.Format("The display name must be at most {0} symbols.", MaxDisplayNameLength));
            }
            else if (nickname.Any(ch => !ValidDisplayNameCharacters.Contains(ch)))
            {
                throw new ArgumentException("The display name must contain only Latin characters, digits, spaces, underscores, dashes, spaces and dots.");
            }
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null)
            {
                throw new ArgumentNullException("The authentication code must not be null.");
            }
            else if (authCode.Length != Sha1AuthCodeLength)
            {
                throw new ArgumentException("The authentication code must be encrypted with SHA-1.");
            }
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder sessionKey = new StringBuilder();
            sessionKey.Append(userId);
            while (sessionKey.Length < SessionKeyLength)
            {
                int index = random.Next(SessionKeyCharacters.Length);
                sessionKey.Append(SessionKeyCharacters[index]);
            }

            return sessionKey.ToString();
        }
    }
}