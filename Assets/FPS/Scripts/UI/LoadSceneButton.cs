using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public string sceneName = "";

    private void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == gameObject 
            && Input.GetButtonDown(GameConstants.k_ButtonNameSubmit))
        {
            FindObjectOfType<AudioManager>().Play("Button");
            LoadTargetScene();
        }
    }

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
