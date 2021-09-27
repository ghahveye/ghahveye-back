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
        }
    }
}
