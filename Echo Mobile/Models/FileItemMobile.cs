using EchoUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echo_Mobile.Models
{
    public class FileItemMobile : FileItem
    {
        public string Image_Name = $"https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg";
        public FileItemMobile(FileType type, string name, DateTime last_update) : base(type, name, last_update)
        {
            this.Type = type;
            this.Name = name;
            this.Last_update = last_update;


            switch (type)
            {
                case FileType.file:
                    Image_Name = $"Resources/Images/blank_icon.png";
                    break;
                case FileType.directory:
                    Image_Name = $"https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg";
                    break;
                case FileType.zip:
                    Image_Name = $"Resources/Images/zip.png";
                    break;
                case FileType.png:
                    Image_Name = $"Resources/Images/picture_icon.png";
                    break;
                case FileType.jpg:
                    Image_Name = $"Resources/Images/picture_icon.png";
                    break;
                default:
                    Image_Name = $"Resources/Images/blank_icon.png";
                    break;
            }
        }
    }
}
