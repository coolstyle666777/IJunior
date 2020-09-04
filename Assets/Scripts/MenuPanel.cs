using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AnimationOfPanel))]
public class MenuPanel : MonoBehaviour
{
    private AnimationOfPanel _panelAnimation;
    private const int NUMBER_OF_GAMESCENE = 1;

    private void Awake()
    { 
        _panelAnimation = GetComponent<AnimationOfPanel>();
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(NUMBER_OF_GAMESCENE);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnAuthorsButtonClick()
    {
        _panelAnimation.HidePannel();      
    } 
}
