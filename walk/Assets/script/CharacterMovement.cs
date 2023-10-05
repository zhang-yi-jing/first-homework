using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �ƶ��ٶ�

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ��ȡ�������
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // �����ƶ�����
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // �����ƶ���
        Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;

        // Ӧ���ƶ�������ɫλ��
        rb.MovePosition(transform.position + moveAmount);
    }
}