using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UI.PlayerHP
{
    public class HPBarModel : MonoBehaviour
    {
        /// <summary>
        /// HPバーの割合を初期化する
        /// </summary>
        public Action<float> DrawInitHPBar;

        /// <summary>
        /// HPバーの割合を回復させる
        /// </summary>
        public Action<float> DrawRecoveryHPBar;

        /// <summary>
        /// HPバーの割合を減少させる
        /// </summary>
        public Action<float> DrawDamageHPBar;

        /// <summary>
        /// HPバーを振動させる
        /// </summary>
        public Action DamagedShake; 
    }
}

