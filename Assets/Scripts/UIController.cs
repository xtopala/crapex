using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Slider weaponTempSlider;
    public TMP_Text overheatedMessage;

    public GameObject deathScreen;
    public TMP_Text deathText;

    public Slider healthSlider;

    public TMP_Text killsText, deathsText;

    public GameObject leaderboard;
    public LeaderboardPlayer leaderboardPlayerDisplay;

    public GameObject endScreen;

    public TMP_Text timerText;

    private void Awake()
    {
        instance = this;
    }
}
