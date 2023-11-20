using Microsoft.VisualBasic.FileIO;

namespace EchoUtility
{
    public enum FileType
    {
        directory,
        file,
        zip,
        exe,
        txt,
        msi,
        apk,
        rar,
        sql,
        psd,
        pdf,
        png,
        jpg,
        mp4
    }

    public class FileItem
    {
        public FileType Type { get; set; }
        public string Name { get; set; }
        public DateTime Last_update { get; set; }

        public FileItem(FileType type, string name, DateTime last_update)
        {
            this.Type = type;
            this.Name = name;
            this.Last_update = last_update;
        }
    };
}