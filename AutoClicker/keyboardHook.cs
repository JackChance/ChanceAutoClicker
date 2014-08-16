using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoClicker
{
    class keyboardHook
    {
        public delegate int kbHookProc(int code, int wParam, ref kbHookStruct lParam);

        public struct kbHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        const int WH_KB_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x1011;
        const int WM_SYSYKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

        //Keys to watch for
        public List<Keys> HookedKeys = new List<Keys>();

        IntPtr hhook = IntPtr.Zero;


        public event KeyEventHandler KeyDown;

        public event KeyEventHandler KeyUp;

        public keyboardHook() {
            hook();
        }

        ~keyboardHook(){
            unhook();
        }

        public void hook(){
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KB_LL, hookProc, hInstance, 0);
        }

        public void unhook(){
            UnhookWindowsHookEx(hhook);
        }
        // Check to see if the depressed key was the one in the watch list combined with the CONTROL key. If it is, call the key press even.
        public int hookProc(int code,int wParam, ref kbHookStruct lParam){

            if(code >= 0)

            {
                Keys key = (Keys)lParam.vkCode;
                if(HookedKeys.Contains(key) && Control.ModifierKeys == Keys.Control){
                    KeyEventArgs kea = new KeyEventArgs(key);
                    if((wParam == WM_KEYDOWN|| wParam == WM_SYSYKEYDOWN) && (KeyDown != null))
                    {KeyDown(this, kea);}
                    else if((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                    {
                        KeyUp(this, kea);
                    }
                    if (kea.Handled)
                        return 1;

               }
            }
            return CallNextHookEx(hhook, code, wParam, ref lParam);
        }
        

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, kbHookProc callback, IntPtr hInstance, uint threadID);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref kbHookStruct lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);



    }
}
