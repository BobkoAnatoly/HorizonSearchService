using Application.Models;
using Octokit;

namespace Application.Helpers
{
    public static class QueryHelper
    {
        public static void DetectLanguage(ref SearchRequest request, RepositorySearchModel model)
        {
            switch (model.Language)
            {
                case "Python": request.Language = Language.Python;
                    break;
                case "JavaScript": request.Language = Language.JavaScript;
                    break;
                case "Java": request.Language = Language.Java;
                    break;
                case "HTML": request.Language = Language.Http;
                    break;
                case "CSharp": request.Language = Language.CSharp;
                    break;
                default: request.Language = null;
                    break;
            }
        }
    }
}
