using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public Vector3 startPos = new Vector3(68.17f, -0.83f, -79.56f);
    public Vector3 endPos = new Vector3(-14.73f, -0.05f, 25.5f);
    public float moveDuration = 5f;  // 移动用时（秒）

    private float timer = 0f;
    private bool isMoving = true;

    void Start()
    {
        transform.position = startPos;
    }

    void Update()
    {
        if (!isMoving) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / moveDuration);  // 计算0~1之间的比例

        transform.position = Vector3.Lerp(startPos, endPos, t);

        if (t >= 1f)
        {
            isMoving = false;  // 到达终点后停止
        }
    }
}
