using System.Text.Json.Serialization;

namespace DesafioAtos.Application.ActionFilters.ValidateModel
{
    public class ValidationError
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Field { get; }

        public string Message { get; }

        public ValidationError(string field, string message)
        {
            Field = (field != string.Empty ? field : null)!;
            Message = message;
        }
    }
}