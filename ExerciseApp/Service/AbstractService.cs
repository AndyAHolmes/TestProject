using System;
namespace ExerciseApp.Services
{

    /// <summary>
    /// Class <c>AbstractService</c> a abstract service with several abstract methods to be used by child service
    /// </summary>
	public abstract class AbstractService
    {
        int _MIN_AGE = 17;
        int _MAX_AGE = 80;
		public AbstractService(int MIN_AGE, int MAX_AGE) 
		{
            _MIN_AGE = MIN_AGE;
            _MAX_AGE = MAX_AGE;
		}

        public bool isValidAge(DateTime dateOfBirth)
        {

            if (DateTime.Now.Year - ((DateTime)dateOfBirth).Year > _MIN_AGE && DateTime.Now.Year - ((DateTime)dateOfBirth).Year <= _MAX_AGE)
            {
                return true;
            }
            return false;
        }

    }
}

