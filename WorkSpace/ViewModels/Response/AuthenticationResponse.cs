namespace WorkSpace.ViewModels.Response
{
    public class AuthenticationResponse
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
    }
}
