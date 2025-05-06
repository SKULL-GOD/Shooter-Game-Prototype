using UnityEngine;
using Unity.Cinemachine;

public class CinemachineCameraSwitcher : MonoBehaviour
{
    public CinemachineCamera[] cameras;  // 把 roboCam1-5 依次拖进来
    public float switchInterval = 3f;           // 每段时长（秒）

    private int currentIndex = 0;

    public SmoothBurstMove burstMove;
    private float timer = 0f;

    void Start()
    {
        // 确保只有第一个相机激活
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].Priority = (i == 0) ? 10 : 0;
        }
    }

    void Update()
    {
        if (currentIndex >= cameras.Length - 1) return;  // 切到最后一个就停

        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            // 切换到下一个相机
                        if(currentIndex==3){
                            burstMove.StartMoving();
                        }
            cameras[currentIndex].Priority = 0;
            currentIndex++;
            cameras[currentIndex].Priority = 10;



            timer = 0f;
        }
    }
}
