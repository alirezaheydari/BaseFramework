using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.Error
{
    public static class MessError
    {
        public static void GetMess(int errorCode,eLanguagePack language,out string errorDescription, string fieldName="")
        {
            switch (language)
            {
                case eLanguagePack.Persian:
                    GetPersianError(errorCode,out errorDescription, fieldName);
                    break;
                case eLanguagePack.English:
                    break;
                case eLanguagePack.Arabic:
                    break;
                default:
                    break;
            }
            errorDescription = string.Empty;
        }

        private static void GetPersianError(int errorCode,out string errorDescription, string fieldName = "")
        {
            switch (errorCode)
            {
                case 1000:
                    errorDescription = PersianError.Repetitous(fieldName);
                    break;
                case 1001:
                    errorDescription = PersianError.Forced(fieldName);
                    break;
                case 1002:
                    errorDescription = PersianError.InvalidFormatPhoneNumber(fieldName);
                    break;
                default:
                    errorDescription = string.Empty;
                    break;
            }
        }
    }
}
