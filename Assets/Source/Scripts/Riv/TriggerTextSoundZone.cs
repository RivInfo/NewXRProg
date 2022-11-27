using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TriggerTextSoundZone : MonoBehaviour
{
    [TextArea]
    [SerializeField] string _subtitleText;

    [SerializeField] AudioClip _subtitleClip;

    [SerializeField] private float _duration = 0;

    private bool _firstUse = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerAudio _))
        {
            TextSoundCall();
        }
    }

    public void TextSoundCall()
    {
        if (!_firstUse)
        {
            VRSubtatile.Instance.ShowSubtitle(_subtitleText, _duration);

            if (_subtitleClip != null)
                PlayerAudio.Instance.PlayClip(_subtitleClip);

            _firstUse = true;
        }
    }
}
