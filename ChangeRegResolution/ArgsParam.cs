using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeRegResolution
{
    class ArgsParam
    {
        //  クラスパラメータ
        public bool MonitorHWCheck { get; set; }
        public string StartsWith { get; set; }
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public bool Runnable { get; set; }
        public string DisplayNum { get; set; }

        //  コンストラクタ
        public ArgsParam() { }
        public ArgsParam(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "/c":
                    case "-c":
                    case "/check":
                    case "-check":
                    case "--check":
                        this.MonitorHWCheck = true;
                        break;
                    case "/s":
                    case "-s":
                    case "/start":
                    case "-start":
                    case "--start":
                        this.StartsWith = args[++i];
                        break;
                    case "/x":
                    case "-x":
                    case "/width":
                    case "-width":
                    case "--width":
                        this.ResolutionX = int.TryParse(args[++i], out int tempX) ? tempX : 0;
                        break;
                    case "/y":
                    case "-y":
                    case "/height":
                    case "-height":
                    case "--height":
                        this.ResolutionY = int.TryParse(args[++i], out int tempY) ? tempY : 0;
                        break;
                    case "/n":
                    case "-n":
                    case "/number":
                    case "-number":
                    case "--number":
                        this.DisplayNum = args[++i];
                        break;

                }
            }
            if (StartsWith != null && ResolutionX > 0 && ResolutionY > 0)
            {
                this.Runnable = true;
            }
        }
    }
}
