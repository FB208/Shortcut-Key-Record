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
using System.Configuration;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ShortcutKeyRecord
{
    public partial class Form1 : Form, IViewFor<MainVM>
    {
        List<KeyMapGroup> skConfig;
        public Form1()
        {
            InitializeComponent();
            this.WhenActivated(a =>
            {
                this.Bind(ViewModel, vm => vm.CurrentProcessName, v => v.lbl_currentProcess.Text);
                this.Bind(ViewModel, vm => vm.CurrentProcessName, v => v.gb_currentProcess.Text);
                this.Bind(ViewModel, vm => vm.NewSKMap, v => v.tb_SKMap.Text);
                this.Bind(ViewModel, vm => vm.NewSKText, v => v.tb_SKText.Text);


                this.Bind(ViewModel, vm => vm.ProcessNameList, v => v.cb_SKProcessName.DataSource).DisposeWith(a);

                var selectionChanged = Observable.FromEvent<EventHandler, EventArgs>(
                           h => (_, e) => h(e),
                           ev => cb_SKProcessName.SelectedIndexChanged += ev,
                           ev => cb_SKProcessName.SelectedIndexChanged -= ev);
                this.Bind(ViewModel, vm => vm.NewProcessName, v => v.cb_SKProcessName.SelectedItem, selectionChanged);

                //始终置顶
                this.Bind(ViewModel, vm => vm.FixedTop, v => v.cms_t_fixedTop.Checked);
                //a(this.OneWayBind(ViewModel, vm => vm.Id, v => v.label1.Text));
                //a(this.OneWayBind(ViewModel, vm => vm.Name, v => v.label2.Text));
                //a(this.OneWayBind(ViewModel, vm => vm.Age, v => v.label3.Text));
            });
            ViewModel = new MainVM();


            LoadUserSetting();
            //#region 样式
            //foreach (Control ctrl in this.Controls)
            //{
            //    ctrl.BackColor = Color.Red;
            //}
            //#endregion
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


                    gb_currentProcess.Invoke((Action)(() =>
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

        /// <summary>
        /// 重新加载用户配置
        /// </summary>
        private void LoadUserSetting()
        {
            string skString = Properties.Settings.Default.KeyMapGroup;
            skConfig = (List<KeyMapGroup>)JsonConvert.DeserializeObject(skString, typeof(List<KeyMapGroup>));

            ViewModel.FixedTop = Properties.Settings.Default.FixedTop;

            this.BindAllKeymap();
        }

        #region 控件数据绑定
        private void BindAllKeymap()
        {
            this.p_allProcess.Controls.Clear();
            int row = 0;
            foreach (var sk in skConfig)
            {
                string name = sk.ProcessName;
                foreach (var km in sk.KeyMap)
                {
                    string skMap = km.Map;
                    string skText = km.Text;
                    Label lbl_Map = new Label() { Text=skMap,Size=new Size(150,20),Location=new Point(10,10+30*row) };
                    Label lbl_Text = new Label() { Text = skText, Size = new Size(150, 20), Location = new Point(160, 10 + 30 * row) };
                    Label lbl_Name = new Label() { Text = name, Size = new Size(150, 20), Location = new Point(320, 10 + 30 * row) };
                    this.p_allProcess.Controls.Add(lbl_Map);
                    this.p_allProcess.Controls.Add(lbl_Text);
                    this.p_allProcess.Controls.Add(lbl_Name);
                    row++;
                }
                
            }        
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addSK_Click(object sender, EventArgs e)
        {
            KeyMapGroup keyMapGroup = new KeyMapGroup();
            keyMapGroup.ProcessName = ViewModel.NewProcessName;
            List<Keymap> keymaps = new List<Keymap>();
            Keymap keymap = new Keymap();
            keymap.Map = ViewModel.NewSKMap;
            keymap.Text = ViewModel.NewSKText;
            keymaps.Add(keymap);
            keyMapGroup.KeyMap = keymaps;
            
            //更新并保存配置
            skConfig.Add(keyMapGroup);
            this.BindAllKeymap();
            string skString = JsonConvert.SerializeObject(skConfig);
            Properties.Settings.Default.KeyMapGroup = skString;
            Properties.Settings.Default.Save();
        }

        #region 右键菜单
        /// <summary>
        /// 切换是否置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_t_fixedTop_CheckedChanged(object sender, EventArgs e)
        {
            ViewModel.FixedTop = cms_t_fixedTop.Checked;
            Properties.Settings.Default.FixedTop = ViewModel.FixedTop;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// 关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_t_close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// 导出用户配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_t_config_export_Click(object sender, EventArgs e)
        {
            string exportPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                exportPath = dialog.SelectedPath + "/ShortcutKeyRecord.config.json";
            }
            // 获取用户配置
            List<ExportModel> exportModels = new List<ExportModel>();
            ExportModel exportModel = null;
            foreach (System.Configuration.SettingsPropertyValue item in Properties.Settings.Default.PropertyValues)
            {
                exportModel = new ExportModel();
                exportModel.Key = item.Name;
                exportModel.Value = item.PropertyValue.ToString();
                exportModels.Add(exportModel);
            }
            string json = JsonConvert.SerializeObject(exportModels, Formatting.Indented);


            // 保存配置到文件
            File.WriteAllText(exportPath, json);
            MessageBox.Show("导出成功");
        }

        /// <summary>
        /// 导入用户配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_t_config_input_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Config|*.config.json";
            string inputPath="";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                inputPath = dialog.FileName;
            }
            StreamReader reader = new StreamReader(inputPath);
            string json = reader.ReadToEnd();
            reader.Close();
            List<ExportModel> exportModels = JsonConvert.DeserializeObject<List<ExportModel>>(json);
            foreach (ExportModel exportModel in exportModels)
            {
                Properties.Settings.Default[exportModel.Key]= Convert.ChangeType(exportModel.Value, Properties.Settings.Default[exportModel.Key].GetType());
            }
            Properties.Settings.Default.Save();
            this.LoadUserSetting();
            MessageBox.Show("导入成功");
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

      
    }
}
