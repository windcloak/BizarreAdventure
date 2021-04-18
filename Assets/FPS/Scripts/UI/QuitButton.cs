using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }
}
