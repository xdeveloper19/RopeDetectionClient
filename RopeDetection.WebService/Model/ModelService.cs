using Newtonsoft.Json;
using RopeDetection.CommonData.ViewModels.Base;
using RopeDetection.CommonData.ViewModels.LabelViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static RopeDetection.CommonData.ModelEnums;

namespace RopeDetection.WebService.Model
{
    public class ModelService
    {
        private static HttpClient _httpClient;

        /// <summary>
        /// Инициализация экземпляра клиента
        /// </summary>
        /// <param name="client"></param>
        public static void InitializeClient(HttpClient client)
        {
            _httpClient = client;
        }
        public static async Task<List<LabelModel>> GetLabels()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"model/getlabels");
                string s_result;
                using (HttpContent responseContent = response.Content)
                {
                    s_result = await responseContent.ReadAsStringAsync();
                }

                List<LabelModel> o_data = new List<LabelModel>();

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        {
                            o_data = JsonConvert.DeserializeObject<List<LabelModel>>(s_result);
                            return o_data;
                        }
                    default:
                        {
                            throw new Exception("Ошибка !");
                        }
                }
            }
            catch (Exception ex)
            {
                List<LabelModel> o_data = new List<LabelModel>();
                //o_data.Error = ex;
                //o_data.Result = CommonData.DefaultEnums.Result.Error;
                return o_data;
            }
        }

        public static async Task<List<ModelResponse>> GetModels()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"model/getmodels");
                string s_result;
                using (HttpContent responseContent = response.Content)
                {
                    s_result = await responseContent.ReadAsStringAsync();
                }

                List<ModelResponse> o_data = new List<ModelResponse>();

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        {
                            o_data = JsonConvert.DeserializeObject<List<ModelResponse>>(s_result);
                            return o_data;
                        }
                    default:
                        {
                            throw new Exception("Ошибка !");
                        }
                }
            }
            catch (Exception ex)
            {
                List<ModelResponse> o_data = new List<ModelResponse>();
                return o_data;
            }
        }

        public static async Task<BaseModel> UploadTrainingFiles(CreateFilesModel model)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync("model/uploadfilesfortraining", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

                string s_result;
                using (HttpContent responseContent = response.Content)
                {
                    s_result = await responseContent.ReadAsStringAsync();
                }

                BaseModel o_data = new BaseModel();
                o_data = JsonConvert.DeserializeObject<BaseModel>(s_result);
                return o_data;
            }
            catch (Exception ex)
            {
                BaseModel o_data = new BaseModel();
                o_data.Error = ex;
                o_data.Result = CommonData.DefaultEnums.Result.Error;
                return o_data;
            }
        }

        public static async Task<CreateModel> CreateModel(string name, ModelType type)
            {
                try
                {
                    var formContent = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                            { "name", name },
                            { "type", type.ToString() },
                    });

                    HttpResponseMessage response = await _httpClient.PostAsync($"model/createmodel?name={name}&type={type}", formContent);
                    string s_result;
                    using (HttpContent responseContent = response.Content)
                    {
                        s_result = await responseContent.ReadAsStringAsync();
                    }

                    CreateModel o_data = new CreateModel();

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            {
                                o_data = JsonConvert.DeserializeObject<CreateModel>(s_result);
                                return o_data;
                            }
                        default:
                            {
                                throw new Exception(response.StatusCode.ToString() + " Server Error");
                            }
                    }

                }
                catch (Exception ex)
                {
                    CreateModel o_data = new CreateModel();
                    return o_data;
                }
            }
        }
}
