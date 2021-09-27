using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework
{
    public interface IRepository<CustomeType>
    {
        /// <summary>
        /// اضافه کردن عضو
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CustomeType Add(CustomeType value, eLanguagePack Lang = eLanguagePack.Persian);
        /// <summary>
        /// پیدا کردن عضو
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomeType Get(int id, eLanguagePack Lang = eLanguagePack.Persian);
        /// <summary>
        /// ویرایش عضو
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CustomeType Update(CustomeType value, eLanguagePack Lang = eLanguagePack.Persian);
        /// <summary>
        /// حذف عضو
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CustomeType Delete(int value, eLanguagePack Lang = eLanguagePack.Persian);
        /// <summary>
        /// بر گرداندن تمامی اعضا
        /// </summary>
        /// <returns></returns>
        IEnumerable<CustomeType> GetAll(eLanguagePack Lang = eLanguagePack.Persian);
        /// <summary>
        /// تعداد کل اعضا
        /// </summary>
        /// <returns></returns>
        int GetAllCount(eLanguagePack Lang = eLanguagePack.Persian);
    }
}
