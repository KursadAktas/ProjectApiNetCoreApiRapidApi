using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.Service
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet ikon giriniz.")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı giriniz.")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter giriniz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet açıklması giriniz.")]
        [StringLength(200, ErrorMessage = "En fazla 200 karakter giriniz.")]
        public string Description { get; set; }
    }
}
