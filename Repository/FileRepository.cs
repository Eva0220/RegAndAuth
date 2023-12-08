using InformBez.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformBez.Repository
{
    public class FileRepository
    {
        public async Task<bool> GetFileStatus (DateTime time, string filename)
        {
            using ApplicationContext context = new();
            return await context.Files.AnyAsync(t => t.ModificatedTime == time && t.Name == filename);

        }
    }
}
