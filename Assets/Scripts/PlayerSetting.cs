using UnityEngine;
using Photon.Pun;
using StarterAssets;
using TMPro;

namespace photonPun
{
    /// <summary>
    /// 玩家設定控制器
    /// </summary>
    public class PlayerSetting : MonoBehaviourPunCallbacks
    {
        [SerializeField, Header("攝影機物件")]
        private GameObject objectCamera;
        [SerializeField, Header("攝影機跟隨物件")]
        private GameObject objectCameraFollow;
        [SerializeField,Header("第一人稱控制器")]
        private FirstPersonController firstPersonController;
        [SerializeField, Header("玩家名稱")]
        private TextMeshProUGUI textPlayerName;
        [SerializeField, Header("theGirl模型")]
        private GameObject objectGirlHead;

        private string pointName = "Spawn";

        private void Awake()
        {
            SettingPosition();
            if (!photonView.IsMine)
            {
                objectCamera.SetActive(false);
                objectCameraFollow.SetActive(false); 
                firstPersonController.enabled = false;
            }
            else if(photonView.IsMine)
            {
                objectGirlHead.layer = 3;
            }
            textPlayerName.text = photonView.Owner.NickName;
        }
        private void SettingPosition()
        {
            int id = photonView.ViewID / 1000;
            Vector3 point = GameObject.Find(pointName + id).transform.position;
            transform.position = point;
        }
    }
}

