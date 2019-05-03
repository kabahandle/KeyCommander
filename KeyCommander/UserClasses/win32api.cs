using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace KCommander.UserClasses
{
    public class win32api
    {
        public const int WM_IME_CHAR = 0x286;    //文字コード送信

        /*
        [System.Runtime.InteropServices.DllImport("winmm.dll",
            CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int mciSendString(string command,
           System.Text.StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        */

        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        public static extern int mciSendString(String command,
           StringBuilder buffer, int bufferSize, IntPtr hwndCallback);



        [DllImport("user32.dll")]
        public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern Int32 SendMessage(Int32 hWnd, Int32 Msg, Int32 wParam,
          ref COPYDATASTRUCT lParam);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern Int32 SendMessage(Int32 hWnd, Int32 Msg,
           Int32 wParam, Int32 lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd,
            ref  RECT lpRect);

        public struct POINT
        {
            public int X;
            public int Y;
        }
        [DllImport("user32.dll")]
        public static extern Boolean GetCursorPos(ref POINT lpPoint);


        public const Int32 WM_COPYDATA = 0x4A;
        public const Int32 WM_USER = 0x400;

        //COPYDATASTRUCT構造体 
        public struct COPYDATASTRUCT
        {
            public Int32 dwData;        //送信する32ビット値
            public Int32 cbData;　　　　//lpDataのバイト数
            public string lpData;　　 //送信するデータへのポインタ(0も可能)
        }

        [DllImport("user32.dll")]
        public static extern int GetFocus();

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern bool GetKeyboardState(byte[] lpKeyState);

        public const int VK_CAPITAL = 0x14;
        public const int VK_KANA = 0x15;
        public const int VK_INSERT = 0x2D;
        public const int VK_NUMLOCK = 0x90;
        public const int VK_SCROLL = 0x91;
        public const int VK_CONTROL = 0x11;
        public const int VK_TAB = 0x09;
        public const int VK_ALT = 0x12;
        public const int VK_LCONTROL = 0xA2;
        public const int VK_ESCAPE = 0x1B;
        public const int VK_SHIFT = 0x10;
    }
}
