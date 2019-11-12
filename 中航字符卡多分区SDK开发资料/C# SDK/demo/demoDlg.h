
// demoDlg.h : 头文件
//

#pragma once
#include "afxcmn.h"
#include "ColorListCtrl.h"

#include "TriColorSDK.h"


// CdemoDlg 对话框
class CdemoDlg : public CDialogEx
{
// 构造
public:
	CdemoDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_DEMO_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持

	static void __cdecl OnDeviceNotify(unsigned int uDeviceId, void* pNotifiedData, unsigned int uCommand, void* pUserParam);

// 实现
protected:
	HICON m_hIcon;
	CColorListCtrl m_lstDevices;

	unsigned int m_uCurrentDeviceID;
	CString		 m_sCurrentDeviceIP;
	CString		 m_sCurrentDevicePort;
	//
	void InitGUI();
	void CalcListCtrlLineNumber(CListCtrl* pCtrl);

	// 生成的消息映射函数
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnBnClickedButtonAdddevice();

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButtonInit();
	afx_msg void OnBnClickedButtonDeinit();
	afx_msg void OnBnClickedButtonShowinstant();
	afx_msg void OnBnClickedButtonHideinstant();
	afx_msg void OnBnClickedButtonUpdatetext();
	afx_msg void OnBnClickedButtonDeltext();
	afx_msg void OnBnClickedButtonPrevtext();
	afx_msg void OnBnClickedButtonNexttext();
	afx_msg void OnBnClickedButtonSwitchtext();
	afx_msg void OnBnClickedButtonDeldevice();
	afx_msg void OnNMClickList1(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnBnClickedButtonOpendevice();
	afx_msg void OnBnClickedButtonClosedevice();
	afx_msg void OnBnClickedButtonLightness();
	afx_msg LRESULT OnDeviceMessage(WPARAM, LPARAM);
};
