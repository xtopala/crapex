using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher instance;

    public GameObject loadingScreen, menuButtons;
    public TMP_Text loadingText;

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
    }
}
