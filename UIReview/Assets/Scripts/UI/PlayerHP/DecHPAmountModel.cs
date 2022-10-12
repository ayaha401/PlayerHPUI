using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UI.PlayerHP
{
    public class DecHPAmountModel : MonoBehaviour
    {
        /// <summary>
        /// HPが減った時に減少値を出す
        /// </summary>
        public Action<Vector2, int> DrawDecHPAmount;
    }
}

