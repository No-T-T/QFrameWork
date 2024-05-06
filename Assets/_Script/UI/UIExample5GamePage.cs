﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

public class UIExample5GamePage : QUIBehaviour,IMsgSender
{
	protected override void InitUI(QUIData uiData = null)
	{
		mUIComponents = mIComponents as UIExample5GamePageComponents;
		//please add init code here
	}
	protected override void ProcessMsg (int key,QMsg msg)
	{
		throw new System.NotImplementedException ();
	}
	protected override void RegisterUIEvent()
	{
		mUIComponents.BtnBack_Button.onClick.AddListener (delegate {
			this.SendMsgByChannel(QMgrID.UI,Example5UIMsg.SEND_MSG_TO_EXAMPLE_5_UI_CTRL,
				new object[]{Example5UIMsg.BTN_BACK_CLICK});	
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
		Debug.Log("[ UIExample5GamePage:]" + content);
	}

	UIExample5GamePageComponents mUIComponents = null;
}