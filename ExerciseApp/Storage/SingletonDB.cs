using System;
using System.Collections.Generic;
using ExerciseApp.Model;
namespace ExerciseApp.Storeage
{
    /// <summary>
    /// Class <c>SingletonDB</c> a singletonDB instance for persistent the objects; It is used for demo purpose and better to implement thread-safety singleton or persistent into rdbs
    /// </summary>
    public sealed class SingletonDB
    {
        private static List<Model.QuoteRequest> requestList = new List<Model.QuoteRequest>();
        private static SingletonDB instance = null;
        public static SingletonDB GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonDB();
                return instance;
            }
        }

        private SingletonDB()
        {

        }

        public void addRequest(QuoteRequest request)
        {
            requestList.Add(request);
        }
    }
}

