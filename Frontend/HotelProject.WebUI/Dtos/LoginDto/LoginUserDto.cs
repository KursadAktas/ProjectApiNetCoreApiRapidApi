using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {

        [Required(ErrorMessage = "Kullanıcı adı girilmesi zorunludur.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şİfre girilmesi zorunludur.")]
        public string Password { get; set; }
    }
}
