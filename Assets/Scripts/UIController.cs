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

    private void Awake()
    {
        instance = this;
    }
}
