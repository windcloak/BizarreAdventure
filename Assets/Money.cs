using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public TMP_Text scoreText;
    public static float money = 0f;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = money.ToString("0");
    }

    // increase (find loot) or decrease money (buy stuff)
    public static void UpdateMoney(float n)
    {
        money += n;
    }

    // reset on game over
    public static void ResetMoney()
    {
        money = 0;
    }

    public static float GetMoney()
    {
        return money;
    }
}
