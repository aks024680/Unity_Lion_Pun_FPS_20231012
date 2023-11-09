using UnityEngine;
using Photon.Pun;
using StarterAssets;
using TMPro;
using Cinemachine;

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
        [SerializeField,Header("畫布主要")]
        private GameObject objectMainCanvas;
        [SerializeField, Header("開槍系統")]
        private FireSystem fireSystem;
        [SerializeField, Header("輸入資源")]
        private StarterAssetsInputs starterAssetsInputs;

        private string pointName = "Spawn";

        private void Awake()
        {
            SettingPosition();
            if (!photonView.IsMine)
            {
                objectCamera.tag = "Untagged";
                objectCamera.GetComponent<Camera>().enabled = false;
                objectCamera.GetComponent<AudioListener>().enabled = false;
                objectCamera.GetComponent<CinemachineBrain>().enabled = false;
                //objectCamera.SetActive(false);
                objectCameraFollow.SetActive(false); 
                firstPersonController.enabled = false;
                objectMainCanvas.SetActive(false);
                //fireSystem.enabled = false;
                starterAssetsInputs.cursorLocked = false;
            }
            else if(photonView.IsMine)
            {
                objectGirlHead.layer = 3;
                firstPersonController.transform.localPosition = Vector3.zero;
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

