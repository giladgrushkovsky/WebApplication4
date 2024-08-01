//using MessageServices;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Text;
  
//namespace MessageService
//{
//    public static class MessageServiceExtention
//    {
//        public static void addMessagesService(this IServiceCollection services)
//        {
//            services.AddSingleton<IMessageService>((svc) =>
//            {
//                var res = ActivatorUtilities.CreateInstance<IMessageService>(svc);
//                return res;
//            });
//        }
//    }
//}
