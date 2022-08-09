using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [Header("Logo Animators")]
    public Animator fadeIn;
    public Animator fadeOut;
    public Animator flyIn;

    [Header("Title Animators")]
    public Animator background;
    public Animator sam;
    public Animator of;
    public Animator twickenham;
    public Animator ballKick;

    [Header("Button")]
    public GameObject start;
    public GameObject tutorial;

    void Start()
    {
        StartCoroutine(PlayLogo());
    }

    void Update()
    {
        
    }

    public IEnumerator PlayLogo()
    {
        flyIn.SetBool("Play", true);

        yield return new WaitForSeconds(0.7f);

        AudioManager.instance.Play("LogoSound");

        yield return new WaitForSeconds(0.3f);

        fadeIn.SetBool("Play", true);

        yield return new WaitForSeconds(3f);

        fadeOut.SetBool("Play", true);

        yield return new WaitForSeconds(2f);

        StartCoroutine(PlayTitle());
    }

    public IEnumerator PlayTitle()
    {

        background.SetBool("Play", true);

        yield return new WaitForSeconds(1f);

        AudioManager.instance.Play("MainTheme");
        sam.SetBool("Play", true);

        yield return new WaitForSeconds(1f);

        of.SetBool("Play", true);

        yield return new WaitForSeconds(1f);

        twickenham.SetBool("Play", true);

        yield return new WaitForSeconds(1f);

        ballKick.SetBool("Play", true);

        yield return new WaitForSeconds(0.5f);

        start.SetActive(true);
        tutorial.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
