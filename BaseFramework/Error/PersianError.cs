using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.Error
{
    public static class PersianError
    {
        /// <summary>
        /// مقدار را تکراری وارد کرده اید
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string Repetitous(string fieldName = "")
        {
            return "مقدار " + fieldName + " را تکراری وارد کرده اید";
        }

        /// <summary>
        /// مقدار اجباری است.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string Forced(string fieldName = "")
        {
            return "مقدار " + fieldName + " اجباری است.";
        }

        /// <summary>
        /// شماره تلفن
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static string InvalidFormatPhoneNumber(string phoneNumber = "")
        {
            return "فرمت شماره تلفن درست نمیباشد " + phoneNumber;
        }
    }
}
