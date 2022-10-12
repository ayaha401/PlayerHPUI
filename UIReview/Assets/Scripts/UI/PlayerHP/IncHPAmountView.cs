using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace UI.PlayerHP
{
    /// <summary>
    /// 頭上に回復量を出す見た目
    /// </summary>
    public class IncHPAmountView : MonoBehaviour
    {
        [SerializeField] private GameObject textObj;
        [SerializeField] private new Camera camera;

        [Header("テキストの位置調整")]
        [SerializeField, Tooltip("UIのオフセット")] private Vector2 uiOffset = Vector2.zero;

        [Header("テキストの拡大")]
        [SerializeField, Tooltip("拡大の大きさ")] private Vector2 textSize = new Vector2(1.6f, 1.6f);
        [SerializeField, Tooltip("拡大完了までの時間")] private float sizeCompTime = 0.1f;

        [Header("表現停止")]
        [SerializeField, Tooltip("停止時間")] private float delayTime = 0.1f;

        [Header("テキストの透明度")]
        [SerializeField, Tooltip("見えなくなるまでの時間")] private float transparentTime = 1f;

        /// <summary>
        /// HPの増加値のアニメーション
        /// </summary>
        /// <param name="generatePos">生成位置</param>
        /// <param name="amount">増加量</param>
        public void GenerateIncHPAmount(Vector2 generatePos, int amount)
        {
            TextMeshProUGUI tmp = null;
            RectTransform tmpRect = null;
            Canvas canvas;

            // スクリーン座標変換
            Vector2 screenPos = camera.WorldToScreenPoint(generatePos + uiOffset);

            // オブジェクト生成
            GameObject generatedTextObj = Instantiate(textObj);

            // コンポーネント取得
            canvas = GetComponentInParent<Canvas>() ?? GetComponentInParent<Canvas>();
            tmp ??= generatedTextObj.GetComponent<TextMeshProUGUI>();
            tmpRect ??= generatedTextObj.GetComponent<RectTransform>();

            tmp.text = amount.ToString();

            // UI移動
            generatedTextObj.transform.SetParent(canvas.transform, false);
            Vector2 localPos = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                tmpRect,
                screenPos,
                null,
                out localPos);
            tmpRect.localPosition = localPos;


            //====================================//
            // Append           : 拡大            //
            // SetDelay         : 停止            //
            // Append           : フェードアウト  //
            //====================================//
            Sequence sequence = DOTween.Sequence();
            sequence.Append(tmpRect.DOScale(textSize, sizeCompTime))
                    .SetDelay(delayTime)
                    .Append(DOTween.ToAlpha(
                        () => tmp.color,
                        col => tmp.color = col,
                        0f,
                        transparentTime)
                    .OnComplete(() => Destroy(generatedTextObj)))
                    .Play();
        }
    }
}
