﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using SCFramework;

namespace PTGame.PaiLogic
{
    public class LoadTableNode : ExecuteNode
    {
//        private TableModule m_TableModule;

        public override void OnBegin()
        {
            Log.i("ExecuteNode:" + GetType().Name);
//            m_TableModule = GameMgr.S.AddCom<TableModule>();
        }

        public override void OnExecute()
        {
//            isFinish = m_TableModule.isTableLoadFinish;
        }
    }
}
