using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

public class UserModel
{
    public class Repository
    {
        DatabaseModel DbContext = new DatabaseModel();
        public List<User> ShowUsers()
        {
            return DbContext.Users.ToList();
        }
        public void InsertUser(User user)
        {
            user.HashedPassword = Encryption(user.HashedPassword);
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User userToUpdate = DbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.FirstName;
                userToUpdate.UserName = user.UserName;
                userToUpdate.StreetAdress = user.StreetAdress;
                userToUpdate.StreetNumber = user.StreetNumber;
                userToUpdate.UserLevel = user.UserLevel;
                DbContext.SaveChanges();

            }

        }

        public void DeleteUser(User user)
        {
            User userToDelete = DbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            DbContext.Users.Remove(userToDelete);
            DbContext.SaveChanges();
        }
    }

    public static bool ValidateUser(User user)
    {
        DatabaseModel dbContext = new DatabaseModel();

        User userToValidate = dbContext.Users.FirstOrDefault(u => u.UserName == user.UserName);
        if (userToValidate == null)
            return false;

        else
        {
            bool isUserValidated = Compare(user.HashedPassword, userToValidate.HashedPassword);

            return isUserValidated;
        }
    }

    public static string Encryption(string data)
    {
        //create neew instance of 256
        SHA256 sha1 = SHA256.Create();

        //convert to bytes
        byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

        //create new instance of stringbuilder to save hashed data
        StringBuilder returnValue = new StringBuilder();

        for (int i = 0; i < hashData.Length; i++)
            returnValue.Append(hashData[i].ToString());

        return returnValue.ToString();
    }

    private static bool Compare(string inputData, string storedHashData)
    {
        string getHashInputData = Encryption(inputData);

        return String.CompareOrdinal(getHashInputData, storedHashData) == 0;
    }

    public static string UserLevelDictionary(int value)
    {

        if (value == 1)
            return "Admin";
        else
            return "User";

    }

    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; }

        [Required, StringLength(256)]
        public string HashedPassword { get; set; }
        
        [Required]
        public int UserLevel { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string StreetAdress { get; set; }

        public int StreetNumber { get; set; }

    }


}