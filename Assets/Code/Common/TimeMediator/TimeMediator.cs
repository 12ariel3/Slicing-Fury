using Assets.Code.Common.EnergyData;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Code.Common.TimeMediator
{
    public class TimeMediator : MonoBehaviour
    {
        private float _counter = 10;
        struct ServerDateTime
        {
            public string unixtime;
        }

        private int _unixtime;
        private int _lastDateSaved;
        private int _counterToAvoidFirstTimeEvent;



        void Start()
        {
            _counterToAvoidFirstTimeEvent = 0;
            StartCoroutine(GetDateTimeFromServer());

            //Take madafucking off vsync!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Application.targetFrameRate = 60;
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        private void Update()
        {
            _counter -= Time.deltaTime;
            if (_counter <= 0)
            {
                StartCoroutine(GetDateTimeFromServer());
                _counter = 10;
            }
        }


        IEnumerator GetDateTimeFromServer()
        {
            var energySystem = ServiceLocator.Instance.GetService<EnergySystem>();
            _lastDateSaved = energySystem.GetLastDateEnergyRecovered();

            UnityWebRequest request = UnityWebRequest.Get("https://worldtimeapi.org/api/ip");
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                ServerDateTime serverDateTime = JsonUtility.FromJson<ServerDateTime>(request.downloadHandler.text);
                _unixtime = int.Parse(serverDateTime.unixtime);
                int energyToAdd = Mathf.FloorToInt(((_unixtime - _lastDateSaved) / 60) / 5);

                if (energyToAdd >= 1)
                {
                    float currentEnergy = energySystem.GetActualEnergy();
                    float totalEnergy = energySystem.GetTotalEnergy();
                    currentEnergy = Mathf.Min(totalEnergy, currentEnergy + energyToAdd);

                    energySystem.SaveActualEnergy(currentEnergy);
                    energySystem.SaveLastDateEnergyRecovered(_unixtime);

                    if(_counterToAvoidFirstTimeEvent > 0)
                    {
                        ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.EnergyRecovered));
                    }
                    _counterToAvoidFirstTimeEvent++;
                }
            }
            else
            {
                UnityEngine.Debug.Log("failed to load datetime from server with error " + request.result.ToString());
            }
        }
    }
}