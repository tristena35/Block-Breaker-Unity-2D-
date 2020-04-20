using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
       DontDestroyOnLoad(gameObject);
       Debug.Log("Theme Song");
    }

    public void ResetSong()
    {
        Destroy(gameObject);
    }
    
}
