using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform target; // �ڕW��Transform���Q�Ƃ��邽�߂̕ϐ�
    public float moveSpeed1 = 5.0f; // �X�s�[�h1
    public float moveSpeed2 = 10.0f; // �X�s�[�h2
    public float moveSpeed3 = 15.0f; // �X�s�[�h3

    private bool isMoving = false; // �ړ������ǂ����������t���O
    private bool canPlaceMarker = true; // �ڕW��ݒ�ł��邩�ǂ����������t���O

    void Update()
    {
        // �}�E�X�N���b�N�ŖڕW��ݒ�
        if (Input.GetMouseButtonDown(0) && canPlaceMarker)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            target.position = mousePosition;

            isMoving = false;
            canPlaceMarker = false; // �V�����ڕW��ݒ肵���̂ŁA�ڕW���Đݒ�ł��Ȃ��悤�ɂ���
        }

        // �����L�[�ňړ�
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

    // �ڕW�Ɍ������Ĉړ�����֐�
    private void MoveToTarget(float speed)
    {
        if (target != null && !isMoving)
        {
            StartCoroutine(MoveCoroutine(speed));
        }
    }

    // �ړ��̃R���[�`��
    private IEnumerator MoveCoroutine(float speed)
    {
        isMoving = true;
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = target.position;

        while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            // �v���C���[�̈ʒu����ڕW�Ɍ������x�N�g��
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            // �v���C���[�̈ʒu����ڕW�Ɍ�����Ray���΂�
            RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 0.1f);

            // Ray���ǂɃq�b�g�����ꍇ�A�ړ����I��
            if (hit.collider != null && hit.collider.tag == "Wall")
            {
                isMoving = false;
                canPlaceMarker = true; // �ړ����I�������̂ŁA�V�����ڕW��ݒ�ł���悤�ɂ���
                yield break; // �R���[�`�����I��
            }

            // �v���C���[��ڕW�Ɍ������Ĉړ�
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
        canPlaceMarker = true; // �ړ����I�������̂ŁA�V�����ڕW��ݒ�ł���悤�ɂ���
    }
}
