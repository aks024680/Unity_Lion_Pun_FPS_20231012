using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace photonPun
{
    /// <summary>
    /// 大廳管理器
    /// </summary>
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        #region 資料
        /// <summary>
        /// 畫布連線大廳
        /// </summary>
        private CanvasGroup groupLobby;
        /// <summary>
        /// 房間資訊
        /// </summary>
        private CanvasGroup groupRoom;
        /// <summary>
        /// 輸入欄位玩家名稱
        /// </summary>
        private TMP_InputField inputFieldName;
        /// <summary>
        /// 輸入欄位創建房間名稱
        /// </summary>
        private TMP_InputField inputFieldCreateRoomName;
        /// <summary>
        /// 輸入欄位加入房間名稱
        /// </summary>
        private TMP_InputField inputFieldJoinRoomName;
        /// <summary>
        /// 按鈕創建房間
        /// </summary>
        private Button btnCreateRoom;
        /// <summary>
        /// 按鈕加入房間
        /// </summary>
        private Button btnJoinRoom;
        /// <summary>
        /// 按鈕加入隨機房間
        /// </summary>
        private Button btnJoinRandomRoom;
        #endregion

        private void Awake()
        {
            GetUIObject();
            PhotonNetwork.ConnectUsingSettings();
        }

        private void GetUIObject()
        {
            groupLobby = GameObject.Find("CanvasLobby").GetComponent<CanvasGroup>();
            groupRoom = GameObject.Find("RoomName").GetComponent<CanvasGroup>();
            inputFieldName = GameObject.Find("InputPlayerName (TMP)").GetComponent<TMP_InputField>();
            inputFieldCreateRoomName = GameObject.Find("InputCreateRoomName (TMP)").GetComponent<TMP_InputField>();
            inputFieldJoinRoomName = GameObject.Find("InputIntoRoomName (TMP)").GetComponent<TMP_InputField>();
            btnCreateRoom = GameObject.Find("ButtonCreateRoom").GetComponent<Button>();
            btnJoinRoom = GameObject.Find("ButtonIntoRoom").GetComponent<Button>();
            btnJoinRandomRoom = GameObject.Find("ButtonIntoRandomRoom").GetComponent<Button>();
        }
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            {
                base.OnConnectedToMaster();
                print("<color=#f96>連線至伺服器成功!</color>");
                groupLobby.interactable = true;
            }
        }
    }
}

