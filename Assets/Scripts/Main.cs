using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public Web Web;
    public static Main Instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null) {
        Instance = this;
        Web = GetComponent<Web>(); 
        } else
        {
            Destroy(gameObject);
        }
    }

}
