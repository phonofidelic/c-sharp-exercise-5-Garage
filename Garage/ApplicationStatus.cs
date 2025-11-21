namespace Garage
{
    public  class ApplicationStatus
    {
        public int Code { get; private set; }
        public Exception? Exception { get; private set; }
        public ApplicationStatus(int code, Exception exception)
        {
            Code = code;
            Exception = exception;
        }
        public ApplicationStatus(int code)
        {
            Code = code;
            Exception = null;
        }
    }
}