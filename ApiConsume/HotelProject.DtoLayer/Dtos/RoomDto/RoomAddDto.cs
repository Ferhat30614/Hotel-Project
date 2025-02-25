﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [Required(ErrorMessage = "Lütfen oda numarası giriniz")]
        public string RoomNumber { get; set; }  
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage ="Lütfen Fiyat giriniz")]
        public int Price { get; set; } 
        [Required(ErrorMessage = "Lütfen Başlık giriniz")]
        public string Title { get; set; } 
        [Required(ErrorMessage = "Lütfen Yatak sayısı giriniz")]
        public string BedCount { get; set; } 
        [Required(ErrorMessage = "Lütfen Banyo sayısı giriniz")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }

    }
}
