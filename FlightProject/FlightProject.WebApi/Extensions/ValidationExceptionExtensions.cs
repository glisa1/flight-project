//using FluentValidation;

//namespace FlightProject.WebApi.Extensions;

//public static class ValidationExceptionExtensions
//{
//    public static IDictionary<string, string[]> AsProblemsDictionary(this ValidationException exception)
//    {
//        // Unit test this
//        Dictionary<string, string[]> resultDictionary = [];

//        foreach (var entry in exception.Errors)
//        {
//            if (resultDictionary.ContainsKey(entry.PropertyName))
//            {
//                var element = resultDictionary[entry.PropertyName].ToList();
//                element.Add(entry.ErrorMessage);
//                resultDictionary[entry.PropertyName] = [.. element];
//            }
//            else
//            {
//                resultDictionary.Add(entry.PropertyName, [entry.ErrorMessage]);
//            }
//        }

//        return resultDictionary;
//    }
//}
