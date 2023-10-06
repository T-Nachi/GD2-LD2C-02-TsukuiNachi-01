using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public Transform target; // �ڕW��Transform
    private LineRenderer lineRenderer; // LineRenderer�R���|�[�l���g�̎Q��

    void Start()
    {
        // LineRenderer�R���|�[�l���g�̎擾
        lineRenderer = GetComponent<LineRenderer>();
        // ���C���̕���ݒ�
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        // �v���C���[�̈ʒu����ڕW�̈ʒu�܂Ń��C����`��
        if (target != null)
        {
            lineRenderer.SetPosition(0, transform.position); // ���C���̎n�_���v���C���[�̈ʒu�ɐݒ�
            lineRenderer.SetPosition(1, target.position); // ���C���̏I�_��ڕW�̈ʒu�ɐݒ�
        }
        else
        {
            // �ڕW���ݒ肳��Ă��Ȃ��ꍇ�A���C�����\���ɂ���
            lineRenderer.enabled = false;
        }
    }
}
