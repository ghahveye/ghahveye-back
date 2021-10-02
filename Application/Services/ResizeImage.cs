using Application.DataTransferObjects.User;
using System;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace Application.Services
{
    class Upload
    {
        public static string UploadImage(UpdateUserAvatarDto image)
        {
            var dir = Directory.GetCurrentDirectory() + "\\wwwroot\\";

            if (image.Avatar.Length > 0)
            {
                if (image.Avatar.FileName.EndsWith(".png") || image.Avatar.FileName.EndsWith(".jpg") || image.Avatar.FileName.EndsWith(".jpeg"))
                {
                    var NewFileName = image.Avatar.FileName;
                    NewFileName = Guid.NewGuid().ToString();
                    if (!Directory.Exists(dir + "\\Uploads\\UserAvatar\\"))
                    {
                        Directory.CreateDirectory(dir + "\\Uploads\\UserAvatar\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(dir + "\\Uploads\\UserAvatar\\" + NewFileName))
                    {

                        image.Avatar.CopyTo(filestream);
                        filestream.Flush();
                        return NewFileName;
                    }
                }
                else
                {
                    return "false";
                }
            }
            return "false";
        }
    }

}