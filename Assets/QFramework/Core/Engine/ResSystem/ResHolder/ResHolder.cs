﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace QFramework
{
    public class ResHolder : QSingleton<ResHolder>
    {
        protected string[] CommonRes =
        {

        };

        protected EngineUI[] CommonUI =
        {

        };

        protected ResLoader m_Loader;

        public override void OnSingletonInit()
        {
            m_Loader = new ResLoader();
        }

        protected void AddAssistUI2Holder(EngineUI uiid)
        {
            var data = UIDataTable.Get(uiid);
            m_Loader.Add2Load(data.fullPath);
        }
    }
}
