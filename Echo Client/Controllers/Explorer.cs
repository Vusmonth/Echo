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
        private List<FileItem> files = new();

        public Explorer(string initialRoute)
        {
            this.currentRoute = initialRoute;
            //this.ListFiles();
            Console.Clear();
            Console.WriteLine(currentRoute);
        }

        public void GoBack()
        {
            if (Directory.Exists(Directory.GetParent(currentRoute).FullName))
            {
                currentRoute = Directory.GetParent(currentRoute).FullName;
                Console.Clear();
                Console.WriteLine(currentRoute);
            }
        }

        public void NavigateTo(string route)
        {
            if (Directory.Exists($"{currentRoute}\\{route}"))
            {
                currentRoute = $"{currentRoute}\\{route}";
                Console.Clear();
                Console.WriteLine(currentRoute);
            }
        }

        public List<FileItem> ListFiles()
        {
            files.Clear();
            if (Directory.Exists(currentRoute))
            {

                foreach (var item in Directory.GetDirectories(currentRoute))
                {
                    FileItem dir = new(FileType.directory, item.Replace(currentRoute, ""), DateTime.Now);
                    files.Add(dir);
                }

                foreach (var item in Directory.GetFiles(currentRoute))
                {

                    FileItem file = new(this.GetType($"{currentRoute}\\{item}"), item.Replace(currentRoute, ""), DateTime.Now);
                    files.Add(file);
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
