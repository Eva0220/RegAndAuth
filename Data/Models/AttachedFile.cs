using Microsoft.EntityFrameworkCore;

namespace InformBez.Data.Models
{
    public class AttachedFile : Entity<int>
    {
        public string FullPath { get; set; } = null!;
        public DateTime CreationTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public string Hash { get; set; }

        public AttachedFile(FileInfo fileInfo)
        {
            CreationTime = fileInfo.CreationTime;
            LastWriteTime = fileInfo.LastAccessTime;
            FullPath = fileInfo.FullName;
        }

        public AttachedFile() { }
    }
}
