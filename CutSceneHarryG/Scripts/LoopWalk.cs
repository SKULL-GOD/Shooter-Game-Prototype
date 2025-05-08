using UnityEngine;

public class LoopWalk : MonoBehaviour
{
    public Transform endPoint;     // 指定的终点（可拖到 Inspector）
    public float walkSpeed = 2f;   // 移动速度（可调）

    private Animator animator;
    private Vector3 startPos;
    private bool hasStarted = false;
    private float delayTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        startPos = transform.position;
        delayTime = Random.Range(0f, 2f);   // 随机延时 0~2 秒

        if (endPoint == null)
        {
            Debug.LogWarning("EndPoint 未设置！");
        }
    }

    void Update()
    {
        if (!hasStarted)
        {
            delayTime -= Time.deltaTime;
            if (delayTime <= 0f)
            {
                animator.Play("Run_Aim", 0, Random.value);
                hasStarted = true;
            }
            return;
        }

        if (endPoint != null)
        {
            Vector3 direction = (endPoint.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, endPoint.position);
            float moveStep = walkSpeed * Time.deltaTime;

            if (distance > moveStep)
            {
                transform.Translate(direction * moveStep, Space.World);
            }
            else
            {
                transform.position = endPoint.position;  // 抵达终点
                hasStarted = false;                    // 停止移动
               
            }
        }
    }
}
