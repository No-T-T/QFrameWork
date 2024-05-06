﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using QFramework;

namespace QFramework
{
    public class FloatMessage : QSingleton<FloatMessage>
    {
		private FloatMessage() {}

        public void ShowMsg(string msg)
        {
            FloatMessagePanel fP = UIMgr.Instance.FindPanel(EngineUI.FloatMessagePanel) as FloatMessagePanel;
            if (fP != null)
            {
                fP.ShowMsg(msg);
                return;
            }

            UIMgr.Instance.OpenPanel(EngineUI.FloatMessagePanel, (panel) =>
            {
                FloatMessagePanel panel1 = panel as FloatMessagePanel;
                panel1.ShowMsg(msg);
            });
        }

        public void ShowLightMsg(string msg)
        {
            FloatMessagePanel fP = UIMgr.Instance.FindPanel(EngineUI.LightMessagePanel) as FloatMessagePanel;
            if (fP != null)
            {
                fP.ShowMsg(msg);
                return;
            }

            UIMgr.Instance.OpenPanel(EngineUI.LightMessagePanel, (panel) =>
            {
                FloatMessagePanel panel1 = panel as FloatMessagePanel;
                panel1.ShowMsg(msg);
            });
        }
    }
}
