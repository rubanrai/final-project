using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net;
using System;
using Android.Content;

namespace App8
{
    [Activity(Label = "December", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //Get our button from the layout resource,
            Button btnCall = FindViewById<Button>(Resource.Id.button1);
            btnCall.Click += delegate
            {
                //Open dialer
                var uri1 = Android.Net.Uri.Parse("tel:4377775018");
                var intent = new Intent(Intent.ActionDial, uri1);
                StartActivity(Intent);
                /*
                //dial call
                var uri1 = Android.Net.Uri.Parse("tel:3657773550");
                var intent = new Intent(Intent.ActionCall,uri2);
                StartActivity(callintent);*/
            };
            Button btnSMS = FindViewById<Button>(Resource.Id.button2);
            btnSMS.Click += delegate
            {
                var smsContent = FindViewById<EditText>(Resource.Id.txtSMS).Text;

                var smsUri = Android.Net.Uri.Parse("smsto:4377775018");
                var smsIntent = new Android.Content.Intent(Intent.ActionSendto, smsUri);
                smsIntent.PutExtra("sms_body", smsContent);
                StartActivity(smsIntent);
            };
            Button btnEmail = FindViewById<Button>(Resource.Id.button3);

            btnEmail.Click += delegate
            {

                var email = new Intent(Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail,
                               new string[] { "rubankrai@gmail.com", "rubankrai@gmail.com" });

                email.PutExtra(Android.Content.Intent.ExtraCc, new string[] { "rubankrai@gmail.com" });

                email.PutExtra(Android.Content.Intent.ExtraSubject, "Test Email");

                email.PutExtra(Android.Content.Intent.ExtraText, "This is a test email from XAMARIN Android CSD3184");

                email.SetType("message/rfc822");
                StartActivity(email);
            };
        }

        private T FindViewById<T>(object button1)
        {
            throw new NotImplementedException();
        }
    }
}

