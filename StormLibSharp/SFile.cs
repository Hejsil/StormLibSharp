using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StormLibSharp
{
    public static class SFile
    {
        [DllImport("Kernel32")]
        public static extern int GetLastError();

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileOpenArchive")]
        public static extern BBool OpenArchive([MarshalAs(UnmanagedType.LPStr)] string fileName, int priority, int flags, out IntPtr handle);

        //SFileCreateArchive Creates a new MPQ archive
        //SFileCreateArchive2 Creates a new MPQ archive.Gives more options than SFileCreateArchive
        //SFileCreateArchiveEx Removed
        //SFileAddListFile Adds another list file to the open archive in order to improve searching
        //SFileSetLocale Changes default locale ID for adding new files
        //SFileGetLocale  Returns current locale ID for adding new files
        //SFileFlushArchive  Flushes all unsaved data to the disk

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileCloseArchive")]
        public static extern BBool CloseArchive(IntPtr archiveHandle);

        //SFileSetMaxFileCount Changes the file limit for the archive
        //SFileSignArchive Signs the archive
        //SFileCompactArchive Compacts(rebuilds) the archive, freeing all gaps that were created by write operations
        //SFileSetCompactCallback

        //SFileOpenPatchArchive Adds a patch archive for an existing open archive
        //SFileIsPatchedArchive Determines if the open MPQ has patches



        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileOpenFileEx")]
        public static extern BBool OpenFileEx(IntPtr archiveHandle, [MarshalAs(UnmanagedType.LPStr)] string fileName, int searchScope, ref IntPtr fileHandle);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileGetFileSize")]
        public static extern int GetFileSize(IntPtr fileHandle, ref int fileSize);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileSetFilePointer")]
        public static extern int SetFilePointer(IntPtr fileHandle, long filePos, ref long filePosHigh, int moveMethod);
        
        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileReadFile")]
        public static extern BBool ReadFile(IntPtr fileHandle, IntPtr buffer, int bytesToRead, ref int bytesRead, IntPtr overlapped);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileCloseFile")]
        public static extern BBool CloseFile(IntPtr fileHandle);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileHasFile")]
        public static extern BBool HasFile(IntPtr fileHandle, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileGetFileName")]
        public static extern BBool GetFileName(IntPtr fileHandle, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileGetFileInfo")]
        public static extern BBool GetFileInfo(IntPtr fileOrArchiveHandle, InfoClass infoClass, IntPtr fileInfo, int fileInfoSize, ref int lengthNeeded);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileVerifyFile")]
        public static extern int VerifyFile(IntPtr archiveHandle, [MarshalAs(UnmanagedType.LPStr)] string fileName, int flags);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileVerifyArchive")]
        public static extern int VerifyArchive(IntPtr archiveHandle);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileExtractFile")]
        public static extern BBool ExtractFile(IntPtr archiveHandle, [MarshalAs(UnmanagedType.LPStr)] string fileName, [MarshalAs(UnmanagedType.LPStr)] string destination, int searchScope);

        
        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileFindFirstFile")]
        public static extern IntPtr FindFirstFile(IntPtr archiveHandle, [MarshalAs(UnmanagedType.LPStr)] string mask, out FileFoundData fileData, [MarshalAs(UnmanagedType.LPStr)] string listFile);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileFindNextFile")]
        public static extern BBool FindNextFile(IntPtr findHandle, out FileFoundData fileData);

        [DllImport("StormLibRAD", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "SFileFindClose")]
        public static extern BBool FindClose(IntPtr findHandle);

        //SListFileFindFirstFile Finds a first line in the listfile that matches the specification
        //SListFileFindNextFile Finds a next line in the listfile that matches the specification
        //SListFileFindClose Stops searching in the listfile
        //SFileEnumLocales

        //SFileCreateFile Creates a new file in MPQ and prepares it for writing data
        //SFileWriteFile Writes data to the file within MPQ
        //SFileFinishFile Finalizes writing file to the MPQ
        //SFileAddFileEx  Adds a file to the archive
        //SFileAddFile Adds a data file to the archive(obsolete)
        //SFileAddWave Adds a WAVE file to the archive(obsolete)
        //SFileRemoveFile Deletes a file from MPQ archive
        //SFileRenameFile Renames a file within MPQ archive
        //SFileSetFileLocale Changes locale of a file in MPQ archive
        //SFileSetDataCompression Sets default compression method for adding a data file using SFileAddFile
        //SFileSetAddFileCallback Sets callback function that is called to inform the calling application about progress of adding file to the archive

        //SCompImplode Compresses a data buffer using IMPLODE method(Pkware Data Compression Library)
        //SCompExplode Decompresses a buffer that has been imploded by SCompImplode
        //SCompCompress Compresses a data buffer using any of the supported MPQ compressions
        //SCompDecompress Decompresses a data buffer that has been compressed by SCompCompress

      [StructLayout(LayoutKind.Sequential), Serializable]
        public struct BBool
        {
            public byte Value { get; }

            public static implicit operator bool(BBool b) => b.Value > 0;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi), Serializable]
        public struct FileFoundData
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string FirstName;
            public IntPtr PlainName;
            public int HashIndex;
            public int BlockIndex;
            public int FileSize;
            public int FileFlags;
            public int CompSize;
            public int FileTimeLow;
            public int FileTimeHigh;
            public int LocalVersion;
        }

        public enum InfoClass
        {
            // Info classes for archives
            MpqFileName,                       // Name of the archive file (TCHAR [])
            MpqStreamBitmap,                   // Array of bits, each bit means availability of one block (BYTE [])
            MpqUserDataOffset,                 // Offset of the user data header (ULONGLONG)
            MpqUserDataHeader,                 // Raw (unfixed) user data header (TMPQUserData)
            MpqUserData,                       // MPQ USer data, without the header (BYTE [])
            MpqHeaderOffset,                   // Offset of the MPQ header (ULONGLONG)
            MpqHeaderSize,                     // Fixed size of the MPQ header
            MpqHeader,                         // Raw (unfixed) archive header (TMPQHeader)
            MpqHetTableOffset,                 // Offset of the HET table, relative to MPQ header (ULONGLONG)
            MpqHetTableSize,                   // Compressed size of the HET table (ULONGLONG)
            MpqHetHeader,                      // HET table header (TMPQHetHeader)
            MpqHetTable,                       // HET table as pointer. Must be freed using FreeFileInfo
            MpqBetTableOffset,                 // Offset of the BET table, relative to MPQ header (ULONGLONG)
            MpqBetTableSize,                   // Compressed size of the BET table (ULONGLONG)
            MpqBetHeader,                      // BET table header, followed by the flags (TMPQBetHeader + DWORD[])
            MpqBetTable,                       // BET table as pointer. Must be freed using FreeFileInfo
            MpqHashTableOffset,                // Hash table offset, relative to MPQ header (ULONGLONG)
            MpqHashTableSize64,                // Compressed size of the hash table (ULONGLONG)
            MpqHashTableSize,                  // Size of the hash table, in entries (DWORD)
            MpqHashTable,                      // Raw (unfixed) hash table (TMPQBlock [])
            MpqBlockTableOffset,               // Block table offset, relative to MPQ header (ULONGLONG)
            MpqBlockTableSize64,               // Compressed size of the block table (ULONGLONG)
            MpqBlockTableSize,                 // Size of the block table, in entries (DWORD)
            MpqBlockTable,                     // Raw (unfixed) block table (TMPQBlock [])
            MpqHiBlockTableOffset,             // Hi-block table offset, relative to MPQ header (ULONGLONG)
            MpqHiBlockTableSize64,             // Compressed size of the hi-block table (ULONGLONG)
            MpqHiBlockTable,                   // The hi-block table (USHORT [])
            MpqSignatures,                     // Signatures present in the MPQ (DWORD)
            MpqStrongSignatureOffset,          // Byte offset of the strong signature, relative to begin of the file (ULONGLONG)
            MpqStrongSignatureSize,            // Size of the strong signature (DWORD)
            MpqStrongSignature,                // The strong signature (BYTE [])
            MpqArchiveSize64,                  // Archive size from the header (ULONGLONG)
            MpqArchiveSize,                    // Archive size from the header (DWORD)
            MpqMaxFileCount,                   // Max number of files in the archive (DWORD)
            MpqFileTableSize,                  // Number of entries in the file table (DWORD)
            MpqSectorSize,                     // Sector size (DWORD)
            MpqNumberOfFiles,                  // Number of files (DWORD)
            MpqRawChunkSize,                   // Size of the raw data chunk for MD5
            MpqStreamFlags,                    // Stream flags (DWORD)
            MpqFlags,                          // Nonzero if the MPQ is read only (DWORD)

            // Info classes for files
            InfoPatchChain,                    // Chain of patches where the file is (TCHAR [])
            InfoFileEntry,                     // The file entry for the file (TFileEntry)
            InfoHashEntry,                     // Hash table entry for the file (TMPQHash)
            InfoHashIndex,                     // Index of the hash table entry (DWORD)
            InfoNameHash1,                     // The first name hash in the hash table (DWORD)
            InfoNameHash2,                     // The second name hash in the hash table (DWORD)
            InfoNameHash3,                     // 64-bit file name hash for the HET/BET tables (ULONGLONG)
            InfoLocale,                        // File locale (DWORD)
            InfoFileIndex,                     // Block index (DWORD)
            InfoByteOffset,                    // File position in the archive (ULONGLONG)
            InfoFileTime,                      // File time (ULONGLONG)
            InfoFileSize,                      // Size of the file (DWORD)
            InfoCompressedSize,                // Compressed file size (DWORD)
            InfoFlags,                         // File flags from (DWORD)
            InfoEncryptionKey,                 // File encryption key
            InfoEncryptionKeyRaw,              // Unfixed value of the file key
            InfoCRC32,                         // CRC32 of the file
        }
    }
}
