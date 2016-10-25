using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StormLibSharp
{
    public class FileFound
    {
        private SFile.FileFoundData _inner;

        public string FirstName => _inner.FirstName;
        public string PlainName => Marshal.PtrToStringAnsi(_inner.PlainName);
        public int HashIndex => _inner.HashIndex;
        public int BlockIndex => _inner.BlockIndex;
        public int FileSize => _inner.FileSize;
        public int FileFlags => _inner.FileFlags;
        public int CompSize => _inner.CompSize;
        public int FileTimeLow => _inner.FileTimeLow;
        public int FileTimeHigh => _inner.FileTimeHigh;
        public int LocalVersion => _inner.LocalVersion;

        internal FileFound(SFile.FileFoundData inner)
        {
            _inner = inner;
        }
    }
}
