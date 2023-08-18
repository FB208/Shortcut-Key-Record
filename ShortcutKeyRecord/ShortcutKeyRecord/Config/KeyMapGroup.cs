using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutKeyRecord.Config
{

    public class KeyMapGroup
    {
        public string ProcessName { get; set; }
        public Keymap[] KeyMap { get; set; }
    }

    public class Keymap
    {
        public string Map { get; set; }
        public string Text { get; set; }
    }


}
