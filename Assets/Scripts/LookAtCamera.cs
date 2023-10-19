using UnityEngine;

namespace photonPun
{
    /// <summary>
    /// 面向攝影機控制器
    /// </summary>
    public class LookAtCamera : MonoBehaviour
    {
        private Transform pointCamera;

        private void Awake()
        {
            pointCamera = Camera.main.transform;
        }

        private void Update()
        {
            LookAt();
        }
        private void LookAt()
        {
            transform.LookAt(pointCamera);
        }
    }
}

