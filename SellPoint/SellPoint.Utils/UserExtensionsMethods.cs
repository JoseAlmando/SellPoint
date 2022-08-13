using SellPoint.Data.DTO;
using SellPoint.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPoint.Utils
{
    public static partial class ExtensionsMethods
    {

        public static User MapToUserEntity(this UserDTO user)
        {
            return new User
            {
                UserNameEntidad = user.Username,
                PasswordEntidad = user.PassWord.Encrypt()
            };
        }

        public static UserDTO MapToUserDTO(this User user)
        {
            return new UserDTO
            {
                Username = user.UserNameEntidad,
                PassWord = user.PasswordEntidad,
                Id = user.Id
            };
        }
    }
}
