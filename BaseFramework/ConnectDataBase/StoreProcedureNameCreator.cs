using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.ConnectDataBase
{
    public static class StoreProcedureNameCreator
    {
        private static readonly string StaticName = "USP";
        private static readonly string SeperatorChar = "_";
        public static string GetName(eCRUDBase crud,string tableName)
        {
            return StaticName + SeperatorChar + GetCrudString(crud) + SeperatorChar + tableName;
        }
        private static string GetCrudString(eCRUDBase crud)
        {
            switch (crud)
            {
                case eCRUDBase.Insert:
                    return "INS";
                case eCRUDBase.Update:
                    return "UPD";
                case eCRUDBase.Delete:
                    return "DEL";
                case eCRUDBase.Select:
                    return "SEL";
                default:
                    return string.Empty;
            }
        }
    }
}
