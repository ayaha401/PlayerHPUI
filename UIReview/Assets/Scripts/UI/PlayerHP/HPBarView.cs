using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UI.PlayerHP
{
    /// <summary>
    /// HPバーの見た目
    /// </summary>
    public class HPBarView : MonoBehaviour
    {
        [SerializeField] private Image mainBarImage = null;
        [SerializeField] private Image subBarImage = null;

        private Sequence recoveryHPBarSequence;
        private Sequence damageHPBarSequence;

        [Header("アニメーション調整")]
        [SerializeField, Tooltip("FillAmountが動く所要時間")] private float fillSpeed = 0.2f;

        [Header("振動設定")]
        [SerializeField, Tooltip("振動時間")] private float shakeDuration = 0.2f;
        [SerializeField, Tooltip("強度")] private float shakeStrength = 10.0f;
        [SerializeField, Tooltip("振動数")] private int shakeRandomness = 20;

        /// <summary>
        /// HPバーの割合をアニメーション無しで設定する
        /// </summary>
        /// <param name="hpRatio">HP割合</param>
        public void SetBarFillAmount(float hpRatio)
        {
            mainBarImage.fillAmount = hpRatio;
            subBarImage.fillAmount = hpRatio;
        }

        /// <summary>
        /// 回復した時のHP演出
        /// </summary>
        /// <param name="hpRatio">HP割合</param>
        public void SetRecoveryHPBar(float hpRatio)
        {
            subBarImage.color = Color.white;

            damageHPBarSequence.Kill();

            recoveryHPBarSequence = DOTween.Sequence();
            recoveryHPBarSequence.Append(subBarImage
                                    .DOFillAmount(hpRatio, fillSpeed)
                                    .SetEase(Ease.OutQuint))
                                 .Play();
            recoveryHPBarSequence.Append(mainBarImage
                                    .DOFillAmount(hpRatio, fillSpeed)
                                    .SetEase(Ease.OutQuint))
                                 .Play();
        }

        /// <summary>
        /// ダメージを受けた時のHP演出
        /// </summary>
        /// <param name="hpRatio">HP割合</param>
        public void SetDamageHPBar(float hpRatio)
        {
            
            subBarImage.color = Color.red;

            recoveryHPBarSequence.Kill();

            damageHPBarSequence = DOTween.Sequence();
            damageHPBarSequence.Append(mainBarImage
                                    .DOFillAmount(hpRatio, fillSpeed)
                                    .SetEase(Ease.OutQuint))
                                .Play();
            damageHPBarSequence.Append(subBarImage
                                    .DOFillAmount(hpRatio, fillSpeed)
                                    .SetEase(Ease.OutQuint))
                                .Play();
        }

        /// <summary>
        /// HPバーを振動させる
        /// </summary>
        public void DamagedShakeAnimation()
        {
            this.gameObject.transform.DOShakePosition(shakeDuration, shakeStrength, shakeRandomness)
                                     .Play();
        }
    }
}

