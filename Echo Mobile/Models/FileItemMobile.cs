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
        private string _image_Name;
        public string Image_Name
        {
            get
            {
                switch (this.Type)
                {
                    case FileType.file:
                        return $"blank_icon.png";

                    case FileType.directory:
                        return $"folder_icon.png";

                    case FileType.zip:
                        return $"zip.png";

                    case FileType.png:
                        return $"picture_icon.png";

                    case FileType.jpg:
                        return $"picture_icon.png";

                    case FileType.jpeg:
                        return $"picture_icon.png";

                    case FileType.exe:
                        return $"exe_icon.png";

                    case FileType.txt:
                        return $"notes_icon.png";

                    case FileType.mp4:
                        return $"video_icon.png";

                    default:
                        return $"blank_icon.png";

                };
            }
           
        }
        public FileItemMobile(FileType type, string name, DateTime last_update) : base(type, name, last_update)
        {
            this.Type = type;
            this.Name = name;
            this.Last_update = last_update;
        }
    }
}
