using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace MemoryGame.Data
{
    public class ImageRepository : Singleton<ImageRepository>
    {
        string urlMemoryImages = "http://localhost/MemoryImage/api/MemoryImage";

        public void ProcessImageIds(Action<List<int>> processIds)
        {
            StartCoroutine(GetImageIDs(processIds));
        }

        public void GetProcessTexture(int imgID, Action<Texture2D> processTexture)
        {
            StartCoroutine(GetTextures(imgID, processTexture));
        }

        private IEnumerator GetTextures(int imgID, Action<Texture2D> processTexture)
        {
            UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(urlMemoryImages + "/" + imgID);
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("ImageRepository.GetProcessMaterials: " + uwr.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                processTexture(texture);
            }
        }

        private IEnumerator GetImageIDs(Action<List<int>> processIds)
        {
            UnityWebRequest uwrids = UnityWebRequest.Get(urlMemoryImages);
            yield return uwrids.SendWebRequest();
            if (uwrids.result != UnityWebRequest.Result.Success) // in case of error
            {
                Debug.Log("ImageRepository.GetImageIDs: " + uwrids.error);
            }
            else // if it works
            {
                string json = uwrids.downloadHandler.text;
                List<DBImage> images = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DBImage>>(json);
                images = images.Where(i => !i.IsBack).ToList();
                List<int> ids = images.Select(i => i.Id).ToList();
                processIds(ids);
            }
        }
    }
}