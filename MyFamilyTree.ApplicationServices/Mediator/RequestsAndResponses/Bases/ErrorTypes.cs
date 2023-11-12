
namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases
{
    public static class ErrorTypes
    {
        public const string NotFound = "NOT_FOUND";
        public const string Unauthorized = "UNAUTHORIZED";
        public const string ValidationError = "VALIDATION_ERROR";
        public const string InternalServerError = "INTERNAL_SERVER_ERROR";
        public const string BadRequest = "BAD_REQUEST";//Błąd oznaczający, że żądanie klienta jest niepoprawne lub niekompletne.
        public const string Forbidden = "FORBIDDEN";
        public const string Timeout = "TIMEOUT";
        public const string ServiceUnavailable = "SERVICE_UNAVAILABLE";
        public const string Conflict = "CONFLICT";//Błąd oznaczający konflikt, na przykład podczas próby zapisu danych, które już istnieją
        public const string NotImplemented = "NOT_IMPLEMENTED";
        public const string RequiredField = "This field is required.";
        public const string InvalidEmail = "Please enter a valid email address.";
        public const string StringLengthError = "The length of the field must be between {MinLength} and {MaxLength} characters.";
        public const string RangeError = "The value must be between {MinValue} and {MaxValue}.";
        public const string MustBeTrue = "This condition must be true.";
    }
}
