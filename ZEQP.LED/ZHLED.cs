using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ZHLED
{
    public class LedAgent
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public  delegate void OnDeviceNotify(uint uDeviceId, IntPtr pNotifiedData, uint uCommand, IntPtr pUserParam);

        [DllImport(@"TriColorSDK.dll", EntryPoint = "GetVersion", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetVersion();

        /// <summary>
        /// 1.初始化
        /// </summary>
        /// <param name="sIp"></param>
        /// <param name="uPort"></param>
        /// <param name="uHeartBeatTimeout"></param>
        /// <param name="sDeviceType"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "Init", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int Init(string sIp = null, uint uPort = 60000, uint uHeartBeatTimeout = 10000, string sDeviceType = "ZH_E5L");

        /// <summary>
        /// 反初始化
        /// </summary>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "DeInit", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int DeInit();

        /// <summary>
        /// 2.添加设备
        /// </summary>
        /// <param name="sIp"></param>
        /// <param name="uPort"></param>
        /// <param name="fNotify"></param>
        /// <param name="pUserParam"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "RegisterDevice", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static uint RegisterDevice(string sIp, uint uPort, OnDeviceNotify fNotify, IntPtr pUserParam);


        /// <summary>
        /// 3.删除设备
        /// </summary>
        /// <param name="uDevId"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "UnregisterDevice", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int UnregisterDevice(uint uDevId);


        /// <summary>
        /// 4.打开屏幕
        /// </summary>
        /// <param name="uDeviceId"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "OpenDevice", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int OpenDevice(uint uDeviceId);


        /// <summary>
        /// 5.关闭屏幕
        /// </summary>
        /// <param name="uDeviceId"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "CloseDevice", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int CloseDevice(uint uDeviceId);


        /// <summary>
        /// 6.设置亮度
        /// </summary>
        /// <param name="uDevId"></param>
        /// <param name="uLightnessValue"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "SetDeviceLightness", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SetDeviceLightness(uint uDevId, uint uLightnessValue);


        /// <summary>
        /// 7.LED显示文本
        /// </summary>
        /// <param name="uDevId"></param>
        /// <param name="uEncodeMode"></param>
        /// <param name="uColor"></param>
        /// <param name="pText"></param>
        /// <param name="uField"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "ShowInstantText", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int ShowInstantText(uint uDevId, uint uEncodeMode, uint uColor, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder pText, uint uField);


        /// <summary>
        /// 8.LED取消显示
        /// </summary>
        /// <param name="uDevId"></param>
        /// <param name="uField"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "HideInstantText", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int HideInstantText(uint uDevId, uint uField);


        /// <summary>
        /// 9.保存字符串内容到指定的索引
        /// </summary>
        /// <param name="uDevId"></param>
        /// <param name="uStringIndex"></param>
        /// <param name="uEncodeMode"></param>
        /// <param name="uColor"></param>
        /// <param name="pText"></param>
        /// <param name="uField"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "UpdateDeviceText", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int UpdateDeviceText(uint uDevId, uint uStringIndex, uint uEncodeMode, uint uColor, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder pText, uint uField);


        /// <summary>
        /// 10.切换内容显示
        /// </summary>
        /// <param name="uDevId"></param>
        /// <param name="StringIndex"></param>
        /// <param name="uField"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "SwitchDeviceText", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SwitchDeviceText(uint uDevId, int StringIndex, uint uField);


        /// <summary>
        /// 11.删除保存在索引中的字符串内容
        /// </summary>
        /// <param name="uDevId"></param>
        /// <param name="uStringIndex"></param>
        /// <param name="uField"></param>
        /// <returns></returns>
        [DllImport("TriColorSDK.dll", EntryPoint = "DeleteDeviceText", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public extern static int DeleteDeviceText(uint uDevId, uint uStringIndex, uint uField);
    }
}
