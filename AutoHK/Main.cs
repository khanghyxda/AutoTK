using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoHK
{
    public partial class Main : Form
    {
        IntPtr hWin = GetWindow();

        int sizeX = 1286;
        int sizeY = 749;
        int px = -2;
        int py = 0;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGetBlood_Click(object sender, EventArgs e)
        {
            var blood = GetBloodValue(hWin);
            lbBlood.Text = "BLOOD: " + blood;
            Win32.PostMessage(hWin, Win32.WM_KEYDOWN, (int)Keys.F8, 0);
        }

        public static IntPtr GetWindow()
        {
            return Win32.FindWindow("D3D Window", "YGOnline");
        }

        public static string GetBloodValue(IntPtr handle)
        {
            int address = 0x3F64284C;
            string PtrRead = MemoryUtil.ReadInt32(address, 4, handle).ToString();
            return PtrRead;
        }

        private void ControlClick(int x, int y)
        {
            Win32.PostMessage(hWin, Win32.WM_LBUTTONDOWN, 1, CreateLParam(GetPosX(x), GetPosY(y)));
            Win32.PostMessage(hWin, Win32.WM_LBUTTONUP, 0, CreateLParam(GetPosX(x), GetPosY(y)));
        }

        private int GetPosX(int x)
        {
            return x + px;
        }

        private int GetPosY(int y)
        {
            return y + py;
        }

        private int CreateLParam(int x, int y)
        {
            return ((y << 16) | (x & 0xFFFF));
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
	/// Summary description for Win32.
	/// </summary>
	public class Win32
    {
        // The WM_COMMAND message is sent when the user selects a command item from a menu, 
        // when a control sends a notification message to its parent window, or when an 
        // accelerator keystroke is translated.
        public const int WM_COMMAND = 0x111;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x203;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_RBUTTONUP = 0x205;
        public const int WM_RBUTTONDBLCLK = 0x206;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_CLOSE = 0x0010;

        // The FindWindow function retrieves a handle to the top-level window whose class name
        // and window name match the specified strings. This function does not search child windows.
        // This function does not perform a case-sensitive search.
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        // The FindWindowEx function retrieves a handle to a window whose class name 
        // and window name match the specified strings. The function searches child windows, beginning
        // with the one following the specified child window. This function does not perform a case-sensitive search.
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindowEx(int hwndParent, int hwndChildAfter, string strClassName, string strWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        // The SendMessage function sends the specified message to a 
        // window or windows. It calls the window procedure for the specified 
        // window and does not return until the window procedure has processed the message. 
        [DllImport("User32.dll")]
        public static extern Int32 PostMessage(
            IntPtr hWnd,            // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            [MarshalAs(UnmanagedType.LPStr)] string lParam); // second message parameter

        [DllImport("User32.dll")]
        public static extern Int32 PostMessage(
            IntPtr hWnd,            // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            int lParam);            // second message parameter

        public Win32()
        {

        }

    }
}
