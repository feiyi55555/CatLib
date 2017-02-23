﻿using UnityEngine;
using System.Collections;
using XLua;

namespace CatLib.API.UpdateSystem
{

    /// <summary>
    /// 自动更新接口
    /// </summary>
    public interface IAutoUpdate
    {

        IEnumerator UpdateAsset();

        int NeedUpdateNum{ get; }

        int UpdateNum{ get;}

    }
}