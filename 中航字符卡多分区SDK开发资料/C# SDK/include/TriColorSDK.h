#ifndef __ZH_TRICOLOR_SDK_H__
#define __ZH_TRICOLOR_SDK_H__

#ifdef TRICOLORSDK_EXPORTS
#define TRICOLORSDK_EXPORT_API __declspec(dllexport)
#else
#define TRICOLORSDK_EXPORT_API __declspec(dllimport)
#endif

#ifdef __cplusplus
extern "C" {
#endif

#define TRICOLORSDK_CALLTYPE __cdecl

//对于设备的操作的回调通知方法定义
//uDeviceID, 设备的ID，逻辑上的ID，跟实际设备没有关系
//pNotifiedData, 通知的具体内容，根据用户不同操作返回的操作不同内容
//uCommand，代表当前操作的类型码
//pUserParam，代表用户数据参数，当注册设备到SDK中绑定的用户参数
typedef void(TRICOLORSDK_CALLTYPE *OnDeviceNotify)(unsigned int uDeviceId, void* pNotifiedData, unsigned int uCommand, void* pUserParam);

namespace ZHSDK_TRICOLOR
{
	enum TEXT_ENCODE_MODE
	{
		TEXT_ENCODE_NONE=-1,
		TEXT_ENCODE_UNICODE=0,
		TEXT_ENCODE_GB2312=1
	};

	enum TEXT_COLOR_TYPE
	{
		TEXT_COLOR_NONE,
		TEXT_COLOR_RED=1,
		TEXT_COLOR_GREEN=2,
		TEXT_COLOR_YELLOW=3,
		TEXT_COLOR_BLUE=4,
		TEXT_COLOR_PURPLE=5,
		TEXT_COLOR_CYAN=6,
		TEXT_COLOR_WHITE=7,
		TEXT_COLOR_MAXVALUE
	};

	enum LIGHTNESS_VALUE
	{
		LIGHTNESS_NONE,
		LIGHTNESS_MINVALUE= 1,
		LIGHTNESS_MAXVALUE= 15
	};

	//获取当前SDK的版本号
	//描述：版本号是由主版本和次版本，以及小版本的四个字节组合而成
	//	   MajorVersion.MinorVersion.SubVersion.ReservedVersion
	//MajorVersion：从24位到32位
	//MinorVersion：从16位到24位
	//SubVersion：  从8位到16位
	unsigned int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE GetVersion();

	//初始化
	//描述：初始化当前工作环境
	//参数：sIp 本地工作采用的IP地址，格式为xxx.xxx.xxx.xxx
	//	   uPort 本地工作模式时采用的Port
	//	   uHeartBeatTimeout 本地工作模式时的心跳间隔 ms
	//	   sDeviceType 本地工作模式时过滤的设备类型
	
	//[****特别注意****]
	//该函数必须在所有方法调用之前调用
	//当前版本的Init方法所有参数都无效。
	//当前版本对IP地址和端口，不做合法性校验，外部调用来保证其有效性
	
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE Init(const char* sIp = NULL,
									unsigned short uPort=60000, 
									unsigned int uHeartBeatTimeout=10000, 
									const char* sDeviceType="ZH_E8L");
	//添加设备到设备列表
	//描述：添加一台设备信息到设备列表，用于更新该设备的信息，与实际设备的连接, 并跟踪该设备的状态
	//参数：sIp 设备的IP地址 格式为xxx.xxx.xxx.xxx
	//	   uPort 设备的Port号
	//     OnDeviceNotify 接收设备状态变化的回调函数
	//	   pUserParam 回调函数时，用户自定义参数
	//返回值： 设备逻辑ID号，0为失败，非零为成功
	//注意：操作设备的结果，
	//     当前采用异步通知方式，操作结果都是通过回调函数来通知调用者
	//[****特别注意****]
	//当前版本的Init方法所有参数都无效。
	//当前版本对IP地址和端口，不做合法性校验，外部调用来保证其有效性
	unsigned int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE RegisterDevice(const char* sIp,
												       unsigned int uPort, 
													   OnDeviceNotify fNotify=NULL, 
													   void* pUserParam=NULL);
	//删除从设备列表中删除一台设备，断开与实际设备的连接
	//参数: uDevId 设备ID号
	//返回值：1：成功
	//       0: 失败
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE UnregisterDevice(unsigned int uDevId);

	//点亮一台设备，
	//实际点亮成功，
	//参数: uDevId 设备ID号
	//返回值：1：成功
	//       0: 失败
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE OpenDevice(unsigned int uDevId);

	//熄灭一台设备，
	//实际点亮成功，根据设备注册方式确定 
	//参数: uDevId 设备ID号
	//返回值：1：成功
	//       0: 失败
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE CloseDevice(unsigned int uDevId);

	//熄灭一台设备，
	//实际点亮成功，根据设备注册方式确定 
	//参数: uDevId 设备ID号
	//	    uLightnessValue 亮度值, 
	//		取值范围为[LIGHTNESS_MINVALUE, LIGHTNESS_MAXVALUE]，并根据实际设备具体情况而定
	//返回值：1：成功
	//       0: 失败
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE SetDeviceLightness(unsigned int uDevId,
												  unsigned int uLightnessValue);

	//显示指定设备的即显文字内容
	//参数: uDevId 设备ID号
	//	    uEncodeMode 采用的编码方式
	//		现在支持两种编码方式：[TEXT_ENCODE_UNICODE, TEXT_ENCODE_GB2312],具体要跟硬件的支持能力来定
	//	    uColor 文本信息采用的颜色 取值范围为[TEXT_COLOR_TYPE], 并结合实际设备支持情况而定
	//		pText 需要显示的文本内容，采用unicode编码格式
	//      uField 字符所在分区，范围为[0, 65535]
	//返回值：1：成功
	//       0: 失败
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE ShowInstantText(unsigned int  uDevId,
												unsigned int  uEncodeMode,
												unsigned int  uColor, 
												const wchar_t * pText,
												unsigned int uField = 0);
	//删除指定设备的即显文字内容
	//参数: uDevId 设备ID号
	//返回值：1：成功
	//       0: 失败
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE HideInstantText(unsigned int  uDevId,
											   unsigned int uField = 0);

	//更新指定设备的指定索引的文字内容
	//参数: uDevId 设备ID号
	//      uStringIndex 用于存储在设备中逻辑序列号,并根据实际设备支持的最大范围而定
	//	    uEncodeMode 采用的编码方式
	//		现在支持两种编码方式：[TEXT_ENCODE_UNICODE, TEXT_ENCODE_GB2312],具体要跟硬件的支持能力来定
	//	    uColor 文本信息采用的颜色 取值范围为[TEXT_COLOR_TYPE], 并结合实际设备支持情况而定
	//		pText 需要显示的文本内容，采用unicode编码格式
	//返回值：1：成功
	//       0: 失败
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE UpdateDeviceText(unsigned int  uDevId,
												unsigned int  uStringIndex,
												unsigned int  uEncodeMode,
												unsigned int  uColor,
												const wchar_t* pText,
												unsigned int uField = 0);
	//切换到指定设备的指定索引的文字并显示
	//参数: uDevId 设备ID号
	//      uStringIndex 用于存储在设备中逻辑序列号,并根据实际设备支持的最大范围而定
	//      uField 字符所在分区，范围为[0, 65535]
	//返回值：1：成功
	//       0: 失败
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE SwitchDeviceText(unsigned int uDevId,
												int StringIndex,
												unsigned int uField = 0);

	//删除指定设备中的指定索引的文字
	//参数: uDevId 设备ID号
	//      uStringIndex 用于存储在设备中逻辑序列号,并根据实际设备支持的最大范围而定
	//      uField 字符所在分区，范围为[0, 65535]
	//返回值：1：成功
	//       0: 失败
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE DeleteDeviceText(unsigned int uDevId,
												unsigned int uStringIndex,
												unsigned int uField = 0);
	//反初始化
	//描述：释放所有当前使用的系统资源
	//该方法调用之后，所有方法的调用都将失败[Init除外]
	//返回值：1：成功
	//       0: 失败
	int TRICOLORSDK_EXPORT_API TRICOLORSDK_CALLTYPE DeInit();
}

#ifdef __cplusplus
}
#endif

#endif