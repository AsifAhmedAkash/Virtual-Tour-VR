using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField userNameText;
    public TMP_InputField roomNameText;
    public TMP_InputField maxPlayer;

    public GameObject PlayerNamePanel;
    public GameObject LobbyPanel;
    public GameObject RoomCreatedPanel;
    public GameObject ConnectingPanel;
    public GameObject RoomListPanel;


    #region UnityMethods
    // Start is called before the first frame update
    void Start()
    {
        ActivateMyPanel(PlayerNamePanel.name);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Network state : " + PhotonNetwork.NetworkClientState.ToString());    
    }

    #endregion

    #region UIMethods
    public void onLogInClick()
    {
        string name = userNameText.text;

        if(!string.IsNullOrEmpty(name))
        {
            PhotonNetwork.LocalPlayer.NickName = name;
            PhotonNetwork.ConnectUsingSettings();
            ActivateMyPanel(ConnectingPanel.name);
        }
        else
        {
            Debug.Log("Empty name");
        }
    }

    public void OnClickRoomCreate()
    {
        string roomName = roomNameText.text;
        if (!string.IsNullOrEmpty(roomName))
        {
            roomName = roomName + Random.Range(0, 1000);
        }

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)int.Parse(maxPlayer.text);
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    public void OnCancelClick()
    {
        ActivateMyPanel(LobbyPanel.name);
    }

    public void RoomListBtnClicked()
    {
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
        ActivateMyPanel(RoomListPanel.name);
    }

    #endregion

    #region PhotonCallBacks

    public override void OnConnected()
    {
        base.OnConnected();

        Debug.Log("Connected to internet");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        ActivateMyPanel(LobbyPanel.name);
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " connected to photon...");
    }


    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log(PhotonNetwork.CurrentRoom.Name + "is created"); 
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " Room joined");
        
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        foreach (RoomInfo rooms in roomList) {
            Debug.Log("room name " + rooms.Name);
        }
    }

    #endregion

    #region Public_Methods

    public void ActivateMyPanel(string panelName)
    {
        LobbyPanel.SetActive(panelName.Equals(LobbyPanel.name));
        PlayerNamePanel.SetActive(panelName.Equals(PlayerNamePanel.name));
        RoomCreatedPanel.SetActive(panelName.Equals(RoomCreatedPanel.name));
        ConnectingPanel.SetActive(panelName.Equals(ConnectingPanel.name));
        RoomListPanel.SetActive(panelName.Equals(RoomListPanel.name));
    
    }

    #endregion

}
