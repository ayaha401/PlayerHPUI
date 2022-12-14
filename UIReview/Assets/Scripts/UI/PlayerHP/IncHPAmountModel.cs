using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UI.PlayerHP
{
    public class IncHPAmountModel : MonoBehaviour
    {
        /// <summary>
        /// HPが増えた時に増加値を出す
        /// </summary>
        public Action<Vector2, int> DrawIncHPAmount;
    }
}

