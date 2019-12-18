using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnInputAxis : MonoBehaviour
{
    [SerializeField] string _inputAxisName = default;
    [SerializeField] int _sceneIndex = default;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (0f < Input.GetAxis(_inputAxisName))
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}
