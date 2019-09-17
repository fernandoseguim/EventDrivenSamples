namespace EmailsService.Domain.Command
{
    public class ValidateEmailTokenCommand
    {
        public string Token { get; set; }
        public string Document { get; set; }
    }
}
