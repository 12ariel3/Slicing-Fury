using UnityEngine;

namespace Assets.Code.Trails
{
    public class TrailMovementController : MonoBehaviour
    {
        private TrailRenderer _trailRenderer;


        public void Configure(TrailRenderer trailRenderer)
        {
            _trailRenderer = Instantiate(trailRenderer);
        }


        public void TouchFollow()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y);
            _trailRenderer.gameObject.transform.position = mousePos;
        }
    }
}