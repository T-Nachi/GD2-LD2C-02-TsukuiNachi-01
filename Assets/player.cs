using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform target; // 目標のTransformを参照するための変数
    public float moveSpeed1 = 5.0f; // スピード1
    public float moveSpeed2 = 10.0f; // スピード2
    public float moveSpeed3 = 15.0f; // スピード3

    private bool isMoving = false; // 移動中かどうかを示すフラグ
    private bool canPlaceMarker = true; // 目標を設定できるかどうかを示すフラグ

    void Update()
    {
        // マウスクリックで目標を設定
        if (Input.GetMouseButtonDown(0) && canPlaceMarker)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            target.position = mousePosition;

            isMoving = false;
            canPlaceMarker = false; // 新しい目標を設定したので、目標を再設定できないようにする
        }

        // 数字キーで移動
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveToTarget(moveSpeed1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveToTarget(moveSpeed2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveToTarget(moveSpeed3);
        }
    }

    // 目標に向かって移動する関数
    private void MoveToTarget(float speed)
    {
        if (target != null && !isMoving)
        {
            StartCoroutine(MoveCoroutine(speed));
        }
    }

    // 移動のコルーチン
    private IEnumerator MoveCoroutine(float speed)
    {
        isMoving = true;
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = target.position;

        while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            // プレイヤーの位置から目標に向かうベクトル
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            // プレイヤーの位置から目標に向かうRayを飛ばす
            RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 0.1f);

            // Rayが壁にヒットした場合、移動を終了
            if (hit.collider != null && hit.collider.tag == "Wall")
            {
                isMoving = false;
                canPlaceMarker = true; // 移動が終了したので、新しい目標を設定できるようにする
                yield break; // コルーチンを終了
            }

            // プレイヤーを目標に向かって移動
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
        canPlaceMarker = true; // 移動が終了したので、新しい目標を設定できるようにする
    }
}
