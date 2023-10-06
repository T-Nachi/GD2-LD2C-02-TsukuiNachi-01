using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public Transform target; // 目標のTransform
    private LineRenderer lineRenderer; // LineRendererコンポーネントの参照

    void Start()
    {
        // LineRendererコンポーネントの取得
        lineRenderer = GetComponent<LineRenderer>();
        // ラインの幅を設定
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        // プレイヤーの位置から目標の位置までラインを描画
        if (target != null)
        {
            lineRenderer.SetPosition(0, transform.position); // ラインの始点をプレイヤーの位置に設定
            lineRenderer.SetPosition(1, target.position); // ラインの終点を目標の位置に設定
        }
        else
        {
            // 目標が設定されていない場合、ラインを非表示にする
            lineRenderer.enabled = false;
        }
    }
}
