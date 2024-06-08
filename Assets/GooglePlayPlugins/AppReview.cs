using UnityEngine;
using Google.Play.Review;
using System.Collections;

namespace Assets.GooglePlayPlugins
{
    public class AppReview : MonoBehaviour
    {
        ReviewManager _reviewManager;
        PlayReviewInfo _reviewInfo;


        void Start()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _reviewManager = new ReviewManager();
            }
        }

        IEnumerator ReviewOperation()
        {
            yield return new WaitForSeconds(1f);

            var requestFlowOperation = _reviewManager.RequestReviewFlow();
            yield return requestFlowOperation;
            if (requestFlowOperation.Error != ReviewErrorCode.NoError)
            {
                Debug.LogError(requestFlowOperation.Error.ToString());
                yield break;
            }

            _reviewInfo = requestFlowOperation.GetResult();
            var launchFlowOperation = _reviewManager.LaunchReviewFlow(_reviewInfo);
            yield return launchFlowOperation;
            _reviewInfo = null;

            if (launchFlowOperation.Error != ReviewErrorCode.NoError)
            {
                Debug.LogError(launchFlowOperation.Error.ToString());
                yield break;
            }

            //AcaTengo que cambiar el booleano donde guardo si se hizo o no la review para no repetirlo ya
        }

    }
}