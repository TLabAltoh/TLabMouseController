using System;
using System.Runtime.InteropServices;

namespace TLabMouseController.InputHandler
{
    class InputHandler
    {
        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern void mouse_event(
            int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("USER32.dll", CallingConvention = CallingConvention.StdCall)]
        static extern void SetCursorPos(int X, int Y);

        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [Flags]
        public enum MouseEventFlags
        {
            LeftDown    = 0x00000002,
            LeftUp      = 0x00000004,
            MiddleDown  = 0x00000020,
            MiddleUp    = 0x00000040,
            Move        = 0x00000001,
            Absolute    = 0x00008000,
            RightDown   = 0x00000008,
            RightUp     = 0x00000010,
            Wheel       = 0x00000800
        };

        private IntPtr desktopWindow;

        public InputHandler()
        {
            desktopWindow = GetDesktopWindow();
        }

        public void Click(int x, int y, string dir, int amount)
        {
            SetCursorPos(x, y);
            SetForegroundWindow(desktopWindow);
            mouse_event((int)MouseEventFlags.LeftDown, 0, 0, 0, 0);
            if (dir == "None")
            {
                mouse_event((int)MouseEventFlags.Move, 0, 0, 0, 0);
            }
            else if (dir == "Up")
            {
                mouse_event((int)MouseEventFlags.Move, 0, -amount, 0, 0);
            }
            else if (dir == "Down")
            {
                mouse_event((int)MouseEventFlags.Move, 0, amount, 0, 0);
            }
            else if (dir == "Right")
            {
                mouse_event((int)MouseEventFlags.Move, amount, 0, 0, 0);
            }
            else if (dir == "Left")
            {
                mouse_event((int)MouseEventFlags.Move, -amount, 0, 0, 0);
            }
            mouse_event((int)MouseEventFlags.LeftUp, 0, 0, 0, 0);
        }
    }
}
