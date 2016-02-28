using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using PlanIt.Droid;

namespace PlanIt
{
    public class Main
    {
/**********     Fields     **************************************************/
        private const string sApplicationURL = @"https://planit-server.azurewebsites.net";

        //Mobile Service Client reference
        private MobileServiceClient mClient;

        private MobileServiceClient mMobileService =
            new MobileServiceClient(
            sApplicationURL
         );
  
        private MobileServiceUser mMobileServiceUser;
        private MainActivity mMainActivity;

/**********     METHODS     **************************************************/
        public Main(MainActivity mainActivity) {
            this.mMainActivity = mainActivity;

            // Create the Mobile Service Client instance, using the provided
            // Mobile Service URL

            this.mClient = new MobileServiceClient(sApplicationURL);
        }

        public bool IsUserLoggedIn() {
            return false;
        }

        private async Task<bool> testMethod() {
            var success = false;
            try
            {
                User newUser = new User();
                newUser.FacebookID = this.mMobileServiceUser.UserId;
                newUser.FacebookName = "CHEESECAKE";

                var result = await this.mClient
                   .InvokeApiAsync<User, string>("createUser", newUser);

                CreateAndShowDialog(result, "FARZ");

                CreateAndShowDialog(string.Format("you are now logged in - {0}",
                   mMobileServiceUser.UserId), "Logged in!");

                success = true;
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex, "Test Method Failed");
            }
            return success;
        }

        public async Task<bool> Authenticate()
        {
            var success = false;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                this.mMobileServiceUser = await mClient.LoginAsync(this.mMainActivity,
                    MobileServiceAuthenticationProvider.Facebook);

                success = true;
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex, "Authentication failed");
            }
            return success;
        }

        private void CreateAndShowDialog(Exception exception, String title)
        {
            mMainActivity.CreateAndShowDialog(exception.Message, title);
        }
        private void CreateAndShowDialog(String message, String title)
        {
            mMainActivity.CreateAndShowDialog(message, title);
        }
    }
}
