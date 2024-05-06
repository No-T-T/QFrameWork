﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

public class UIExample4AboutPage : QUIBehaviour,IMsgSender
{
	protected override void InitUI(QUIData uiData = null)
	{
		mUIComponents = mIComponents as UIExample4AboutPageComponents;
		//please add init code here
	}
	protected override void ProcessMsg (int key,QMsg msg)
	{
		throw new System.NotImplementedException ();
	}
	protected override void RegisterUIEvent()
	{
		mUIComponents.BtnBack_Button.onClick.AddListener (delegate {
			this.SendMsgByChannel(QMgrID.UI,Example4UIMsg.SEND_MSG_TO_EXAMPLE_4_UI_CTRL,
				new object[] { Example4UIMsg.ABOUT_PAGE_BTN_BACK_CLICK});	
		});
	}
	protected override void OnShow()
	{
		base.OnShow();
	}

	protected override void OnHide()
	{
		base.OnHide();
	}

	void ShowLog(string content)
	{
		Debug.Log("[ UIExample4AboutPage:]" + content);
	}

	UIExample4AboutPageComponents mUIComponents = null;
}