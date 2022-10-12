using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UI.PlayerHP
{
    public class HPAmountModel : MonoBehaviour
    {
        /// <summary>
        /// 現在のHPの値を初期化する
        /// </summary>
        public Action<int> DrawInitCurrentHP;

        /// <summary>
        /// 最大体力の値を初期化する
        /// </summary>
        public Action<int> DrawInitMaxHP;


        /// <summary>
        /// 現在の体力を変更する
        /// </summary>
        public Action<int> DrawCurrentHP;

        /// <summary>
        /// 最大体力を変更する
        /// </summary>
        public Action<int> DrawMaxHP;
    }
}

