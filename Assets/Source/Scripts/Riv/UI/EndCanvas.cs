using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animation))]
public class EndCanvas : MonoBehaviour
{
    private Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    public void StartEnd()
    {
        VRSubtatile.Instance.ShowSubtitle("Спасибо, что играли в игру!");
        _animation.Play();
        Invoke(nameof(SceneMain),2f);
    }

    private void SceneMain()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
