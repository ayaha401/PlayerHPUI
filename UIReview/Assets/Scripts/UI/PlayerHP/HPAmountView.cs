using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI.PlayerHP
{
    /// <summary>
    /// HPの分数のところの見た目
    /// </summary>
    public class HPAmountView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI currentHP_TMP = null;
        [SerializeField] TextMeshProUGUI maxHP_TMP = null;


        /// <summary>
        /// 現在のHPを変える
        /// </summary>
        /// <param name="num">現在のHP量</param>
        public void SetCurrentHP_Num(int num)
        {
            currentHP_TMP.text = num.ToString();
        }

        /// <summary>
        /// 最大HPを変える
        /// </summary>
        /// <param name="num">最大HP量</param>
        public void SetMaxHP_Num(int num)
        {
            maxHP_TMP.text = num.ToString();
        }
    }
}

