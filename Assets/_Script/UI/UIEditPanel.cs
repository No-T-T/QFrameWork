﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using ToDoList;



public class UIEditPanelData : QUIData{
	public bool isNew; // true 新建 false 修改
	public ToDoListItemData ToDoListItemData;
}

public class UIEditPanel : QUIBehaviour
{
	UIEditPanelData m_EditPanelData;

	protected override void InitUI(QUIData uiData = null)
	{
		mUIComponents = mIComponents as UIEditPanelComponents;
		//please add init code here

		m_EditPanelData = uiData as UIEditPanelData;

		UpdateView ();
	}

	protected override void ProcessMsg (int key,QMsg msg)
	{
		throw new System.NotImplementedException ();
	}

	protected override void RegisterUIEvent()
	{
		mUIComponents.BtnCancel_Button.onClick.AddListener (delegate {
			CloseSelf();	
		});

		mUIComponents.BtnSave_Button.onClick.AddListener (delegate {
			string content = mUIComponents.ContentInputField_InputField.text;

			string id = System.DateTime.Now.Year + "." 
					+ System.DateTime.Now.Month + "." 
					+ System.DateTime.Now.Day + "." 
					+ System.DateTime.Now.Hour + "." 
					+ System.DateTime.Now.Minute + "."  
					+ System.DateTime.Now.Second + "." 
					+ System.DateTime.Now.Millisecond; 

			if (m_EditPanelData.isNew) {
				var newItemData = new ToDoListItemData();
				newItemData.Id = id;
				newItemData.Content = content;
				newItemData.Description();
				this.SendMsg(new CreateNewItemMsg((ushort)UIToDoListPageEvent.CreateNewItem,newItemData));
			} else {
				var itemData = new ToDoListItemData();
				itemData.Id = id;
				itemData.Content = content;
				itemData.Description();
				this.SendMsg(new ModifiedItemMsg((ushort)UIToDoListPageEvent.ModifiedItem,m_EditPanelData.ToDoListItemData.Id,itemData));
			}
			CloseSelf();
		});
		
	}

	void UpdateView() {
		if (!m_EditPanelData.isNew) {
			mUIComponents.ContentInputField_InputField.text = m_EditPanelData.ToDoListItemData.Content;
		}
	}

	protected override void OnShow()
	{
		base.OnShow();
	}

	protected override void OnHide()
	{
		base.OnHide();
	}

	protected override void OnClose()
	{
		base.OnClose();
	}

	void ShowLog(string content)
	{
		Debug.Log("[ UIEditPanel:]" + content);
	}

	UIEditPanelComponents mUIComponents = null;
}