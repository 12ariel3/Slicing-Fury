using UnityEngine;

namespace Assets.Code.MusicAndSound
{
    [CreateAssetMenu(menuName = "Audio/SwordAudioScriptableObject", fileName = "SwordAudioScriptableObject")]
    public class SwordAudioScriptableObject : ScriptableObject
    {
        [SerializeField] private string _audioName;
        [SerializeField] private AudioClip[] _audios;
        public string AudioName => _audioName;

        


        public AudioClip GetRandomAudioClip()
        {
            int randomInt = Random.Range(0, _audios.Length);

            return _audios[randomInt];
        }
    }
}

