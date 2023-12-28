using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace UnityTutorial.Addressable
{

    public class SceanLoad : MonoBehaviour
    {
        public string sceneAddress;



        private void Update()
        {

        }

        public void SceneLoadBtnClick()
        {
            LoadRemoteScene();
        }

        void LoadRemoteScene()
        {
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(sceneAddress, UnityEngine.SceneManagement.LoadSceneMode.Additive);

            handle.Completed += OnSceneLoaded;
        }

        void OnSceneLoaded(AsyncOperationHandle<SceneInstance> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Remote scene loaded successfully!");
            }
            else
            {
                Debug.LogError("Failed to load remote scene. Error: " + handle.OperationException);
            }
        }
    }
}

