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

        private Vector3 _pointHit;
        private Vector3 pointHit
        {
            get 
            {
                if(_pointHit == Vector3.zero)
                {
                    return Camera.main.transform.forward * 100;
                }
                else
                {
                    return _pointHit;
                }
            }
            set => _pointHit = value;
        }

        private void Update()
        {
            Fire();
            CheckHitPoint();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1,0.6f,0.6f,0.5f);
            Gizmos.DrawRay(pointFire.position, pointFire.forward * 100);

            Gizmos.color = new Color(0.2f, 0.3f, 0.3f, 0.8f);
            Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100);
            Gizmos.color = new Color(0.95f, 0.8f, 0.6f, 0.9f);
            Gizmos.DrawLine(pointFire.position,pointHit);
        }

        private void Fire()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0)) {
            GameObject tempBullet = PhotonNetwork.Instantiate(prefabBullet.name, pointFire.position,Quaternion.identity);
                tempBullet.GetComponent<Bullet>().targetPoint = pointHit;
            }
        }

        private void CheckHitPoint()
        {
            Vector3 posStart = Camera.main.transform.position;
            Vector3 posDirection = Camera.main.transform.forward;
            RaycastHit hit;

            if(Physics.Raycast(posStart, posDirection, out hit, 100))
            {
                print($"射線打到的物件 : {hit.collider.gameObject}");
                pointHit = hit.point;
            }
            else
            {
                _pointHit = Vector3.zero;
            }
        }
    }
}

