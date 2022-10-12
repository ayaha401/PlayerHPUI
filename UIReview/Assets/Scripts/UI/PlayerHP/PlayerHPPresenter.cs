using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.PlayerHP
{
    public class PlayerHPPresenter : MonoBehaviour
    {
        //[Header("PlayerHP")]
        //[SerializeField] private PlayerHPModel playerHPModel = null;
        //[SerializeField] private PlayerHPView playerHPView = null;

        [Header("HPBar")]
        [SerializeField] private HPBarModel hpBarModel = null;
        [SerializeField] private HPBarView hpBarView = null;

        [Header("HPAmount")]
        [SerializeField] private HPAmountModel hpAmountModel = null;
        [SerializeField] private HPAmountView hpAmountView = null;

        [Header("IncHPAmout")]
        [SerializeField] private IncHPAmountModel incHPAmountModel = null;
        [SerializeField] private IncHPAmountView incHPAmountView = null;

        [Header("DecHPAmount")]
        [SerializeField] private DecHPAmountModel decHPAmountModel = null;
        [SerializeField] private DecHPAmountView decHPAmountView = null;

        private void Awake()
        {
            // PlayerHP
            //playerHPModel.DamagedShake += playerHPView.DamagedShakeAnimation;

            // HPBar
            hpBarModel.DrawInitHPBar += hpBarView.SetBarFillAmount;
            hpBarModel.DrawRecoveryHPBar += hpBarView.SetRecoveryHPBar;
            hpBarModel.DrawDamageHPBar += hpBarView.SetDamageHPBar;
            hpBarModel.DamagedShake += hpBarView.DamagedShakeAnimation;

            // HPAmount
            hpAmountModel.DrawInitCurrentHP += hpAmountView.SetCurrentHP_Num;
            hpAmountModel.DrawInitMaxHP += hpAmountView.SetMaxHP_Num;

            hpAmountModel.DrawCurrentHP += hpAmountView.SetCurrentHP_Num;
            hpAmountModel.DrawMaxHP += hpAmountView.SetMaxHP_Num;

            // IncHPAmount
            incHPAmountModel.DrawIncHPAmount += incHPAmountView.GenerateIncHPAmount;

            // DecHPAmount
            decHPAmountModel.DrawDecHPAmount += decHPAmountView.GenerateDecHPAmount;
        }
    }
}

