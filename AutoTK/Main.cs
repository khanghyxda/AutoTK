using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTK
{
    public partial class Main : Form
    {
        int sizeX = 1031;
        int sizeY = 612;
        int px = 2;
        int py = 32;
        int delay = 3000;
        int delayQuest = 3000;
        int delayFly = 4000;
        bool isRun = false;
        bool isParty = true;
        Point pointThamGia;
        string folderNox = Properties.Settings.Default["FolderNox"].ToString();
        private OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            FileName = "Nox.exe",
            Filter = "Exe Files (.exe)|*.exe",
            Title = "Select Nox.exe"
        };
        List<Point> listPostion = new List<Point> {
            new Point(1, 500, 140),
            new Point(2, 832, 140),
            new Point(3, 500, 225),
            new Point(4, 832, 225),
            new Point(5, 500, 307),
            new Point(6, 832, 307),
            new Point(7, 500, 393),
            new Point(8, 832, 393),
        };

        IntPtr hWin = GetWindow();

        public Main()
        {
            InitializeComponent();
            chbParty.Checked = true;
            chbParty.Enabled = true;
            cbPos.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            listPostion.ForEach(o =>
            {
                cbPos.Items.Add(new ComboboxItem(o.index, "Ô số " + o.index));
            });
            cbPos.DisplayMember = "Text";
            cbPos.ValueMember = "Value";
            cbPos.SelectedIndex = 3;
            lblFolder.Text = folderNox;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            await StartAuto();
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            isRun = false;
            chbParty.Enabled = true;
            cbPos.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private async void btnStartGame_Click(object sender, EventArgs e)
        {
            hWin = GetWindow();
            if (hWin != IntPtr.Zero)
            {
                return;
            }
            try
            {
                Process.Start(folderNox);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy file Nox.exe vui lòng chọn đường dẫn!");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    Process.Start(filePath);
                    Properties.Settings.Default["FolderNox"] = filePath;
                    Properties.Settings.Default.Save();
                    lblFolder.Text = filePath;
                }
            }

            isRun = true;

            await Wait(60000);

            hWin = GetWindow();

            await StartGame();

            await StartAuto();
        }

        private void btnCloseGame_Click(object sender, EventArgs e)
        {
            Win32.PostMessage(GetWindow(), Win32.WM_CLOSE, 0, 0);
            isRun = false;
        }

        private async Task StartAuto()
        {
            hWin = GetWindow();
            if (hWin == IntPtr.Zero)
            {
                MessageBox.Show("Không tìm thấy game!");
                return;
            }
            isRun = true;
            isParty = chbParty.Checked;
            chbParty.Enabled = false;
            cbPos.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            Win32.MoveWindow(hWin, 0, 0, sizeX, sizeY, true);
            ComboboxItem selected = (ComboboxItem)cbPos.SelectedItem;
            pointThamGia = listPostion.Where(o => o.index == selected.Value).First();
            await CreateTeam();
            await RunAuto();
        }

        private async Task RunAuto()
        {
            while (isRun)
            {
                try
                {
                    for (var i = 0; i < 6; i++)
                    {
                        await StartQuest();
                        await CloseBtn();
                    }
                    // Click Nghỉ Một Chút
                    ControlClick(445, 364);
                    await Wait(delay);

                    // Click Hoạt Động
                    ControlClick(743, 29);
                    await Wait(5000);

                    // Click Hoạt Động
                    ControlClick(743, 29);
                    await Wait(5000);

                    // Click Hoạt Động
                    ControlClick(743, 29);
                    await Wait(5000);

                    // Click Close Tống Kim
                    ControlClick(938, 69);
                    await Wait(delay);

                    // Click Close
                    ControlClick(900, 71);
                    await Wait(delay);

                }
                catch
                {
                }
            }
        }

        private async Task StartQuest()
        {
            // Click Hoạt Động
            ControlClick(743, 29);
            await Wait(delay);

            // Click Tham Gia
            ControlClick(pointThamGia.x, pointThamGia.y);
            await Wait(delayQuest);

            // Click Giày Bay
            ControlClick(560, 407);
            await Wait(delayFly);

            // Click Nhận Nhiệm Vụ
            ControlClick(861, 342);
            await Wait(delay);

            if (isParty)
            {
                // Click Xác Nhận
                ControlClick(591, 342);
                await Wait(delay);
            }
        }

        private async Task CloseBtn()
        {
            // Click Hoạt Động
            ControlClick(743, 29);
            await Wait(delay);

            // Click Tham Gia
            ControlClick(pointThamGia.x, pointThamGia.y);
            await Wait(delayQuest);

            // Click Giày Bay
            ControlClick(560, 407);
            await Wait(delayFly);

            // Click Close
            ControlClick(900, 71);
            await Wait(delay);
        }

        private async Task CreateTeam()
        {
            try
            {
                // Click Đội
                ControlClick(10, 189);
                await Wait(1000);

                // Click Đội
                ControlClick(13, 274);
                await Wait(delay);

                // Click Tạo Đội
                ControlClick(115, 217);
                await Wait(delayQuest);

                // Click Close
                ControlClick(486, 493);
                await Wait(delay);

                // Click Close
                ControlClick(900, 71);
                await Wait(delay);
            }
            catch
            {
            }
        }

        private async Task StartGame()
        {
            try
            {
                // Click Game
                ControlClick(159, 168);
                await Wait(80000);

                // Click Close Dialog 1 
                ControlClick(986, 33);
                await Wait(10000);


                // Click Close Dialog 2
                ControlClick(900, 71);
                await Wait(10000);

                // Click Close Dialog 2
                ControlClick(824, 58);
                await Wait(10000);

                // Click Bắt Đầu
                ControlClick(523, 451);
                await Wait(20000);

                // Click Vào Game
                ControlClick(901, 535);
                await Wait(30000);
            }
            catch
            {
            }
        }

        public async Task Wait(int milliseconds)
        {
            if (!isRun)
            {
                throw new Exception();
            }
            await Task.Delay(milliseconds);
        }

        private void ControlClick(int x, int y)
        {
            if (!isRun)
            {
                throw new Exception();
            }
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

        public static IntPtr GetWindow()
        {
            return Win32.FindWindow("Qt5QWindowIcon", "NoxPlayer");
        }
    }

    public class ComboboxItem
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public ComboboxItem(int value, string text)
        {
            Value = value;
            Text = text;
        }
    }

    public class Point
    {
        public int index { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public Point(int index, int x, int y)
        {
            this.index = index;
            this.x = x;
            this.y = y;
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
