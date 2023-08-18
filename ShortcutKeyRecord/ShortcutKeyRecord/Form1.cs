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
                //a(this.OneWayBind(ViewModel, vm => vm.Id, v => v.label1.Text));
                //a(this.OneWayBind(ViewModel, vm => vm.Name, v => v.label2.Text));
                //a(this.OneWayBind(ViewModel, vm => vm.Age, v => v.label3.Text));
            });
            ViewModel = new MainVM();

            //加载用户配置
            string skString = Properties.Settings.Default.KeyMapGroup;
            List<KeyMapGroup> skConfig = (List<KeyMapGroup>)JsonConvert.DeserializeObject(skString, typeof(List<KeyMapGroup>));
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

                    
                    lbl_currentProcess.Invoke((Action)(() => {
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
    }
}
