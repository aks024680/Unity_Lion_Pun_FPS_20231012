using Photon.Pun;
using UnityEngine;

namespace photonPun
{
    /// <summary>
    /// 生成玩家控制器
    /// </summary>
    public class SpawnPlayerController : MonoBehaviourPunCallbacks
    {
        [SerializeField, Header("玩家控制物件")]
        private GameObject prefabPlayer;

        private void Awake()
        {
            PhotonNetwork.Instantiate(prefabPlayer.name,Vector3.zero,Quaternion.identity);
        }
    }
}

