using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Management;

namespace ChangeRegResolution
{
    class Program
    {
        //  静的パラメータ
        const string REG_CONFIGURATION = @"SYSTEM\CurrentControlSet\Control\GraphicsDrivers\Configuration";
        const string PARAM_PrimSurfSize_cx = "PrimSurfSize.cx";
        const string PARAM_PrimSurfSize_cy = "PrimSurfSize.cy";

        static void Main(string[] args)
        {
            //  引数をパラメータに格納
            ArgsParam ap = new ArgsParam(args);
            if (ap.MonitorHWCheck)
            {
                //  モニターのハードウェアIDをチェック
                foreach (ManagementObject mo in new ManagementClass("Win32_PnPEntity").
                    GetInstances().
                    OfType<ManagementObject>().
                    Where(x => x["PNPClass"] != null && x["PNPClass"].ToString() == "Monitor"))
                {
                    foreach (var id in (string[])mo["HardwareID"])
                    {
                        Console.WriteLine(id);
                    }
                }
            }
            else if (ap.Runnable)
            {
                string[] targetKeyNames = null;
                using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(REG_CONFIGURATION))
                {
                    //  先頭一致のキー
                    targetKeyNames = regKey.GetSubKeyNames().
                        Where(x => x.StartsWith(ap.StartsWith, StringComparison.OrdinalIgnoreCase)).
                        ToArray();
                }
                foreach (string targetKeyName in targetKeyNames)
                {
                    //  先頭一致キーの配下のキー
                    using (RegistryKey regKey =
                        Registry.LocalMachine.OpenSubKey(REG_CONFIGURATION + "\\" + targetKeyName))
                    {
                        foreach (string subtargetKeyName in regKey.GetSubKeyNames())
                        {
                            using (RegistryKey regSubKey =
                                Registry.LocalMachine.OpenSubKey(REG_CONFIGURATION + "\\" + targetKeyName + "\\" + subtargetKeyName, true))
                            {
                                bool isChange = false;
                                if (ap.DisplayNum == null || ap.DisplayNum == subtargetKeyName)
                                {
                                    int checkX = (int)regSubKey.GetValue(PARAM_PrimSurfSize_cx, 0);
                                    int checkY = (int)regSubKey.GetValue(PARAM_PrimSurfSize_cy, 0);
                                    if (checkX > 0 && checkY > 0)
                                    {
                                        isChange = true;
                                    }
                                }
                                if (isChange)
                                {
                                    Console.WriteLine(
                                        "[解像度変更] ディスプレイ番号 ({0})\r\n" +
                                        "  - Width  : {1}\r\n" +
                                        "  - Height : {2}", subtargetKeyName, ap.ResolutionX, ap.ResolutionY);
                                    regSubKey.SetValue(PARAM_PrimSurfSize_cx, ap.ResolutionX, RegistryValueKind.DWord);
                                    regSubKey.SetValue(PARAM_PrimSurfSize_cy, ap.ResolutionY, RegistryValueKind.DWord);
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "[解像度変更対象外] ディスプレイ番号 ({0})", subtargetKeyName);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
