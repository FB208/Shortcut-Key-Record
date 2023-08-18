using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutKeyRecord.ViewModel
{
    public class MainVM:ReactiveObject
    {
        public MainVM() {
            CurrentProcessName = "当前未捕获进程";
            ProcessNameList = new BindingList<string>
            {
                "ShortcutKeyRecord","QQ"
            };
            NewProcessName = "ShortcutKeyRecord";
        }

        private BindingList<string> _processNameList;
        /// <summary>
        /// 当前活动的进程
        /// </summary>
        public BindingList<string> ProcessNameList
        {
            get => _processNameList;
            set => this.RaiseAndSetIfChanged(ref _processNameList, value);
        }


        private string _currentProcessName;
        /// <summary>
        /// 当前活动的进程
        /// </summary>
        public string CurrentProcessName
        {
            get=> _currentProcessName;
            set=>this.RaiseAndSetIfChanged(ref _currentProcessName, value);
        }

        


        private string _newProcessName;
        /// <summary>
        /// 要添加的线程名
        /// </summary>
        public string NewProcessName
        {
            get => _newProcessName;
            set => this.RaiseAndSetIfChanged(ref _newProcessName, value);
        }


        private string _newSKMap;
        /// <summary>
        /// 要添加的快捷键
        /// </summary>
        public string NewSKMap
        {
            get => _newSKMap;
            set => this.RaiseAndSetIfChanged(ref _newSKMap, value);
        }

        private string _newSKText;
        /// <summary>
        /// 要添加的快捷键说明
        /// </summary>
        public string NewSKText
        {
            get => _newSKText;
            set => this.RaiseAndSetIfChanged(ref _newSKText, value);
        }
    }

}
