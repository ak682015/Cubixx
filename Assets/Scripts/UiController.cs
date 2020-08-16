using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public GameObject HomeUI;
    public TextMeshProUGUI coins;
    public Text Score;


    private void Start()
    {
        Score.gameObject.SetActive(false);
    }
    private void Update()
    {
       coins.text = DataSet.coin.ToString();
    }


    public void startGame()
    {
        HomeUI.SetActive(false);
        Time.timeScale = 1f;
        Score.gameObject.SetActive(true);
    }
}
