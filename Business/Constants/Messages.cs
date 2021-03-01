using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarListed = "Araçlar listelendi";


        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandListed = "Marka listelendi";
        public static string BrandExist = "Marka Var";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorListed = "Renk listelendi";
        public static string ColorExist = "Renk Var";


        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserListed = "Kullanıcılar listelendi";
        public static string UserGet = "Kullanıcılar bilgileri getirildi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";        
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerListed = "Müşteriler listelendi";
        public static string CustomerGet = "Müşteri bilgileri getirildi";

        public static string RentalAdded = "Araç kiralandı";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalDeleted = "Kiralama Silindi";
        public static string RentalListed = "Kiralamalar listelendi";
        public static string RentalGet = "Kiralama bilgileri getirildi";
        public static string RentalNotAvailable = "Araç musait degil!";
        public static string RentalAvailable = "Araç musait";

        public static string CarImageAdded ="Araba resmi eklendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageCountOfCarError= "Bir arabanın en fala 5 resmi olabilir";
    }
}
