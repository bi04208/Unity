using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class button : MonoBehaviour
{
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("Restart_Scene");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
