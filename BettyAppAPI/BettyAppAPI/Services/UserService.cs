using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettyAppAPI.Helpers;
using BettyAppAPI.Models;

namespace BettyAppAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(string id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(string id);
    }
    public class UserService : IUserService
    {
        //This is our database handle that gives us access to CRUD operations on the database
        private DatabaseContext _context;

        //Constructor which initializes the database context
        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        //This method matches a user and passwordHash on the database and returns the User if theres a match
        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return null;
            var user = _context.Users.SingleOrDefault(users => users.email == email);
            if (user == null) return null;
            if (!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt)) return null;
            return user;
        }

        //This method returns all users on the database
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        //This method returns a user with a specific id
        public User GetById(string id)
        {
            return _context.Users.Find(id);
        }

        //This method creates/registers a new user on the database given a user profile and a password
        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new AppException("Password Required");
            if (_context.Users.Any(users => users.email == user.email)) throw new AppException("There's an existing account with email " +
                 "\"" + user.email + "\"");
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;
            user.password = "";
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        //This method updates the details of a users profile and takes a password to authorize the update
        public void Update(User userParam, string password = null)
        {
            Console.WriteLine("Updating the user profile...");
            var user = _context.Users.Find(userParam.id);

            if (user == null)
                throw new AppException("User not found");

            if (userParam.email != user.email)
            {
                // username has changed so check if the new username is already taken
                if (_context.Users.Any(x => x.email == userParam.email))
                    throw new AppException("Email " + userParam.email + " is already taken");
            }

            // update user properties
            user.firstname = userParam.firstname;
            user.lastname = userParam.lastname;
            user.email = userParam.email;
            user.occupation = userParam.occupation;
            user.gender = userParam.gender;
            user.residentialAddress = userParam.residentialAddress;
            user.contact_no = userParam.contact_no;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.passwordHash = passwordHash;
                user.passwordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
            Console.WriteLine("Done updating user profile...");
        }

        //This method deletes a user of a particular id
        public void Delete(string id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        //--------------------------------Helpers--------------------------------------------------------------------------------------------
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
