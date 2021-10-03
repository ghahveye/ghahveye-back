using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BusinessLogicErrors
    {
        public static class User
        {
            public const string UserDoesNotExist = "کاربر مورد نظر وجود ندارد.";
            public const string UserAlreadyRegistered = "کاربر قبلا ثبت نام شده است.";
            public const string UserDoesNotExistOrRefreshTokenIsInvalid = "کاربر مورد نظر وجود ندارد یا توکن معتبر نمی باشد.";
            public const string UsernameNotAvailable = "نام کاربری قابل استفاده نمی باشد.";
            public const string OtpCodeDoesNotExist = "کد اعتبارسنجی موجود نمی باشد.";
            public const string VerifyEmail = "حساب کاربری شما فعال نشده است،ابتدا آن را فعال کرده و سپس تلاش مجدد برای ورود کنید";
            public const string UserNameNotEqual = "نام کاربری وارد شده با نام کاربری کاربر پیدا شده مغایرت ندارد";
            public const string UpdateAvatarSucc = "عکس کاربر با موفقیت اپدیت شد";
            public const string EmailOrPasswordInvalid = "ایمیل یا رمز وارد شده اشتباه است";
        }
    }
}
