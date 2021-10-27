using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher instance;

    public GameObject loadingScreen, menuButtons;
    public TMP_Text loadingText;

    public GameObject createRoomScreen;
    public TMP_InputField roomNameInput;

    public GameObject roomScreen;
    public TMP_Text roomNameText;

    public GameObject errorScreen;
    public TMP_Text errorText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CloseMenus();

        loadingScreen.SetActive(true);
        loadingText.text = "Connecting to Network ...";

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        loadingText.text = "Joining Loby ...";
    }

    public override void OnJoinedLobby()
    {
        CloseMenus();
        menuButtons.SetActive(true);
    }

    void CloseMenus()
    {
        loadingScreen.SetActive(false);
        menuButtons.SetActive(false);
        createRoomScreen.SetActive(false);
        roomScreen.SetActive(false);
        errorScreen.SetActive(false);
    }

    public void OpenRoomCreate()
    {
        CloseMenus();
        createRoomScreen.SetActive(true);
    }

    public void CreateRoom()
    {
        if (!string.IsNullOrEmpty(roomNameInput.text))
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 8;

            PhotonNetwork.CreateRoom(roomNameInput.text, options);

            CloseMenus();
            loadingText.text = "Creating Room ...";
            loadingScreen.SetActive(true);
        }
    }

    public override void OnJoinedRoom()
    {
        CloseMenus();
        roomScreen.SetActive(true);

        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Failed to Create Room: " + message;
        CloseMenus();

        errorScreen.SetActive(true);
    }

    public void CloseErrorScreen()
    {
        CloseMenus();
        menuButtons.SetActive(true);
    }
}
