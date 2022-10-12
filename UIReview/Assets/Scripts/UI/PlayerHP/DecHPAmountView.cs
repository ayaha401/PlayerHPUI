using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace UI.PlayerHP
{
    /// <summary>
    /// 頭上に減少量を出す見た目
    /// </summary>
    public class DecHPAmountView : MonoBehaviour
    {
        [SerializeField] private GameObject textObj;
        [SerializeField] private new Camera camera;

        [Header("テキストの位置調整")]
        [SerializeField, Tooltip("UIの出現半径")] private float radius;
        [SerializeField, Tooltip("UIの上に上がる距離")] private float upDist = 50f;
        [SerializeField, Tooltip("上昇完了までの時間")] private float upCompTime = 0.5f;

        [Header("テキストの透明度")]
        [SerializeField, Tooltip("見えなくなるまでの時間")] private float transparentTime = 1f;
        
        
        private Vector2 uiOffset = Vector2.zero;        // UI位置のオフセット

        /// <summary>
        /// HPの減少値のアニメーション
        /// </summary>
        /// <param name="generatePos">生成位置</param>
        /// <param name="amount">HP減少量</param>
        public void GenerateDecHPAmount(Vector2 generatePos, int amount)
        {
            TextMeshProUGUI tmp = null;
            RectTransform tmpRect = null;
            Canvas canvas;

            // スクリーン座標変換
            uiOffset = new Vector2(Random.Range(-radius, radius), Random.Range(-radius, radius));
            Vector2 screenPos = camera.WorldToScreenPoint(generatePos + uiOffset);

            // オブジェクト生成
            GameObject generatedTextObj = Instantiate(textObj);

            // コンポーネント取得
            canvas = GetComponentInParent<Canvas>() ?? GetComponentInParent<Canvas>();
            tmp ??= generatedTextObj.GetComponent<TextMeshProUGUI>();
            tmpRect ??= generatedTextObj.GetComponent<RectTransform>();

            // テキスト設定
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

            //================================
            // Append       : 上昇
            // Append       : フェードアウト
            // OnComplete   : 消す
            //================================
            Sequence sequence = DOTween.Sequence();
            sequence.Append(tmpRect.DOAnchorPosY(
                        tmpRect.localPosition.y + upDist,
                        upCompTime))
                    .Append(DOTween.ToAlpha(
                        () => tmp.color,
                        col => tmp.color = col,
                        0f,
                        transparentTime))
                    .OnComplete(
                        () => Destroy(generatedTextObj))
                    .Play();
        }
    }
}
