using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UI.PlayerHP
{
    public class PlayerHPUI : MonoBehaviour
    {
        [Header("HPBar")]
        [SerializeField] private HPBarModel hpBarModel = null;

        [Header("HPAmount")]
        [SerializeField] private HPAmountModel hpAmountModel = null;

        [Header("IncHPAmount")]
        [SerializeField] private IncHPAmountModel incHPAmountModel = null;

        [Header("DecHPAmount")]
        [SerializeField] private DecHPAmountModel decHPAmountModel = null;

        /// <summary>
        /// HPを初期化するために使う
        /// </summary>
        /// <param name="maxHP">最大HP</param>
        /// <param name="currentHP">現在のHP</param>
        public void DrawInitHP(int maxHP, int currentHP)
        {
            hpAmountModel.DrawInitCurrentHP(currentHP);
            hpAmountModel.DrawInitMaxHP(maxHP);
            hpBarModel.DrawInitHPBar((float)currentHP / (float)maxHP);
        }

        /// <summary>
        /// HPが回復する時に使う
        /// </summary>
        /// <param name="maxHP">最大HP</param>
        /// <param name="currentHP">現在のHP</param>
        /// <param name="playerPos">プレイヤーの位置</param>
        /// <param name="incAmount">増えるHP量</param>
        public void DrawRecoveryHP(int maxHP, int currentHP, Vector2 playerPos, int incAmount)
        {
            hpAmountModel.DrawCurrentHP(currentHP);
            hpAmountModel.DrawMaxHP(maxHP);
            hpBarModel.DrawRecoveryHPBar((float)currentHP / (float)maxHP);
            incHPAmountModel.DrawIncHPAmount(playerPos, incAmount);
        }

        /// <summary>
        /// HPが減少する時に使う
        /// </summary>
        /// <param name="maxHP">最大HP</param>
        /// <param name="currentHP">現在のHP</param>
        /// <param name="playerPos">プレイヤーの位置</param>
        /// <param name="incAmount">減るHP量</param>
        public void DrawDamageHP(int maxHP, int currentHP, Vector2 playerPos, int decAmount)
        {
            hpAmountModel.DrawCurrentHP(currentHP);
            hpAmountModel.DrawMaxHP(maxHP);
            hpBarModel.DrawDamageHPBar((float)currentHP / (float)maxHP);
            hpBarModel.DamagedShake();
            decHPAmountModel.DrawDecHPAmount(playerPos, decAmount);
        }

        /// <summary>
        /// 最大HPの見た目を変える
        /// </summary>
        public void DrawMaxHP(int maxHP, int currentHP)
        {
            hpAmountModel.DrawMaxHP(maxHP);
            hpBarModel.DrawInitHPBar((float)currentHP / (float)maxHP);
        }
    }
}

