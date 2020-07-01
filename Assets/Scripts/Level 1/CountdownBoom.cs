using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountdownBoom : MonoBehaviour
{

    private bool _countdownFinished = false;
    [SerializeField] private bool showCountdown = true;
    private float _timeTillBoom;
    public AudioSource boomAudio;
    public GameObject bigBoom;
    public GameObject animateBoom;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if (_countdownFinished)
        {
            //boomAudio.Play();
            bigBoom.SetActive(true);
            animateBoom.SetActive(true);
            new WaitForSeconds(1f);
            Systems.Status.PlayerDeath("You died in a gas explosion");
            //add animation of house exploding
        }
    }

    public void StartGasCount(float time)
    {
        StartCoroutine(nameof(GasCountdown),time);
    }

    private IEnumerator GasCountdown(float CountdownTime)
    {
        _timeTillBoom = CountdownTime;
        while (_timeTillBoom > 0)
        {
            yield return new WaitForSeconds(1f);
            _timeTillBoom--;
            if (showCountdown) Debug.Log("Time Till Boom: " + _timeTillBoom);
        }
        _countdownFinished = true;
    }
}
