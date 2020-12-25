using RopeDetection.CommonData.ViewModels.UserViewModel;
using RopeDetection.WebService;
using RopeDetection.WebService.Account;
using RopeDetection.WPF.StaticClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static RopeDetection.CommonData.DefaultEnums;

namespace RopeDetection.WPF.HomeRegistrationLogin
{
    public static class RegistrationAuthMethods
    {
        public async static Task<string> RegisterUser(UserModel model)
        {
            try
            {
                using (var client = ClientHelper.GetClient())
                {
                    AuthService.InitializeClient(client);
                    UserShortModel o_data = null;
                    o_data = await AuthService.Register(model);

                    if (o_data.Result.ToString() == "OK")
                    {
                        return o_data.SuccessInfo;
                        //Console.WriteLine("User: " + o_data.UserFIO);
                        //Console.WriteLine("Info: " + o_data.SuccessInfo);
                    }
                    else
                       return "Ошибка: " + o_data.ErrorInfo;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static async Task<string> ExitMethod()
        {
            using (var client = ClientHelper.GetClient(StaticUser.Token))
            {
                AuthService.InitializeClient(client);
                var o_data = await AuthService.LogOut();

                if (o_data.Result.ToString() == "OK")
                {
                    return o_data.SuccessInfo;
                }
                else
                    return "Ошибка: " + o_data.ErrorInfo;
            }
        }
        public static async Task<string> AuthMethod(string login, string password)
        {
            try
            {
                using (var client = ClientHelper.GetClient())
                {
                    AuthService.InitializeClient(client);
                    UserShortModel o_data = null;
                    o_data = await AuthService.Login(login, password);

                    if (o_data.Result.ToString() == "OK")
                    {                       
                        StaticUser.Token = o_data.Token;
                        return o_data.SuccessInfo.ToString();                        
                    }
                    else
                        return "Ошибка: " + o_data.ErrorInfo;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
