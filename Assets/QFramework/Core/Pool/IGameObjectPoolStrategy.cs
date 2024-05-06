﻿using System;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using QFramework;

namespace QFramework
{
    public interface IGameObjectPoolStrategy
    {
        void ProcessContainer(GameObject container);
        void OnAllocate(GameObject result);

        void OnRecycle(GameObject result);
    }

    public class DefaultPoolStrategy : QSingleton<DefaultPoolStrategy>, IGameObjectPoolStrategy
    {
		private DefaultPoolStrategy(){}
		
        public void ProcessContainer(GameObject container)
        {
            container.SetActive(false);
        }

        public void OnAllocate(GameObject result)
        {

        }

        public void OnRecycle(GameObject result)
        {

        }
    }

    public class UIPoolStrategy : QSingleton<UIPoolStrategy>, IGameObjectPoolStrategy
    {
		private UIPoolStrategy() {}

        public void ProcessContainer(GameObject container)
        {
            UITools.SetGameObjectLayer(container, LayerDefine.LAYER_HIDE_UI);
        }

        public void OnAllocate(GameObject result)
        {
            UITools.SetGameObjectLayer(result, LayerDefine.LAYER_UI);
        }

        public void OnRecycle(GameObject result)
        {
            UITools.SetGameObjectLayer(result, LayerDefine.LAYER_HIDE_UI);
        }
    }
}
