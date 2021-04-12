using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserListed="Kullanıcı listelendi";
        public static string CarAdded = "Araç eklendi";
        public static string BrandInvalid = "Geçersiz araba markası";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarUpdated="Araç düzeltildi";
        public static string CarDeleted = "Araç silindi";
        public static string UserAdded="Kullanıcı eklendi";
        public static string UsersListed="Kullanıcılar listelendi";
        public static string CustomersListed="Müşteriler listelendi";
        public static string RentalsListed="Kiralama işlemleri listelendi";
        public static string CustomerAdded="Müşteri eklendi";
        public static string CustomerUpdated="Müşteri düzeltildi";
        public static string CustomerDeleted="Müşteri silindi";
        public static string CustomerListed="Müşteri listelendi";
        public static string UserUpdated="Kullanıcı düzeltildi";
        public static string UserDeleted="Kullanıcı silindi";
        public static string RentalAdded="Kiralama işlemi eklendi";
        public static string CarNotReturned="Bu araç daha kiralamadan geri gelmemiş. Tekrar kiralanamaz";
        public static string BrandAdded="Marka eklendi";
        public static string CarIsRentable="Araç kiralanabilir durumdadır.";
        public static string CarImageAdded="Araç resmi eklendi";
        public static string CarImagesListed="Araç resimleri listelendi";
        public static string CarImageLimitExceded="Araç resim limiti aşıldı.";
        public static string CarImageDeleted="Araç resmi silindi";
        public static string CarImageUpdated="Araç resmi değiştirildi";
        public static string CarImageNotExist="Araç resmi yoktur.";
        public static string CarIdDosntExists="Böyle bir araç nosu yoktur";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kullanıcı kaydedildi";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Parola hatalı";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Token oluşturuldu";
    }
}
