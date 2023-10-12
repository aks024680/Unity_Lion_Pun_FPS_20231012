using Photon.Pun;
using Photon.Realtime;
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

        private string namePlayer;
        private string nameCreateRoom;
        private string nameJoinRoom;

        private TextMeshProUGUI textRoomName;

        private TextMeshProUGUI textRoomPersonCount;

        private Button btnStartGame;

        private void Awake()
        {
            GetUIObject();
            PhotonNetwork.ConnectUsingSettings();
            GetInputFieldData();
            ButtonClickSetting();
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

            textRoomName = GameObject.Find("TextTitle (TMP)").GetComponent<TextMeshProUGUI>();
            textRoomPersonCount = GameObject.Find("TextIntoCount (TMP)").GetComponent<TextMeshProUGUI>();

            btnStartGame = GameObject.Find("ButtonGameStart").GetComponent<Button>();
        }

        private void GetInputFieldData()
        {
            inputFieldName.onEndEdit.AddListener((input) => namePlayer = input);
            inputFieldCreateRoomName.onEndEdit.AddListener((input) => nameCreateRoom = input);
            inputFieldJoinRoomName.onEndEdit.AddListener((input) => nameJoinRoom = input);
        }

        private void ButtonClickSetting()
        {
            btnCreateRoom.onClick.AddListener(BtnCreateRoom);
            btnJoinRoom.onClick.AddListener(BtnJoinRoom);
            btnJoinRandomRoom.onClick.AddListener(BtnRandomRoom);
            btnStartGame.onClick.AddListener(() => photonView.RPC("RPCLoadGameScene", RpcTarget.All)); 
        }

        private void BtnCreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 20;
            PhotonNetwork.CreateRoom(nameCreateRoom, roomOptions);
            btnStartGame.interactable = true;
        }

        private void BtnJoinRoom()
        {
            PhotonNetwork.JoinRoom(nameJoinRoom);
        }
        private void BtnRandomRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        private void UpdateRoomUI()
        {
            groupRoom.alpha = 1.0f;
            groupRoom.interactable = true;
            groupRoom.blocksRaycasts = true;

            textRoomName.text = PhotonNetwork.CurrentRoom.Name;
            textRoomPersonCount.text = $"{PhotonNetwork.CurrentRoom.PlayerCount} / {PhotonNetwork.CurrentRoom.MaxPlayers}";
        }
        [PunRPC]
        private void RPCLoadGameScene()
        {
            Debug.LogError("<color=#69f>開始遊戲</color>");
            PhotonNetwork.LoadLevel("GameScene");
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

        public override void OnCreatedRoom()
        {
            base.OnCreatedRoom();
            print("<color=#6f9>創建房間成功</color>");
            UpdateRoomUI();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            print("<color=#6f9>加入房間成功</color>");
            UpdateRoomUI();
        }
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);
            UpdateRoomUI();
        }
    }
}

