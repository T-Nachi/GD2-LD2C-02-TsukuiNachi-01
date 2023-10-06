using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �v���C���[��Transform���Q�Ƃ��邽�߂̕ϐ�
    public float smoothSpeed = 5.0f; // �J�����̒Ǐ]���x

    void LateUpdate()
    {
        if (target != null)
        {
            // �v���C���[�̌��݈ʒu
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z; // �J������Z���W�͕ύX���Ȃ�

            // �J���������炩�Ƀv���C���[�̈ʒu�ɒǏ]
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
