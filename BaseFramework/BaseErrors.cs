
namespace BaseFramework
{
    public class BaseErrors
    {
        private string ErrorDescription;
        private string ErrorCode;
        private eLanguagePack Language;

        public BaseErrors(string errorCode,string errorDescription,eLanguagePack language = eLanguagePack.Persian)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
            Language = language;
        }
    }
}
