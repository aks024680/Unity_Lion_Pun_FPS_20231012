using Photon.Pun;
using UnityEngine;

namespace photonPun
{
    /// <summary>
    /// 開槍系統
    /// </summary>
    public class FireSystem : MonoBehaviour
    {
        [SerializeField, Header("子彈預置物")]
        private GameObject prefabBullet;
        [SerializeField, Header("槍口")]
        private Transform pointFire;
        private void Update()
        {
            Fire();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1,0.6f,0.6f,0.5f);
            Gizmos.DrawRay(pointFire.position, pointFire.forward * 100);

            Gizmos.color = new Color(0.2f, 0.3f, 0.3f, 0.8f);
            Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100);
        }

        private void Fire()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0)) {
            PhotonNetwork.Instantiate(prefabBullet.name, pointFire.position,Quaternion.identity);
            }
        }
    }
}

