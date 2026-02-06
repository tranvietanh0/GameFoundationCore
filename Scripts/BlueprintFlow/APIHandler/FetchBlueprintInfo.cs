namespace BlueprintFlow.APIHandler
{
    using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using GameFoundationCore.Scripts.Models.Interfaces;
    using GameFoundationCore.Scripts.Utilities.UserData;
    using Newtonsoft.Json;
    using UnityEngine;
    using UnityEngine.Scripting;

    [Preserve]
    public class BlueprintInfoData : ILocalData
    {
        public string Version;
        public string Hash;
        public string Url;

        public void Init()
        {
        }
    }

    public class FetchBlueprintInfo
    {
        private readonly IHandleUserDataServices handleUserDataServices;

        [Preserve]
        public FetchBlueprintInfo(IHandleUserDataServices handleUserDataServices)
        {
            this.handleUserDataServices = handleUserDataServices;
        }

        public async Task<BlueprintInfoData> GetBlueprintInfo(string fetchUri)
        {
            try
            {
                var request      = (HttpWebRequest)WebRequest.Create(fetchUri);
                var response     = (HttpWebResponse)await request.GetResponseAsync();
                var reader       = new StreamReader(response.GetResponseStream());
                var jsonResponse = await reader.ReadToEndAsync();
                var definition   = new { data = new { blueprint = new BlueprintInfoData() } };
                var responseData = JsonConvert.DeserializeAnonymousType(jsonResponse, definition);
                return responseData?.data.blueprint;
            }
            catch (Exception e)
            {
                //if fetch info fails get info from local
                Debug.LogException(e);
                return await this.handleUserDataServices.Load<BlueprintInfoData>();
            }
        }
    }
}