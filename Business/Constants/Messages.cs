using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserList = "Kullanıcılar listelendi";

        public static string BasketList = "Sepetteki ürünler listelendi.";

        public static string UserAdded = "Kullanıcı kaydı başarılı";

        public static string SuccessUserData = "Kullanıcı bilgisi gönderildi";

        public static string ProductAdded = "Ürün Eklendi";

        public static string ProductCountOfCategoryError = "Alt kategori limit aşımı";
        public static string ProductNameAlreadyExists = "Aynı isimde ürün mevcut";

        public static string GetProduct = "Ürün getirildi";
        

        public static string MaintenanceTime = "Sistem Bakımda";

        public static string ProductList = "Ürünler listelendi";
        public static string ProductsNotFound = "Ürün bulunamadı";
        public static string AuthorizationDenied = "Yetkin yok";
        public static string GetUser = "Kulanıcı mevcut ve getirildi";

        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string PasswordError = "Şifre hatalı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kullanıcı kaydı başarılı";

        public static string SubCategoryNotActive = "Eklenmek istenen alt kategori aktif değil";

        public static string SuccessAllCategories = "Kategoriler ve alt kagetorileri listelendi";
        public static string ErrorAllCategories = "Kategoriler ve alt kategoriler bulunamadı";

        public static string ErrorSubCategories = "işlem başarısız";
        public static string GetSubCategories = "Alt kategoriler listelendi";

        public static string GetBrands = "Markalar listlendi";
        public static string ErroyGetBrands = "Marka bulunamadı";

        public static string ErrorProductList = "Ürünler bulunamadı";

        public static string CartAddSuccessful = "Ürün Sepete Başarılı Bir Şekilde Eklendi";

        public static string CartAddError = "Sepete ekleme işlemi başarısız";
    }
}
