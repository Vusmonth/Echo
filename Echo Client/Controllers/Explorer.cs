using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EchoUtility;

namespace Echo_Client.Controllers
{
    public class Explorer
    {
        public string currentRoute = "";
        private List<FileItem> files = new List<FileItem>();

        public Explorer(string initialRoute)
        {
            this.currentRoute = initialRoute;
            this.ListFiles();

        }

        public void GoBack(string route)
        {

        }

        public List<FileItem> ListFiles()
        {
            if (Directory.Exists(currentRoute))
            {

                foreach (var item in Directory.GetDirectories(currentRoute))
                {
                    FileItem dir = new(FileType.directory, item, DateTime.Now);
                    files.Add(dir);
                    Console.WriteLine(dir);
                }

                foreach (var item in Directory.GetFiles(currentRoute))
                {

                    FileItem file = new(this.GetType($"{currentRoute}\\{item}"), item, DateTime.Now);
                    files.Add(file);
                    Console.WriteLine($"{file.Name} | {file.Type}");
                }

            }

            return files;
        }

        private FileType GetType(string path)
        {
            string ext = Path.GetExtension(path).ToLower().Remove(0, 1);

            if (Enum.TryParse(typeof(FileType), ext, out object resultado))
            {
                FileType type = (FileType)resultado;
                return type;
            }

            return FileType.file;
        }
    }
}
