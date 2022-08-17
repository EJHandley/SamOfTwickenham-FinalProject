using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryNotificationUI : MonoBehaviour
{
    public GameObject playerScored;
    public GameObject enemyScored;

    public GameObject playerColour1;
    public GameObject playerColour2;

    public GameObject enemyColour1;
    public GameObject enemyColour2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayerScored()
    {
        AudioManager.instance.Play("CrowdNoise-Cheer");
        playerScored.SetActive(true);
        yield return new WaitForSeconds(.1f);
        playerColour1.SetActive(true);
        yield return new WaitForSeconds(.5f);
        playerColour1.SetActive(false);
        playerColour2.SetActive(true);
        yield return new WaitForSeconds(.5f);
        playerColour2.SetActive(false);
        playerColour1.SetActive(true);
        yield return new WaitForSeconds(.5f);
        playerColour1.SetActive(false);
        playerColour2.SetActive(true);
        yield return new WaitForSeconds(.5f);
        playerColour2.SetActive(false);
        playerColour1.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        playerColour1.SetActive(false);
        playerScored.SetActive(false);
        AudioManager.instance.StopPlaying("CrowdNoise-Cheer");
    }

    public IEnumerator EnemyScored()
    {
        AudioManager.instance.Play("CrowdNoise-Boo");
        enemyScored.SetActive(true);
        yield return new WaitForSeconds(.1f);
        enemyColour1.SetActive(true);
        yield return new WaitForSeconds(.5f);
        enemyColour1.SetActive(false);
        enemyColour2.SetActive(true);
        yield return new WaitForSeconds(.5f);
        enemyColour2.SetActive(false);
        enemyColour1.SetActive(true);
        yield return new WaitForSeconds(.5f);
        enemyColour1.SetActive(false);
        enemyColour2.SetActive(true);
        yield return new WaitForSeconds(.5f);
        enemyColour2.SetActive(false);
        enemyColour1.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        enemyColour1.SetActive(false);
        enemyScored.SetActive(false);
        AudioManager.instance.StopPlaying("CrowdNoise-Boo");
    }
}
