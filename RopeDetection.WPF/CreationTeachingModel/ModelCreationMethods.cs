using RopeDetection.CommonData.ViewModels.LabelViewModel;
using RopeDetection.WebService;
using RopeDetection.WebService.Account;
using RopeDetection.WebService.Model;
using RopeDetection.WPF.StaticClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static RopeDetection.CommonData.ModelEnums;

namespace RopeDetection.WPF.CreatingTrainingModel
{
    public class ModelCreationMethods
    {
        //private static string projectDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppContext.BaseDirectory, "../../../../"));
        //private static string testImageOneRelativePath = System.IO.Path.Combine(projectDirectory, "RopeDetection.WPF", "TestImages");
        public async static Task<List<LabelModel>> GetLabels()
        {
            try
            {
                using (var client = ClientHelper.GetClient(StaticUser.Token))
                {
                    ModelService.InitializeClient(client);
                    var o_data = await ModelService.GetLabels();

                    if (o_data.Count != 0)
                    {
                        return o_data;
                    }
                    else
                    {
                        LabelModel label = new LabelModel();
                        label.TextContent = "Произошла ошибка ! Не удалось загрузить список дефектов.";
                        o_data.Add(label);
                        return o_data;
                    }
                }
            }
            catch (Exception ex)
            {
                List<LabelModel> labels = new List<LabelModel>();
                LabelModel label = new LabelModel();
                label.TextContent = "Ошибка: " + ex.Message;
                labels.Add(label);
                return labels;
            }
        }

        public async static Task<List<ModelResponse>> GetModels(bool IsShowTrainedModels)
        {
            try
            {
                using (var client = ClientHelper.GetClient(StaticUser.Token))
                {
                    ModelService.InitializeClient(client);
                    var o_data = await ModelService.GetModels();
                    List<ModelResponse> listModels = new List<ModelResponse>();
                    if(IsShowTrainedModels)
                    {
                        foreach(var model in o_data)
                        {
                            if (model.LearningStatus)
                                listModels.Add(model);
                        }
                    }
                    else
                    {
                        foreach (var model in o_data)
                        {
                            if (!(model.LearningStatus))
                                listModels.Add(model);
                        }
                    }

                    return listModels;
                }
            }
            catch (Exception ex)
            {
                List<ModelResponse> models = new List<ModelResponse>();
                return models;
            }
        }

        public async static Task<string> UploadTrainingFiles(string[] _fileNames, Guid typeId)
        {
            //            List<BitmapImage> bitmapImages = new List<BitmapImage>();
            //            if (_fileNames != null)
            //                imagePageModel.GetListOfImages(_fileNames, bitmapImages);
            //            imagePageModel.NumberSelectedPhotos = bitmapImages.Count.ToString();
            //            var filesFromDirectory = Directory.GetFiles(testImageOneRelativePath, "*",
            //searchOption: SearchOption.AllDirectories);

            List<FileModel> files = new List<FileModel>();

            foreach (var file in _fileNames)
            {
                files.Add(new FileModel
                {
                    FileContent = File.ReadAllBytes(file),
                    FileName = Path.GetFileName(file),
                    FileType = System.IO.Path.GetExtension(file)
                });
            }

            CreateFilesModel model = new CreateFilesModel
            {
                Files = files,
                ModelId = StaticModel.ModelId,
                TypeId = typeId
            };

            using (var client = ClientHelper.GetClient(StaticUser.Token))
            {
                ModelService.InitializeClient(client);
                var o_data = await ModelService.UploadTrainingFiles(model);

                if (o_data.Result.ToString() == "OK")
                {
                    return o_data.SuccessInfo;
                }
                else
                    return "Произошла ошибка: " + o_data.ErrorInfo;
            }
        }

        public async static Task<string> CreateModel(string nameModel, string typeName)
        {
            try
            {
                using (var client = ClientHelper.GetClient(StaticUser.Token))
                {
                    ModelService.InitializeClient(client);
                    //fix it
                    var modelType = (typeName == "Классификация") ? ModelType.Classification : (typeName == "Распознавание объектов")? ModelType.ObjectDetection : ModelType.Regression;
                    var o_data = await ModelService.CreateModel(nameModel, modelType);

                    if (o_data.Result.ToString() == "OK")
                    {
                        StaticModel.ModelId = o_data.Id;
                        StaticModel.NameModel = o_data.Name;
                        StaticModel.IsAllDataEntered = true;
                        return o_data.SuccessInfo;
                    }
                    return "Произошла ошибка. Не получилось создать модель: " + o_data.ErrorInfo;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
