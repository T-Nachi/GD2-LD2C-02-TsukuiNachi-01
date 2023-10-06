using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // プレイヤーのTransformを参照するための変数
    public float smoothSpeed = 5.0f; // カメラの追従速度

    void LateUpdate()
    {
        if (target != null)
        {
            // プレイヤーの現在位置
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z; // カメラのZ座標は変更しない

            // カメラを滑らかにプレイヤーの位置に追従
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
