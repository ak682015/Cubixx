using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public GameObject HomeUI;
    public GameObject coinplus;
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
        DataSet.inPlay = true;
        coinplus.SetActive(false);
        Score.gameObject.SetActive(true);
    }
}
