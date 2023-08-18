using Newtonsoft.Json;
using ReactiveUI;
using System.Reactive.Disposables;
using ReactiveUI.Winforms;
using ShortcutKeyRecord.Config;
using ShortcutKeyRecord.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortcutKeyRecord
{
    public partial class Form1 : Form, IViewFor<MainVM>
    {
        public Form1()
        {
            InitializeComponent();
            this.WhenActivated(a =>
            {
                this.Bind(ViewModel, vm => vm.CurrentProcessName, v => v.lbl_currentProcess.Text);
                this.Bind(ViewModel, vm => vm.NewSKMap, v => v.tb_SKMap.Text);
                this.Bind(ViewModel, vm => vm.NewSKText, v => v.tb_SKMap.Text);


                this.Bind(ViewModel, vm => vm.ProcessNameList, v => v.cb_SKProcessName.DataSource).DisposeWith(a);

                var selectionChanged = Observable.FromEvent<EventHandler, EventArgs>(
                           h => (_, e) => h(e),
                           ev => cb_SKProcessName.SelectedIndexChanged += ev,
                           ev => cb_SKProcessName.SelectedIndexChanged -= ev);
                this.Bind(ViewModel, vm => vm.NewProcessName, v => v.cb_SKProcessName.SelectedItem, selectionChanged);

                //始终置顶
                this.Bind(ViewModel, vm => vm.FixedTop, v => v.TopMost);
                //a(this.OneWayBind(ViewModel, vm => vm.Id, v => v.label1.Text));
                //a(this.OneWayBind(ViewModel, vm => vm.Name, v => v.label2.Text));
                //a(this.OneWayBind(ViewModel, vm => vm.Age, v => v.label3.Text));
            });
            ViewModel = new MainVM();

            #region 加载用户配置
            string skString = Properties.Settings.Default.KeyMapGroup;
            List<KeyMapGroup> skConfig = (List<KeyMapGroup>)JsonConvert.DeserializeObject(skString, typeof(List<KeyMapGroup>));

            ViewModel.FixedTop = Properties.Settings.Default.FixedTop;
            #endregion

        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainVM)value;
        }

        public MainVM ViewModel { get; set; }


        // 引入user32.dll
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                while (true)
                {
                    IntPtr hWnd = GetForegroundWindow();
                    uint processId;
                    GetWindowThreadProcessId(hWnd, out processId);
                    Process proc = Process.GetProcessById((int)processId);


                    lbl_currentProcess.Invoke((Action)(() =>
                    {
                        if (!ViewModel.ProcessNameList.Contains(proc.ProcessName))
                        {
                            ViewModel.ProcessNameList.Add(proc.ProcessName);
                        }
                        ViewModel.CurrentProcessName = proc.ProcessName;
                        if (!proc.ProcessName.Equals("ShortcutKeyRecord"))
                        {
                            ViewModel.NewProcessName = proc.ProcessName;
                        }
                    }));

                    Thread.Sleep(1000);
                }
            });

        }


        #region 控件数据绑定

        #endregion

        private void btn_addSK_Click(object sender, EventArgs e)
        {

        }

        #region 右键菜单


        private void cms_t_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region 拖动窗口
        Point mouseOffset;
        bool isStartMove = false;

        private void pic_move_MouseDown(object sender, MouseEventArgs e)
        {
            //mouseOffset = new Point(-e.X, -e.Y);
            //isStartMove = true;
            //拖动窗体
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void pic_move_MouseMove(object sender, MouseEventArgs e)
        {
            if (isStartMove)
            {

                //Point mouseSet = Control.MousePosition;
                //mouseSet.Offset(mouseOffset.X, mouseOffset.Y);  //设置移动后的位置
                //Location = mouseSet;

            }

        }
        private void pic_move_MouseUp(object sender, MouseEventArgs e)
        {
            //isStartMove = false;
        }

        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        #endregion

        private void cms_t_fixedTop_CheckedChanged(object sender, EventArgs e)
        {
            ViewModel.FixedTop = cms_t_fixedTop.Checked;
            Properties.Settings.Default.FixedTop = ViewModel.FixedTop;
            Properties.Settings.Default.Save();
        }
    }
}
