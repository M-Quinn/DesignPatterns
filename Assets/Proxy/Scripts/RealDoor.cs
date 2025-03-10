using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace DesignPatterns.Proxy
{
    public class RealDoor : IDoor
    {
        private GameObject _door;

        public RealDoor(GameObject door)
        {
            _door = door;
        }


        async Task SwingDoorRoutine()
        {
            float totalTime = 1.4f;
            float elapsedTime = 0;
            float value;


            while (elapsedTime / totalTime <= 1.0f)
            {
                elapsedTime += Time.deltaTime;
                value = elapsedTime / totalTime;

                _door.transform.rotation = Quaternion.Euler(0, Mathf.LerpAngle(0, -90, value), 0);
                await Task.Yield();
            }

            _door.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        public void Open(Key key)
        {
            OpenAsyncDoor();
        }

        async void OpenAsyncDoor()
        {
            await SwingDoorRoutine();
        }
    }

}