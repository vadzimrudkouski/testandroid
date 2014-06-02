using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Mindscape.Raygun4Net;

namespace TestAndroid
{
    [Application(Label = "Campus Dish")]
    public class Application : global::Android.App.Application
    {

        /// <summary>
        /// Must implement this constructor for subclassing the application class.
        /// Will act as a global application class throughout the app.
        /// </summary>
        /// <param name="javaReference">pointer to java</param>
        /// <param name="transfer">transfer enumeration</param>
        public Application(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        { }

        /// <summary>
        /// Override on create to instantiate the service container to be persistant.
        /// </summary>
        public override void OnCreate()
        {
            RaygunClient.Attach("JNZwtZ68Y1BhfA0JWtJBUw==");

            RaygunClient.Current.Send(new Exception("Test exc"));
            //TODO: Temporary solution. Need to investigate how to apply certificate.
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
            base.OnCreate();

        }
    }
}