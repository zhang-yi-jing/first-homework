using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 获取玩家输入
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // 计算移动量
        Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;

        // 应用移动量到角色位置
        rb.MovePosition(transform.position + moveAmount);
    }
}