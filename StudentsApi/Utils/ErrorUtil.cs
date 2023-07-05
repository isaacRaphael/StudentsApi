using System.Text;

namespace StudentsApi.Utils
{
    public class ErrorUtil
    {
        public static string OutputErrorString(System.Exception ex)
        {
            var errorString = new StringBuilder();
            errorString.Append($"================Error======================\n");
            errorString.Append($"message : {ex.Message}\n");
            errorString.Append($"InnerException : {ex.InnerException}\n");
            errorString.Append($"StackTrace : {ex.StackTrace}\n");
            errorString.Append($"===========================================");


            return errorString.ToString();

        }

        public static List<string> ReturnErrorList(System.Exception ex)
        {
            return new List<string> { ex.Message };
        }




    }
}
