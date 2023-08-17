using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutKeyRecord.ViewModel
{
    public class MainVM:ReactiveObject
    {
        public MainVM() {
            CurrentProcessName = "当前未捕获进程";
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
    }

}
