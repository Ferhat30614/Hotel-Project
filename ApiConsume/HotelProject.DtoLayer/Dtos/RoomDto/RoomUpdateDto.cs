using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
       
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Lütfen oda numarası giriniz")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Lütfen oda görseli giriniz")]
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen Fiyat giriniz")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen Başlık giriniz")]
        [StringLength(100,ErrorMessage ="Lütfen en fazla 100 karakter giriniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen Yatak sayısı giriniz")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen Banyo sayısı giriniz")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }

        [Required(ErrorMessage = "Lütfen Açıklamayı giriniz")]
        public string Description { get; set; }
    }
}
