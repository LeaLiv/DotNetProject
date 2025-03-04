
namespace DO
{
    [Serializable]
    public class DalExceptionIdNotExist : Exception
    {
        public DalExceptionIdNotExist(string error):base(error)
        {

        }
    }
    [Serializable]
    public class DalExceptionIdAllreadyExist : Exception
    {
        public DalExceptionIdAllreadyExist(string error) : base(error)
        {

        }
    }
    [Serializable]
    public class DalException : Exception
    {
        public DalException(string error) : base(error)
        {

        }
    }


}


