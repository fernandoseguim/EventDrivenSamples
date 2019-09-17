namespace EmailsService.Domain.Command
{
    public class CreateEmailTokenCommand
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}