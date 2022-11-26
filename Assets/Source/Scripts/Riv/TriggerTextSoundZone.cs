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

    private bool _firstUse = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out XROrigin _))
        {
            TextSoundCall();
        }
    }

    public void TextSoundCall()
    {
        if (!_firstUse)
        {
            VRSubtatile.Instance.ShowSubtitle(_subtitleText);

            if (_subtitleClip != null)
                PlayerAudio.Instance.PlayClip(_subtitleClip);

            _firstUse = true;
        }
    }
}
