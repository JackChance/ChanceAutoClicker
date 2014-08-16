using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace AutoClicker
{
    public partial class ghostForm : Form
    {
        keyboardHook myHook = new keyboardHook();
        volatile static bool doClicking = false;
        Thread clickThread = new Thread(clickCaller);
        public static ManualResetEvent _pauseClick = new ManualResetEvent(true);
        public static ManualResetEvent _closeThread = new ManualResetEvent(false);
        public static int clicks = 25;
        public ghostForm()
        {
            InitializeComponent();
        }

        public TextBox PassTextBox()
        {
            return clickstxb;
        }
        private void ghostForm_Load(object sender, EventArgs e)
        {
            
            myHook.HookedKeys.Add(Keys.F1);
            myHook.KeyDown += new KeyEventHandler(myHook_KeyDown);
            Begin();
            Pause();
        }

        void myHook_KeyDown(object sender, KeyEventArgs e)
        {
             
                if (!doClicking)
                {
                    doClicking = true;
                    clickstxb.Enabled = false;
                    clicks = int.Parse(clickstxb.Text);
                    Resume();
                }
                else if(doClicking)
                {
                    doClicking = false;
                    clickstxb.Enabled = true;
                    Pause();
                }
            
            e.Handled = true;
        }
        /// <summary>
        /// Used to start the background thread, do once at the beginning of the program.
        /// </summary>
        public void Begin()
        {
            clickThread = new Thread(clickCaller);
            clickThread.Start();
        }
        /// <summary>
        /// used to pause the background thread. Do when its loop needs to be halted.
        /// </summary>
        public void Pause()
        {
            _pauseClick.Reset();
        }
        /// <summary>
        /// Used to resume the background thread. Do when its loop needs to be restarted.
        /// </summary>
        public void Resume()
        {
            _pauseClick.Set();
        }
        /// <summary>
        /// Used to clean up the background thread. Use before the program ends to avoid instability.
        /// </summary>
        public void Exit()
        {
            _closeThread.Set();
            _pauseClick.Set();
            clickThread.Join();
        }
        static void clickCaller()
        {
                while (true)
                {
                    _pauseClick.WaitOne(Timeout.Infinite);
                    if (_closeThread.WaitOne(0))
                    {
                        break;
                    }
                    while (doClicking)
                    {
                        System.Threading.Thread.Sleep(1000 / clicks);
                        ClickOnPoint();
                    }
                }
        }

        static private void ClickOnPoint()
        {
            uint mousex = (uint)Cursor.Position.X;
            uint mousey = (uint)Cursor.Position.Y;
            mouse_event(0x00000002, mousex, mousey, 0, UIntPtr.Zero);
            mouse_event(0x00000004, mousex, mousey, 0, UIntPtr.Zero);
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr ExtraInfo);

        private void ghostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit();
        }

    }
}
