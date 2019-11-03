using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDying : MonoBehaviour
{
    PlayerStateBehaviour _playerStateBehaviourRef;

    [SerializeField]
    private EndScreenColorPicker _endScreenColorPicker;

    [SerializeField]
    SongManager _songManager;

    bool _isDead = false;

    private void Start()
    {
        _playerStateBehaviourRef = GetComponent<PlayerStateBehaviour>();
    }

    private void Update()
    {
        if (_isDead == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Attack")
        {
            _playerStateBehaviourRef.ResetToSpawnPosition();
            _isDead = true;

            // Reset Game!
            _songManager.StopPlaying();

            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            playerMovement.enabled = false;
            _endScreenColorPicker.gameObject.SetActive(true);
        }
    }
}