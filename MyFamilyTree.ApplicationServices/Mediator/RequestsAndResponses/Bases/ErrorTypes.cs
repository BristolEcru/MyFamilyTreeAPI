
namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases
{
    public static class ErrorTypes
    {
        public static string NotFound = "NOT_FOUND";
        public static string Unauthorized = "UNAUTHORIZED";
        public static string ValidationError = "VALIDATION_ERROR";
        public static string InternalServerError = "INTERNAL_SERVER_ERROR";
        public static string BadRequest = "BAD_REQUEST";//Błąd oznaczający, że żądanie klienta jest niepoprawne lub niekompletne.
        public static string Forbidden = "FORBIDDEN";
        public static string Timeout = "TIMEOUT";
        public static string ServiceUnavailable = "SERVICE_UNAVAILABLE";
        public static string Conflict = "CONFLICT";//Błąd oznaczający konflikt, na przykład podczas próby zapisu danych, które już istnieją
        public static string NotImplemented = "NOT_IMPLEMENTED";
        public static string RequiredField = "This field is required.";
        public static string InvalidEmail = "Please enter a valid email address.";
        public static string StringLengthError = "The length of the field must be between {MinLength} and {MaxLength} characters.";
        public static string RangeError = "The value must be between {MinValue} and {MaxValue}.";
        public static string MustBeTrue = "This condition must be true.";
    }
}
