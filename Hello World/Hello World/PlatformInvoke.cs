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
        
    
    }
}