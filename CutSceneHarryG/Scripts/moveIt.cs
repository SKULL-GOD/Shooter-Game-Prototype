using UnityEngine;

public class SmoothBurstMove : MonoBehaviour
{
    public Vector3 startPos = new Vector3(18f, 0.5f, -5f);
    public Vector3 endPos = new Vector3(-4.25f, 1.5f, 10f);
    public float duration = 5f;  // 总时间（秒）
    public AnimationCurve speedCurve;  // 自定义速度曲线

    private float timer = 0f;
    private bool isMoving = false;

    void Start()
    {
        transform.position = startPos;

        // 如果没有手动配置，自动生成一个缓入-爆发-缓出曲线
        if (speedCurve == null || speedCurve.length == 0)
        {
            speedCurve = new AnimationCurve(
                new Keyframe(0f, 0f),      // 开始慢
                new Keyframe(0.4f, 0.2f),  // 缓慢加速
                new Keyframe(0.5f, 1f),    // 突然爆发
                new Keyframe(0.6f, 0.2f),  // 减速
                new Keyframe(1f, 1f)       // 结束慢
            );
        }
    }

    public void StartMoving()
{
    transform.position = startPos;
    timer = 0f;
    isMoving = true;
}


    void Update()
    {
        if (!isMoving) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);

        float curveValue = speedCurve.Evaluate(t);

        transform.position = Vector3.Lerp(startPos, endPos, curveValue);

        if (t >= 1f)
        {
            isMoving = false;
        }
    }
}
