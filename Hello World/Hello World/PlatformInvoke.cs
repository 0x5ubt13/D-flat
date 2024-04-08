using System.Runtime.InteropServices;

public class PlatformInvoke
{
    public static void Main(string[] args)
    {
        // Platform Invoke, often shortened to P/Invoke, allows you to access functions in unmanaged C libraries from your managed C# code.
        // The most common use case (particularly in the offensive security world) is to access the native Windows APIs (although since .NET is cross-platform it can be used with any C library).
        // These functions are declared with the extern keywork and DllImport attribute.  
        // The following example shows how to import the OpenProcess API from kernel32.dll.
        // We simply define the function signature (i.e. the function name, any input parameters, and the return type).  
        [DllImport("kernel32", SetLastError = true)]
        static extern nint OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        // In most cases, you will also want to set SetLastError to true, as this allows you to retrieve the error code should the API call fail, with Marhsal.GetLastWin32Error.
        var hProcess = OpenProcess(0xF01FF, false, 26768);

        if (hProcess == nint.Zero)
            Console.WriteLine("OpenProcess failed: {0}", Marshal.GetLastWin32Error());
        else
            Console.WriteLine("hProcess: 0x{0}", hProcess);

        // Marshalling
        // Some Windows APIs such as LoadLibraryW require an LPCWSTR, which is a pointer to a null-terminated 16-bit unicode string.
        // P/Invoke can automatically marshal between managed and unmanaged datatypes using the MarshalAs attribute, so we don't have to do it manually.
        // [DllImport("kernel32", SetLastError = true)]
        static extern nint LoadLibraryW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpLibFileName);
        
        var hProcess2 = LoadLibraryW("amsi.dll");

        // Enums
        // Enums can be used in conjunction with APIs that have pre-determined values for their parameters.  
        // For instance, OpenProcess requires a set of ProcessAccessRights which are defined [here](https://learn.microsoft.com/en-us/windows/win32/procthread/process-security-and-access-rights).  
        // Instead of remembering values, we can define then in an enum - as long as the underlying datatype matches (in this case, uint), it will work.
        // The '[Flags]' attribute on the enum tells C# that the values can be treated as a bit field (i.e. you can perform bitwise operations on them).  In the particular case of this API, it allows you to build up a desired access value of the exact privileges that you want the final handle to have.
        static extern nint OpenProcess(ProcessAccessRights dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        var hProcess3 = OpenProcess(
            ProcessAccessRights.PROCESS_VM_READ | ProcessAccessRights.PROCESS_VM_WRITE, 
            false, 26768);

        [Flags]
        internal enum ProcessAccessRights : uint
        {
            // many missing for brevity
            PROCESS_VM_READ = 0X0010,
            PROCESS_VM_WRITE = 0X0020,
            PROCESS_VM_OPERATION = 0X0008
        }
    }
}