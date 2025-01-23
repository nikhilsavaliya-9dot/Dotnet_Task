using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace test.Helpers
{
    public static class InvalidResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new BaseResponse { Message = errors.FirstOrDefault(), Success = false };

            return new BadRequestObjectResult(response);
        }
    }

    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
            => dictionary.SelectMany(m => m.Value.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}
