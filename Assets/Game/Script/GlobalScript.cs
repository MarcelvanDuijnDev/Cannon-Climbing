using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GlobalScript : MonoBehaviour {

    [SerializeField]private bool noPauzeMenu;
    private GameObject Canvas_PauzeMenu;

	void Start () 
    {
        if (!noPauzeMenu)
        {
            Canvas_PauzeMenu = GameObject.Find("Canvas_PauzeMenu");
            Canvas_PauzeMenu.SetActive(false);
        }
	}
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !noPauzeMenu)
        {
            if (Canvas_PauzeMenu.activeSelf) { Canvas_PauzeMenu.SetActive(false); }
            else { Canvas_PauzeMenu.SetActive(true); }
        }
	}

    public void Click_Resume()
    {
        Canvas_PauzeMenu.SetActive(false);
    }

    public void Click_NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Click_Menu()
    {
        SceneManager.LoadScene(0);
    }
}
