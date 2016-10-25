using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StormLibSharp
{
    public class Archive : IDisposable
    {
        private readonly IntPtr _handle;

        private Archive(IntPtr handle)
        {
            _handle = handle;
        }

        public static Archive Open(string fileName, int priority, int flags)
        {
            IntPtr handle;
            var error = SFile.OpenArchive(fileName, priority, flags, out handle);

            if (error.Bool)
                throw new NotImplementedException();

            return new Archive(handle);
        }

        public FileFound[] GetFiles(string mask = "*")
        {
            var res = new List<FileFound>();
            SFile.FileFoundData fileFoundData;
            var findHandle = SFile.FindFirstFile(_handle, mask, out fileFoundData, null);

            if (findHandle == null)
                throw new NotImplementedException();

            do
            {
                res.Add(new FileFound(fileFoundData));
            } while (SFile.FindNextFile(findHandle, out fileFoundData).Bool);

            if (SFile.FindClose(findHandle).Bool)
                throw new NotImplementedException();

            return res.ToArray();
        }

        public void Dispose()
        {
            var error = SFile.CloseArchive(_handle);

            if (error.Bool)
                throw new NotImplementedException();
        }
    }
}
