using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour {

    private static LoadSceneManager _loadSceneManager;
    public static LoadSceneManager Instance { get { return _loadSceneManager; } }


    private string _loadSceneName;
    public string LoadSceneName { get { return _loadSceneName; } set{_loadSceneName = value;} }
    

    void Awake()
    {
        if (_loadSceneManager == null)
        {
            _loadSceneManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_loadSceneManager != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAsync(string sceneName)
    {
        _loadSceneName = sceneName;
        SceneManager.LoadScene("02.LoadingScene");
    }
}