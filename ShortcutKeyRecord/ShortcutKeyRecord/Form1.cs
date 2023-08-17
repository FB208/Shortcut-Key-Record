using ReactiveUI;
using ShortcutKeyRecord.ViewModel;
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

namespace ShortcutKeyRecord
{
    public partial class Form1 : Form, IViewFor<MainVM>
    {
        public Form1()
        {
            InitializeComponent();
            this.WhenActivated(a =>
            {
                a(this.Bind(ViewModel, vm => vm.CurrentProcessName, v => v.lbl_currentProcess.Text));
                //a(this.Bind(ViewModel, vm => vm.Id, v => v.textBox1.Text));
                //a(this.Bind(ViewModel, vm => vm.Name, v => v.textBox2.Text));
                //a(this.Bind(ViewModel, vm => vm.Age, v => v.textBox3.Text));
                //a(this.OneWayBind(ViewModel, vm => vm.Id, v => v.label1.Text));
                //a(this.OneWayBind(ViewModel, vm => vm.Name, v => v.label2.Text));
                //a(this.OneWayBind(ViewModel, vm => vm.Age, v => v.label3.Text));
            });
            ViewModel = new MainVM();
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
                        ViewModel.CurrentProcessName = proc.ProcessName;
                    }));
                    
                    Thread.Sleep(1000);
                }
            });
            
        }
    }
}
