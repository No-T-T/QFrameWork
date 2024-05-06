﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ToDoList {

	public class UIEditPanelData {
		
		public string Title;

		public string Content;
	
	}

	public enum ToDoListEvent {
		Began = (ushort)QMgrID.Data,
		ModifiedItem,
		CreateNewItem,
		DeleteItem,
		End
	}

	public class CreateNewItemMsg :QMsg {
		public ToDoListItemData NewItemData;
		public CreateNewItemMsg(ushort msgId,ToDoListItemData newItemData):base(msgId) {
			this.NewItemData = newItemData;
		}
	}

	public class ModifiedItemMsg : QMsg {
		public string SrcTitle;
		public ToDoListItemData ItemData;
		public ModifiedItemMsg(ushort msgId,string srcTitle,ToDoListItemData itemData):base(msgId) {
			this.SrcTitle = srcTitle;
			this.ItemData = itemData;
		}
	}

	public class DeleteItemMsg : QMsg {
		public string Title;
		public DeleteItemMsg(ushort msgId,string title):base(msgId) {
			this.Title = title;
		}
	}

	public class ToDoListManager : QMgrBehaviour,ISingleton {

		Dictionary<string,ToDoListItemData> m_CachedData = new Dictionary<string, ToDoListItemData> ();

		public Dictionary<string,ToDoListItemData> CurCachedData {
			get {
				return m_CachedData;
			}
		}

		protected override void SetupMgrId ()
		{
			mMgrId = (ushort)QMgrID.Data;
		}
			
		protected override void ProcessMsg (int key,QMsg msg)
		{
			switch (msg.msgId) {
				case (ushort)ToDoListEvent.ModifiedItem:
					ModifiedItemMsg modifiedMsg = msg as ModifiedItemMsg;
					m_CachedData.Remove (modifiedMsg.SrcTitle);
					modifiedMsg.ItemData.Description ();
					m_CachedData.Add (modifiedMsg.ItemData.Id, modifiedMsg.ItemData);
					NetManager.Instance.ModifiedItemUpload (modifiedMsg.ItemData.Id, modifiedMsg.ItemData);
					this.SendMsg (new QMsg ((ushort)UIEvent.UpdateView));
					break;
				case (ushort)ToDoListEvent.CreateNewItem:
					CreateNewItemMsg newItemMsg = msg as CreateNewItemMsg;
					newItemMsg.NewItemData.Description ();
					m_CachedData.Add (newItemMsg.NewItemData.Id,newItemMsg.NewItemData);
					NetManager.Instance.NewItemUpload (newItemMsg.NewItemData);
					this.SendMsg (new QMsg ((ushort)UIEvent.UpdateView));
					break;
				case (ushort)ToDoListEvent.DeleteItem:
					DeleteItemMsg deleteItemMsg = msg as DeleteItemMsg;
					m_CachedData.Remove (deleteItemMsg.Title);
					NetManager.Instance.DeleteItemUpload (deleteItemMsg.Title);
					this.SendMsg (new QMsg ((ushort)UIEvent.UpdateView));
					break;
			}
		}


		public static ToDoListManager Instance {
			get {
				return QMonoSingletonProperty<ToDoListManager>.Instance;
			}
		}

		public void OnSingletonInit()
		{

		}

		private ToDoListManager() {

		}

		void Awake() {
			Debug.Log ("ToDoList Manager Awake");

			LoadData ();

			RegisterSelf (new ushort[] {
				(ushort)ToDoListEvent.CreateNewItem,
				(ushort)ToDoListEvent.ModifiedItem,
				(ushort)ToDoListEvent.DeleteItem
			});

			NetManager.Instance.Query (delegate(List<ToDoListItemData> obj) {
				SaveManager.Save(obj);
				LoadData();
				this.SendMsg(new QMsg((ushort)UIEvent.UpdateView));
			});
		}

		void LoadData() {
			Debug.Log ("---- LoadData ----");
			var list = SaveManager.Load ();

			m_CachedData.Clear ();
			foreach (var itemData in list) {
				if (m_CachedData.ContainsKey (itemData.Id)) {
					m_CachedData.Add (itemData.Id, itemData);
					Debug.Log (itemData.Id);
				}
				else {
					m_CachedData[itemData.Id] = itemData;

					Debug.LogWarning (itemData.Id + ": Exists");
				}
			}
			Debug.Log ("-------------------");
		}


		public void UpdateData(ToDoListItemData itemData) {
			m_CachedData [itemData.Id] = itemData;
		}

		void OnDestroy() {
			SaveManager.Save (new List<ToDoListItemData>(m_CachedData.Values));
		}

		void OnApplicationQuit() {
			SaveManager.Save (new List<ToDoListItemData>(m_CachedData.Values));
		}

		void OnApplicationPause(bool pause) {

			if(pause) {
				SaveManager.Save (new List<ToDoListItemData>(m_CachedData.Values));
			}
		}

		void OnApplicationFocus(bool focus) {
			if (!focus) {
				SaveManager.Save (new List<ToDoListItemData>(m_CachedData.Values));
			}
		}
	}

}