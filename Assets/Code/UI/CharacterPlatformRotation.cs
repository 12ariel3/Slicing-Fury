using UnityEngine;

namespace Assets.Code.UI
{
    public class CharacterPlatformRotation : MonoBehaviour
    {
        private RectTransform _rectTransform;

        void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
        }


        void Update()
        {
            _rectTransform.localRotation = Quaternion.Euler(62, 0, -15 * Time.time);
        }
    }
}