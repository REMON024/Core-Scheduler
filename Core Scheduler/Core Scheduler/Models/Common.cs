using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Scheduler.Models
{
    public static class Common
    {
        public static void Logs(string message,string filename)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MyLogs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            path = Path.Combine(path, filename);
            using FileStream fileStream = new FileStream(path, FileMode.Create);
            using TextWriter textWriter= new StreamWriter(fileStream);

            textWriter.WriteLine(message);

        }
    }
}
