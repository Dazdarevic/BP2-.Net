namespace NBP.Application.DTOs
{
    public class ValueDto
    {
        public ValueResponse? Value { get; set; }

        public class ValueResponse
        {
            public int Id { get; set; }
            public string? AccessToken { get; set; }
            public string? RefreshToken { get; set; }
            public string? UserName { get; set; }
            public string? Role { get; set; }
        }
    }
}
