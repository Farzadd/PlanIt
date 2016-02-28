using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;



namespace PlanIt
{
    public class Main
    {
        //Mobile Service Client reference
        public static MobileServiceClient client;

        public const string applicationURL = @"https://planit-server.azurewebsites.net";

        public static MobileServiceClient MobileService =
            new MobileServiceClient(
            applicationURL
         );
        public static MobileServiceUser user;


        /*
        User newUser = new User();
        newUser.FacebookID = PlanIt.Main.user.UserId;
        newUser.FacebookName = "CHEESECAKE";

        var result = await client
            .InvokeApiAsync<User, string>("createUser", newUser);

        CreateAndShowDialog(result, "FARZ");

        CreateAndShowDialog(string.Format("you are now logged in - {0}",
            user.UserId), "Logged in!");
        */
    }
}
