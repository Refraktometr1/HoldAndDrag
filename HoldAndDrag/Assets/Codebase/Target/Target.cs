using UnityEngine;

namespace Codebase.Target
{
    public class Target : MonoBehaviour, Itarget
    {
        [SerializeField] AudioSource _audioSource;

        public void Hit() => _audioSource.Play();
    }
}