using System;
using System.Runtime.InteropServices;

namespace lab4
{
    public static class PerformanceInfo
    {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation,
                                                     [In] int Size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }
        public static long GetSystemCacheInMiB()
        {
            PerformanceInformation performanceInformation = new PerformanceInformation();
            if (GetPerformanceInfo(out performanceInformation, Marshal.SizeOf(performanceInformation)))
            {
                return Convert.ToInt64((performanceInformation.SystemCache.ToInt64() * performanceInformation.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }

        }
        public static long GetKernelTotalInMiB()
        {
            PerformanceInformation performanceInformation = new PerformanceInformation();
            if (GetPerformanceInfo(out performanceInformation, Marshal.SizeOf(performanceInformation)))
            {
                return Convert.ToInt64((performanceInformation.KernelTotal.ToInt64() * performanceInformation.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }

        }
        public static long GetKernelPagedInMiB()
        {
            PerformanceInformation performanceInformation = new PerformanceInformation();
            if (GetPerformanceInfo(out performanceInformation, Marshal.SizeOf(performanceInformation)))
            {
                return Convert.ToInt64((performanceInformation.KernelPaged.ToInt64() * performanceInformation.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }

        }
        public static long GetKernelNonPagedInMiB()
        {
            PerformanceInformation performanceInformation = new PerformanceInformation();
            if (GetPerformanceInfo(out performanceInformation, Marshal.SizeOf(performanceInformation)))
            {
                return Convert.ToInt64((performanceInformation.KernelNonPaged.ToInt64() * performanceInformation.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }

        }
        public static long GetPhysicalAvailableMemoryInMiB()
        {
            PerformanceInformation performanceInformation = new PerformanceInformation();
            if (GetPerformanceInfo(out performanceInformation, Marshal.SizeOf(performanceInformation)))
            {
                return Convert.ToInt64((performanceInformation.PhysicalAvailable.ToInt64() * performanceInformation.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }

        }
        public static long GetTotalMemoryInMiB()
        {
            PerformanceInformation performanceInformation = new PerformanceInformation();
            if (GetPerformanceInfo(out performanceInformation, Marshal.SizeOf(performanceInformation)))
            {
                return Convert.ToInt64((performanceInformation.PhysicalTotal.ToInt64() * performanceInformation.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }
        }
    }
}
